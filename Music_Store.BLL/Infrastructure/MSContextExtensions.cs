using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Music_Store.DAL.EF;

namespace Music_Store.BLL.Infrastructure
{
    public static class MSContextExtensions
    {
        public static void AddMusicContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MSContext>(options => options.UseSqlServer(connection));
        }
    }
}
