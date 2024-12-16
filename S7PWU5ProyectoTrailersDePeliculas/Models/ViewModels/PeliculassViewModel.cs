using Microsoft.AspNetCore.Mvc.Rendering;

namespace S7PWU5ProyectoTrailersDePeliculas.Models.ViewModels
{
    public class PeliculassViewModel
    {
        public int ID_Pelicula { get; set; } // Usado para editar si es necesario
        public string? Nombre { get; set; }


        public TimeSpan Duracion { get; set; }
        public short AnioSalida { get; set; }
        public string? Resumen { get; set; }
        public decimal Calificacion { get; set; }

        // Lista de géneros para desplegar en un dropdown
        public int ID_Genero { get; set; }
        public List<SelectListItem>? Generos { get; set; }

        public IEnumerable<OtrasPeliculasModel> OtrasPelis { get; set; } = null!;



    }
    public class OtrasPeliculasModel
    {
        public int ID_Pelicula { get; set; } // Usado para editar si es necesario
        public string? Nombre { get; set; }
    }
}
