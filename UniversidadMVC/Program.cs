using Microsoft.EntityFrameworkCore;
using UniversidadMVC;
using UniversidadMVC.Data;
using Microsoft.AspNetCore.Identity;
using UniversidadMVC.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UniversidadDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration["ConnectionStrings:UniversidadDBConnection"]);

});


builder.Services.AddDefaultIdentity<Usuario>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<UniversidadDbContext>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1500);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
