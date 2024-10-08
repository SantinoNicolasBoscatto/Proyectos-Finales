using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiManagement.Models._Negocio;
using ServiManagement.Models.Repositorio.Abstracto;
using ServiManagement.Models.Repositorio.Implementado;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Negocio>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("SqLite"));
    //opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrdenesService, OrdenesService>();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    opt.Cookie.HttpOnly = true;
    opt.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
