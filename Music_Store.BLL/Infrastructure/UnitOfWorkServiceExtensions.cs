using Microsoft.Extensions.DependencyInjection;
using Music_Store.DAL.Interfaces;
using Music_Store.DAL.Repositories;

namespace Music_Store.BLL.Infrastructure
{
    public static class UnitOfWorkServiceExtensions
    {
        public static void AddUnitOfWorkService(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        }
    }
}
