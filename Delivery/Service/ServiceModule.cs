using Domain;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.Implements;
using Service.Interfaces;

namespace Service
{
    public class ServiceModule : IModule
    {
        public void Registry(IServiceCollection services)
        {
            services.AddTransient<IOrderRepo, OrderRepo>();

            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
