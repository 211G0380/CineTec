using Microsoft.AspNetCore.Mvc;
using S7PWU5ProyectoTrailersDePeliculas.Models.ViewModels;
using S7PWU5ProyectoTrailersDePeliculas.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using S7PWU5ProyectoTrailersDePeliculas.Areas.repositories;

namespace S7PWU5ProyectoTrailersDePeliculas.Controllers
{
    public class HomeController : Controller
    {
        PeliculasBdContext context;
        PeliculaViewModel vmPelicula;
        Repository<Peliculas> peliculaRepository;


        public HomeController()
        {
            context = new PeliculasBdContext();
            vmPelicula = new PeliculaViewModel();

            peliculaRepository = new(context);
        }
        public IActionResult Index()
        {
            var datos = peliculaRepository.GetAll();    
            return View(datos);
        }
        public IActionResult Pelicula(int id)
        {


            ModelState.Clear();
            vmPelicula = context.Peliculas.Where(x=> x.IdPelicula == id).
                Select(x => new PeliculaViewModel
            {
                Nombre = x.Nombre,
                 AnioSalida = x.AnioSalida,
                  Calificacion = x.Calificacion,
                   Clasificacion = x.IdClasificacionNavigation.ClasificacionDePelicula,
                    Duracion = x.Duracion,
                     Nombre_Genero = x.IdGeneroNavigation.NombreGenero,
                      Resumen = x.Resumen,
                      LinkTrailer = x.LinkTrailer,
                      IdPelicula=x.IdPelicula
                      
                      
            }).FirstOrDefault();

            

            return View(vmPelicula);
        }

        // Vista: Create (Formulario para Crear o Editar)
       

       
    }
}
