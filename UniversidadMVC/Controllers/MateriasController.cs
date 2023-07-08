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
    public class MateriasController : Controller
    {

        private readonly UniversidadDbContext _context;

        public MateriasController(UniversidadDbContext context)
        {
            _context = context;
        }
        public IActionResult AgregarMaterias()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        /*
        //COdigo Original

        public async Task<IActionResult> AgregarMateria([Bind("Carrera,Nombre,Identificador")] MateriasParaAgregar materias)
        {
            Materia materiaFalsa = new Materia();
            materiaFalsa.Nombre = materias.Nombre;
           
            Carrera carreraFalsa = new Carrera();
            carreraFalsa.Nombre = materias.Carrera;

            List<Materia> x = new List<Materia>();
       
            var datosTabla = await _context.Carreras.FirstOrDefaultAsync(m => m.Nombre.Equals(carreraFalsa.Nombre));

            
            if (datosTabla != null && datosTabla.Materias == null)
            {

                datosTabla.Materias = x;
                datosTabla.Materias.Add(materiaFalsa);         
                await _context.SaveChangesAsync();

            }           
/*
           if (datosTabla != null && datosTabla.Materias != null)
            {
                datosTabla.Materias.Add(materiaFalsa);
                await _context.SaveChangesAsync();
            }
*/      
          //      return RedirectToAction(nameof(Index));
      //  }

        //Version 2 del codigo de arriba con chatgpt 
        public async Task<IActionResult> AgregarMateria([Bind("Carrera,Nombre")] MateriasParaAgregar materias)
        {
            Materia materiaFalsa = new Materia();
            materiaFalsa.Nombre = materias.Nombre;

            Carrera carreraFalsa = new Carrera();
            carreraFalsa.Nombre = materias.Carrera;

            var datosTabla = await _context.Carreras.FirstOrDefaultAsync(m => m.Nombre.Equals(carreraFalsa.Nombre));

            if (datosTabla != null)
            {
                if (datosTabla.Materias == null)
                {
                    datosTabla.Materias = new List<Materia>();
                }

                datosTabla.Materias.Add(materiaFalsa);
                //necesito el await aca?
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }








    }
}
