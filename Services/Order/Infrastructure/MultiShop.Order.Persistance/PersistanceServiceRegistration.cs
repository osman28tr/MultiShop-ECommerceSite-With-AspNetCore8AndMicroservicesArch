using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Abstract;
using MultiShop.Order.Persistance.Repositories;

namespace MultiShop.Order.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            return services;
        }
    }
}
