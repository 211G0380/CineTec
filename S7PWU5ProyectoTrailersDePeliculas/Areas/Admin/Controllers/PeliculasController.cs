using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using S7PWU5ProyectoTrailersDePeliculas.Areas.Admin.Models;
using S7PWU5ProyectoTrailersDePeliculas.Areas.repositories;
using S7PWU5ProyectoTrailersDePeliculas.Models.Entities;
using System;


namespace S7PWU5ProyectoTrailersDePeliculas.Areas.Admin.Controllers.Controllers

{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class PeliculasController : Controller
    {
        PeliculasBdContext context;
        AgregarViewModel model;
        Repository<Peliculas> peliculaRepository;
        Repository<Generos> generosRepository;
        Repository<Clasificacion> clasificacionRepository;

        public PeliculasController()
        {
            context = new PeliculasBdContext();
            peliculaRepository = new(context);
            generosRepository = new(context);
            clasificacionRepository = new(context);
            model = new AgregarViewModel();
        }

        // Vista principal de películas
        [Route("/Admin")]
        public ActionResult Index()
        {
            var peliculas = peliculaRepository.GetAll();
            return View(peliculas);
        }

        // Agregar película: GET
        [HttpGet]
        public IActionResult AgregarPelicula()
        {
             

            model.GenerosSeleccionar = generosRepository.GetAll();
            model.ClasificacionSeleccionar = clasificacionRepository.GetAll();


            return View(model);
        }

        // Agregar película: POST
        [HttpPost]
        public IActionResult AgregarPelicula(AgregarViewModel vm)
        {
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(vm.Peliculas.Nombre))
                ModelState.AddModelError("", "El *Nombre* es obligatorio.");

            if (vm.Peliculas.AnioSalida <= 1500)
                ModelState.AddModelError("", "El *Año de salida* es inválido.");

            if (ModelState.IsValid)
            {
                peliculaRepository.Insert(vm.Peliculas);

                var ruta = $"wwwroot/imagenes/{vm.Peliculas.Nombre}.jpg";
                if (vm.Imagen != null)
                {
                    FileStream fs = System.IO.File.Create(ruta);
                    vm.Imagen.CopyTo(fs);
                    fs.Close();
                }

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // Editar película: GET
        [HttpGet]
        public IActionResult EditarPelicula(int id)
        {
            var pelicula = peliculaRepository.Get(id);
            AgregarViewModel model = new AgregarViewModel()
            {
                Peliculas = pelicula,
                GenerosSeleccionar = generosRepository.GetAll(),
                ClasificacionSeleccionar=clasificacionRepository.GetAll()
                

            };
            return View(model);
        }
           
            
        

        // Editar película: POST
        [HttpPost]
        public IActionResult EditarPelicula(AgregarViewModel vm)
        {
            ModelState.Clear();
            if (string.IsNullOrWhiteSpace(vm.Peliculas.Nombre))
                ModelState.AddModelError("", "El *Nombre* es obligatorio.");

            if (vm.Peliculas.AnioSalida <= 0)
                ModelState.AddModelError("", "El *Año de salida* es inválido.");

           var genero= generosRepository.Get(vm.Peliculas.IdPelicula);
            var clasificacion = clasificacionRepository.Get(vm.Peliculas.IdPelicula);
            if (ModelState.IsValid)
            {
                var pelicula = peliculaRepository.Get(vm.Peliculas.IdPelicula);
                if (pelicula == null)
                    return RedirectToAction("Index");

                // Actualizar propiedades
                pelicula.Nombre = vm.Peliculas.Nombre;
                pelicula.Duracion = vm.Peliculas.Duracion;
                pelicula.AnioSalida = vm.Peliculas.AnioSalida;
                pelicula.Resumen = vm.Peliculas.Resumen;
                pelicula.Calificacion = vm.Peliculas.Calificacion;
                pelicula.IdGenero = vm.Peliculas.IdGenero;
                pelicula.IdClasificacion = vm.Peliculas.IdClasificacion;

                peliculaRepository.Update(pelicula);

                var ruta = $"wwwroot/imagenes/{vm.Peliculas.Nombre}.jpg";
                if (vm.Imagen != null)
                {
                    FileStream fs = System.IO.File.Create(ruta);
                    vm.Imagen.CopyTo(fs);
                    fs.Close();
                }

                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // Eliminar película: GET
        [HttpGet]
        public IActionResult EliminarPelicula(int id)
        {
            var pelicula = peliculaRepository.Get(id);
            if (pelicula == null)
                return RedirectToAction("Index");


            return View(pelicula);
        }

        // Eliminar película: POST
        [HttpPost]
        public IActionResult EliminarPelicula(Peliculas vm)
        {
            var pelicula = peliculaRepository.Get(vm.IdPelicula);
            if (pelicula == null)
                return RedirectToAction("Index");
            else
            {
                var ruta = $"wwwroot/imagenes/{pelicula.Nombre}.jpg";
                if (System.IO.File.Exists(ruta))
                {
                    System.IO.File.Delete(ruta);
                }

                peliculaRepository.Delete(pelicula);


                
            }
            return RedirectToAction("Index");

        }




    }
}
