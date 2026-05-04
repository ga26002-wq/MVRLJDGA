using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVRLJDGA.DataAccess.Database;
using MVRLJDGA.DataAccess.Interfaces;
using MVRLJDGA.DataAccess.Repositories;

namespace MVRLJDGA.DataAccess
{
    public static class DataAccessExtensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibreriaConnection")));

            services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));

            return services;
        }
    }
}