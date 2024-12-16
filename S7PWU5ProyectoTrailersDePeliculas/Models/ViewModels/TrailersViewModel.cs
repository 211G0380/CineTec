namespace S7PWU5ProyectoTrailersDePeliculas.Models.ViewModels
{
    public class TrailersViewModel
    {
       
        
            public int ID_Trailer { get; set; }
            public string? LinkTrailer { get; set; }

            // Relación con la película
            public string? NombrePelicula { get; set; }
        

    }
}
