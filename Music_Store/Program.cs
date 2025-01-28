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
    options.IdleTimeout = TimeSpan.FromMinutes(10); // ������������ ������ (����-��� ���������� ������)
    options.Cookie.Name = "Session"; // ������ ������ ����� ���� �������������, ������� ����������� � �����.

});
// ��������� ������� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot
app.UseSession();   // ��������� middleware-��������� ��� ������ � ��������

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Musics}/{action=Index}/{id?}");
app.Run();

