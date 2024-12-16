using S7PWU5ProyectoTrailersDePeliculas.Models.Entities;

namespace S7PWU5ProyectoTrailersDePeliculas.Areas.Admin.Models
{
    public class AgregarViewModel
    {
        public IEnumerable<Generos> GenerosSeleccionar { get; set; }
        public IEnumerable<Clasificacion> ClasificacionSeleccionar { get; set; }

        public Peliculas Peliculas { get; set; }

        public IFormFile Imagen { get; set; } = null!;
    }
}
