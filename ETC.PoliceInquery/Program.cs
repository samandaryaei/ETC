using ETC.PoliceInquery.Authorization;
using ETC.PoliceInquery.ServiceConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.GlobalConfiguration(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);
builder.Services.HttpClientAndPollyConfiguration(builder.Configuration,
    bool.Parse(builder.Configuration.GetSection("IsPollyEnable").Value));
builder.Services.AutoMapperConfigurationConfiguration(builder.Configuration);
builder.Services.SwaggerConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

//TODO بعدا آدرس دقیق کلاینت در کورس مشخص شود
app.UseCors(x => x
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());

app.UseMiddleware<BasicAuthMiddleware>();

//app.UseAuthorization();

app.MapControllers();

app.Run();
