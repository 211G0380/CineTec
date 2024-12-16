using System;
using System.Collections.Generic;

namespace S7PWU5ProyectoTrailersDePeliculas.Models.Entities;

public partial class Clasificacion
{
    public int IdClasificacion { get; set; }

    public string ClasificacionDePelicula { get; set; } = null!;

    public virtual ICollection<Peliculas> Peliculas { get; set; } = new List<Peliculas>();
}
