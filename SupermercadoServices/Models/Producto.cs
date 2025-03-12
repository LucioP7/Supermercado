using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadoServices.Models;

public partial class Producto
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;

    [Required]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
    public decimal Precio { get; set; }

    public bool Eliminado { get; set; } = false;
    public bool Oferta { get; set; } = false;

    public bool DisponibleConPuntos { get; set; } = false;

    [NotMapped]
    public decimal PrecioConPuntos { get; set; }

    public override string ToString()
    {
        return Nombre;
    }
}
