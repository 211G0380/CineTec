using System;
using System.Collections.Generic;

namespace S7PWU5ProyectoTrailersDePeliculas.Models.Entities;

public partial class Generos
{
    public int IdGenero { get; set; }

    public string NombreGenero { get; set; } = null!;

    public virtual ICollection<Peliculas> Peliculas { get; set; } = new List<Peliculas>();
}
