using ETC.PoliceInquery.HttpClient;
using ETC.PoliceInquery.Shared;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PoliceInquery", Version = "v1" });
});

builder.Services.AddHttpClient("ETC", client =>
{
    var baseUrl = builder.Configuration.GetSection("Urls").Get<UrlSettings>().BaseUrl;
    client.BaseAddress = new Uri(baseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddSingleton<IHttpClientHelperAsync,HttpClientHelperAsync>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
//{
//    return HttpPolicyExtensions
//        .HandleTransientHttpError()
//        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
//        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
//        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
//        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
//        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
//        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
//}
