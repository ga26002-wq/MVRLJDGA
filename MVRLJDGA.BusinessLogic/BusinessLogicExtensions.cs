using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MVRLJDGA.BusinessLogic
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}