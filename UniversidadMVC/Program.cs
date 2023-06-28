using Microsoft.EntityFrameworkCore;
using UniversidadMVC;
using UniversidadMVC.Data;
using Microsoft.AspNetCore.Identity;
using UniversidadMVC.Models;
using Microsoft.Extensions.Options;
/*
public class Program {

    public static async Task Main(string[] args)
    {
*/

        var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("BibliotecaDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BibliotecaDbContextConnection' not found.");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<UniversidadDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration["ConnectionStrings:UniversidadDBConnection"]);

});


//Faltaba el "AddRoles" en esta parte del codigo
builder.Services.AddDefaultIdentity<Usuario>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddRoles<Role>().AddEntityFrameworkStores<UniversidadDbContext>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1500);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});


builder.Services.AddRazorPages();

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


//Este Codigo deberia agregar los roles apenas se corre el programa, y se ejecuta cada vez que se 
//inicia el programa


        /*
using (var scope = app.Services.CreateScope())
{

    
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

    var roles = new[] {"Administrador","Usuario" };

    foreach (var algo in roles)
    {

        if (!await roleManager.RoleExistsAsync(algo))
            await roleManager.CreateAsync(new Role(algo));


    }

          //  [NotMapped]

}



*/





app.Run();
/*
}

}
*/
