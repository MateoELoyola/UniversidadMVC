using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Drawing.Drawing2D;
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

        public IActionResult CrearCarrera()
        {
            return View();
        }

        public IActionResult BorrarCarrera()
        {
            return View();
        }


        //Agrega Carreras por Nombre o por html
        //Esto funciona, no te permite crear una carrera con el mismo nombre de una ya creada
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CrearCarreras([Bind("Nombre")] NuevaCarrera otraCarrera)
        {
            Carrera nuevaCategoria = new Carrera();
            nuevaCategoria.Nombre = otraCarrera.Nombre;
            var datosTabla = await _context.Carreras.FirstOrDefaultAsync(m => m.Nombre == otraCarrera.Nombre);
            // "m" es una variable lamba
            if (datosTabla == null)
            {
                await _context.Carreras.AddAsync(nuevaCategoria);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //Borrar Carreras
        //Recorda no dejar comentarios personales dentro del codigo.

        //Borra carreras por Id
        public async Task<IActionResult> BorrarCarreraId([Bind("Id")] NuevaCarrera borrarId)
        {
            if (_context.Carreras == null)
            {
                return Problem("Entity set 'UniversidadDbContext.Carreras'  is null.");
            }

            var carrera = await _context.Carreras.FindAsync(borrarId.Id);

            if (carrera != null)
            {
                _context.Carreras.Remove(carrera);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        //Borra carreras por nombre
        public async Task<IActionResult> BorrarCarreraNombre([Bind("Nombre")] NuevaCarrera borrarNombre)
        {
            if (_context.Carreras == null)
            {
                return Problem("Entity set 'UniversidadDbContext.Carreras'  is null.");
            }

            var carrera = await _context.Carreras.FirstOrDefaultAsync(m => m.Nombre == borrarNombre.Nombre);

            if (carrera != null)

            {
                _context.Carreras.Remove(carrera);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

