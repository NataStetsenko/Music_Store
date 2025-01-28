using Microsoft.Extensions.DependencyInjection;
using Music_Store.BLL.DTO;
using Music_Store.BLL.Interfaces;
using Music_Store.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.BLL.Infrastructure
{
    public static class ServiceProviderExtensionsForUser
    {
        public static void ServiceProviderForUser(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryMiddle<UserDTO>, UserService>();
        }
    }
}
