using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Data;
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

        public async Task<IActionResult> Registrarse([Bind("UserName,Name,LastName,PasswordRegister")] Registrar userForm)
        {

            Usuario user = new Usuario();


       










            //Esto no funcionaba, voy a cambiarlo
           

               
                    Role administrador = new Role();
                    administrador.Name = "Administrador";
                    await _role.CreateAsync(administrador);

                    Role usuario = new Role();
                    usuario.Name = "Usuario";
                    await _role.CreateAsync(usuario);

                    user.UserName = userForm.UserName;
                    await _userMgr.CreateAsync(user, userForm.PasswordRegister);
                    IdentityResult resultado = await _userMgr.AddToRoleAsync(user, "Administrador");

                    return RedirectToAction("Index", "Home");

                

            
           
            

                Usuario segundo = await _userMgr.FindByNameAsync(userForm.UserName);

                if (segundo == null)
                {
                    user = new Usuario();
                    user.UserName = userForm.UserName;

                    IdentityResult result = await _userMgr.CreateAsync(user, userForm.PasswordRegister);

                    //Crear roles en la tabla de Roles
                    //Role nuevoRol = new Role();
                    //nuevoRol.Name = "Administrador";
                    //await _role.CreateAsync(nuevoRol);

                    //Asignar Rol al usuario
                   // await _userMgr.AddToRoleAsync(user, "Administrador");

                    //Consultar rol del usuario
                   // await _userMgr.GetRolesAsync(user);

                    if (result.Succeeded)
                    {

                        return RedirectToAction("Index", "Carreras");

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
                HttpContext.Session.SetString("Usuario", _logIn.UserName);
                HttpContext.Session.SetString("Rol", rol.First());
                return RedirectToAction("Index", "Carreras");
            }
            return RedirectToAction("Index", "Home");

        }

        






    }
}
