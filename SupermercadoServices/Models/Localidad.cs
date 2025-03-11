using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermercadoServices.Models;

public partial class Localidad
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;
    public bool Eliminado { get; set; } = false;

    public override string ToString()
    {
        return Nombre;
    } 
}
