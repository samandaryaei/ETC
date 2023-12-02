using ETC.PoliceInquery.HttpClient;
using ETC.PoliceInquery.Services;
using ETC.PoliceInquery.Shared;
using Polly.Extensions.Http;
using Polly;
using Microsoft.OpenApi.Models;

namespace ETC.PoliceInquery.ServiceConfigurations;

public static class ServiceExtensions
{
    public static void GlobalConfiguration(this IServiceCollection services,
                                        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
    }

    public static void RegisterServices(this IServiceCollection services,
                                        IConfiguration configuration)
    {
        #region Singletons
        services.AddSingleton<IHttpClientHelperAsync, HttpClientHelperAsync>();
        #endregion

        #region Scoped
        services.AddScoped<IUserService, UserService>();
        #endregion

        #region Transient
        #endregion
    }
    public static void HttpClientAndPollyConfiguration(this IServiceCollection services,
                                                       IConfiguration configuration,
                                                       bool isPollyEnable = true)
    {
        var retryPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(new[]
            {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(4),
                    TimeSpan.FromSeconds(8)
            });

        var circuitBreakerPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 3,
                                 durationOfBreak: TimeSpan.FromSeconds(10));

        //var noOpPolicy = Policy.NoOpAsync().AsAsyncPolicy<HttpResponseMessage>();

        var httpClient = services.AddHttpClient("ETC", client =>
        {
            var baseUrl = configuration.GetSection("Urls").Get<UrlSettings>().BaseUrl;
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            //client.Timeout = TimeSpan.FromSeconds(30);
        });

        if (isPollyEnable) httpClient.AddPolicyHandler(request => retryPolicy)
                                     .AddPolicyHandler(request => circuitBreakerPolicy);
    }
    public static void AutoMapperConfigurationConfiguration(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
    public static void SwaggerConfiguration(this IServiceCollection services,
                                            IConfiguration configuration)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PoliceInquery", Version = "v1" });
        });
    }
}
