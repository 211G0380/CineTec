using S7PWU5ProyectoTrailersDePeliculas.Models.Entities;

namespace S7PWU5ProyectoTrailersDePeliculas.Models.ViewModels
{
    public class PeliculaViewModel
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; } = null!;
        public string Duracion { get; set; }

        public short AnioSalida { get; set; }

        public string LinkTrailer { get; set; } = null!;

        public string Resumen { get; set; } = null!;
        public decimal Calificacion { get; set; }


        // Relación con el género
        public string? Nombre_Genero { get; set; }
        public string? Clasificacion { get; set; }




    }
}
