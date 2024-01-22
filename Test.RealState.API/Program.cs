using Microsoft.OpenApi.Models;
using Test.RealEstate.API.Middlewares;
using Test.RealEstate.Application;
using Test.RealEstate.Infraestructure.Persistence;
using Test.RealEstate.Infraestructure.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Real Estate API",
        Version = "v1"
    });
    c.EnableAnnotations();
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastuctureServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCors(options => 
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyMethod()
    .AllowAnyOrigin()
    .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Real Estate API");
    });
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
