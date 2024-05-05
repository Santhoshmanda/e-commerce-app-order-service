using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OGANI.OrderService.Domain.Interfaces;
using OGANI.OrderService.Infrastructure.Persistance;
using OGANI.OrderService.Infrastructure.Repositories;

namespace OGANI.OrderService.Infrastructure.Extensions
{
	public static  class ServiceCollectionExtensions
	{
		public static void AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<OganiDbContext>(options =>
				options
				.UseSqlServer(configuration.GetConnectionString("DbContext")??"")
				.EnableSensitiveDataLogging()
			);

			services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
	}
}

