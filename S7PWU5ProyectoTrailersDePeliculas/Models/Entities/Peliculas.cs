using System;
using System.Collections.Generic;

namespace S7PWU5ProyectoTrailersDePeliculas.Models.Entities;

public partial class Peliculas
{
    public int IdPelicula { get; set; }

    public string Nombre { get; set; } = null!;

    public string LinkTrailer { get; set; } = null!;

    public string Duracion { get; set; } = null!;

    public short AnioSalida { get; set; }

    public string Resumen { get; set; } = null!;

    public int IdGenero { get; set; }

    public int IdClasificacion { get; set; }

    public decimal Calificacion { get; set; }

    public virtual Clasificacion IdClasificacionNavigation { get; set; } = null!;

    public virtual Generos IdGeneroNavigation { get; set; } = null!;
}
