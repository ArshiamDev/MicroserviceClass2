
using Catalog.Api.Data;
using Catalog.Api.Repositories;

namespace Catalog.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ICatalogContext, CatalogContext>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            var app = builder.Build();
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<ICatalogContext>();
				await CatalogContextSeed.SeedData(context.products);
			}
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
