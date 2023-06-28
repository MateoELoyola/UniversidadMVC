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
    public class CarrerasController : Controller
    {

        private readonly UniversidadDbContext _context;

        public CarrerasController(UniversidadDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Administrador")]
        public IActionResult Index()
        {
            return View();
        }

       // [Authorize(Roles = "Administrador, ElUsuario")]
        public IActionResult Materias()
        {
            return View();
        }




        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AgregarMateria([Bind("Id,Nombre,Materia")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materia);
        }


        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> AgregarCarreras([Bind("AutorId,Name,LastName")] Carrera carrera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carrera);
        }







    }
}

