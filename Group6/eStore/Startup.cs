using DataAccess.Repository.OrderDetailRepo;
using DataAccess.Repository;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register repositories as services
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        // Add controllers
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
