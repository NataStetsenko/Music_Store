using Microsoft.EntityFrameworkCore;
using Music_Store.BLL.Interfaces;
using Music_Store.BLL.Services;
using Music_Store.BLL.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMusicContext(connection);
builder.Services.AddUnitOfWorkService();
builder.Services.ServiceProviderForUser();
builder.Services.ServiceProviderForUser2();
builder.Services.ServiceProviderForSinger();
builder.Services.ServiceProviderForStyle();
builder.Services.ServiceProviderForMusic();
builder.Services.ServiceProviderForMusic2();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Длительность сеанса (тайм-аут завершения сеанса)
    options.Cookie.Name = "Session"; // Каждая сессия имеет свой идентификатор, который сохраняется в куках.

});
// Добавляем сервисы MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // обрабатывает запросы к файлам в папке wwwroot
app.UseSession();   // Добавляем middleware-компонент для работы с сессиями

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Musics}/{action=Index}/{id?}");
app.Run();

