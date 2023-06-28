using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using UniversidadMVC.Data;
using UniversidadMVC.Models;



namespace UniversidadMVC.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<Usuario> _userMgr { get; }
        private SignInManager<Usuario> _signInMgr { get; }

        private readonly UniversidadDbContext _context;

        public AccountController(UniversidadDbContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signInMgr)
        {
            _userMgr = userManager;
            _context = context;
            _signInMgr = signInMgr;
       
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

            Usuario user = await _userMgr.FindByNameAsync(userForm.UserName);

             if (user == null)
             {
                 user = new Usuario();
                 user.UserName = userForm.UserName;

                 IdentityResult result = await _userMgr.CreateAsync(user,userForm.PasswordRegister);

                 if (result.Succeeded)
                 {

                     return RedirectToAction("Index", "Home");

                 }
             }

            return RedirectToAction("Index", "Home");
        }

        //Codigo Login
        
        public async Task<IActionResult> Entrar([Bind("UserName,Password")] Loguearse _logIn)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInMgr.PasswordSignInAsync(_logIn.UserName, _logIn.Password, false, false);
            //IList<string> rol = await _userMgr.GetRolesAsync(new Usuario());
            if (result.Succeeded)
            {
                HttpContext.Session.SetString("Usuario", _logIn.UserName);
                //HttpContext.Session.SetString("Rol", rol.First());
                return RedirectToAction("Index", "Carreras");
            }
            return RedirectToAction("Index", "Home");

        }

        






    }
}
