using System;
using OGANI.OrderService.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace OGANI.OrderService.Application.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, Services.OrderService>();
            return services;
        }

    }
}

