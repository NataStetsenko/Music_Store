using Microsoft.Extensions.DependencyInjection;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.BLL.Services;


namespace Music_Store.BLL.Infrastructure
{
    public static class ServiceProviderExtensionsForMusic
    {
        public static void ServiceProviderForMusic(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryMiddle<MusicDTO>, MusicService>();
        }
    }
}
