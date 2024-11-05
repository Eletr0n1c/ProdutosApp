namespace ProdutosApp.Api.Configurations
{
    public class CorsConfiguration
    {
        public static void Configure (IServiceCollection services)
        {
            services.AddCors( options => 
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:5245", "http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static void Use(IApplicationBuilder app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
