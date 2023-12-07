using Derivco.GameRoulette.Application.Contracts.Persistence;
using Derivco.GameRoulette.Persistence.DatabaseContext;
using Derivco.GameRoulette.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Derivco.GameRoulette.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
    IConfiguration configuration)
        {
            services.AddDbContext<DerivcoDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DerivcoDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBetTypeRepository, BetTypeRepository>();
            services.AddScoped<IBetAllocationRepository, BetAllocationRepository>();
            services.AddScoped<IBetRequestRepository, BetRequestRepository>();

            return services;
        }
    }
}
