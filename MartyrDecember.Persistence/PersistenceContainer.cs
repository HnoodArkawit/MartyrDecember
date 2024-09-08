using MartyrDecember.Application.Contracts;
using MartyrDecember.Persistence.Repositories;
using MartyrDecember_Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MartyrDecember.Persistence
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MartyrDecemberDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IMarPicRepository), typeof(MarPicRepository));
            services.AddScoped(typeof(IMarVidRepository), typeof(MarVidRepository));
            services.AddScoped(typeof(ISayRepository), typeof(SayRepository));
            services.AddScoped(typeof(IProfileRepository), typeof(ProfileRepository));

            return services;
        }
    }
}
