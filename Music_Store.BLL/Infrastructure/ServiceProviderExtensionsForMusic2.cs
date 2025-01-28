using Microsoft.Extensions.DependencyInjection;
using Music_Store.BLL.Interfaces;
using Music_Store.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.BLL.Infrastructure
{
    public static class ServiceProviderExtensionsForMusic2
    {
        public static void ServiceProviderForMusic2(this IServiceCollection services)
        {
            services.AddScoped<IMusicService, MusicService>();
        }
    }
}
