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
    public static class ServiceProviderExtensionsForUser2
    {
        public static void ServiceProviderForUser2(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
