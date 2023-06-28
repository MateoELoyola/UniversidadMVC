using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Linq;
using UniversidadMVC.Data;
using UniversidadMVC.Models;



namespace UniversidadMVC.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<Usuario> _userMgr { get; }
        private SignInManager<Usuario> _signInMgr { get; }
        private RoleManager<Role> _role { get; }

        private readonly UniversidadDbContext _context;

        public AccountController(UniversidadDbContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signInMgr, RoleManager<Role> role)
        {
            _userMgr = userManager;
            _context = context;
            _signInMgr = signInMgr;
            _role = role;    
        }
     
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //Codigo Registrarse

        // Esto Asigna Roles y Funciona!!!!!!

        public async Task<IActionResult> Registrarse([Bind("UserName,Name,LastName,PasswordRegister")] Registrar userForm)
        {

            Usuario user = new Usuario();
            string passwordAdmin = "12345Abc@";

            //Esto esta mal, pero por alguna razon funciona.
            Role administrador = new Role();
            administrador.Name = "Administrador";
            await _role.CreateAsync(administrador);

            Role usuario = new Role();
            usuario.Name = "ElUsuario";
            await _role.CreateAsync(usuario);

            Usuario segundo = await _userMgr.FindByNameAsync(userForm.UserName);

            if (segundo == null && userForm.PasswordRegister.Equals(passwordAdmin))
            {

                user = new Usuario();
                user.UserName = userForm.UserName;

                
                await _userMgr.CreateAsync(user, userForm.PasswordRegister);
                IdentityResult result = await _userMgr.AddToRoleAsync(user, "Administrador");

                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn", "Account");
                }
            }

            if(segundo == null && !userForm.PasswordRegister.Equals(passwordAdmin))
            {

                user = new Usuario();
                user.UserName = userForm.UserName;

                
                await _userMgr.CreateAsync(user, userForm.PasswordRegister);
                IdentityResult resultado2 = await _userMgr.AddToRoleAsync(user, "ElUsuario");

                if (resultado2.Succeeded)
                {

                    return RedirectToAction("Index", "Home");

                }

            }
            
        return RedirectToAction("Privacy", "Home");

        }

        //Codigo Login

        public async Task<IActionResult> Entrar([Bind("UserName,Password")] Loguearse _logIn)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInMgr.PasswordSignInAsync(_logIn.UserName, _logIn.Password, false, false);
            IList<string> rol = await _userMgr.GetRolesAsync(new Usuario());
            if (result.Succeeded)
            {
                //Nose para que servia este codigo, por eso lo saque.
                
               // HttpContext.Session.SetString("Loguearse", _logIn.UserName);
               // HttpContext.Session.SetString("Role", rol.First());
                
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Error", "Home");

        }

       //Codigo Para ROles

        //Crear roles en la tabla de Roles
        //Role nuevoRol = new Role();
        //nuevoRol.Name = "Administrador";
        //await _role.CreateAsync(nuevoRol);

        //Asignar Rol al usuario
        // await _userMgr.AddToRoleAsync(user, "Administrador");

        //Consultar rol del usuario
        // await _userMgr.GetRolesAsync(user);

    }
}


