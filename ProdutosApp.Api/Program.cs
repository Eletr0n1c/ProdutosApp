using ProdutosApp.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

SwaggerConfiguration.Configure(builder.Services);
DependencyInjectionConfiguration.Configure(builder.Services);
CorsConfiguration.Configure(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


CorsConfiguration.Use(app);
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }