using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SupermercadoServices.Models;

public partial class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "El campos DNI es obligatorio.")]
    public string DNI { get; set; } = null!;

    public string Telefonos { get; set; } = null!;
    public int PuntosFidelizacion { get; set; } = 0;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime FechaNacimiento { get; set; }

    [Required(ErrorMessage = "Debe seleccionar una localidad.")]
    public int? LocalidadId { get; set; }

    public virtual Localidad? Localidad { get; set; }

    public bool Eliminado { get; set; } = false;

    [Required]
    public string FirebaseUid { get; set; } = null!;

    public override string ToString()
    {
        return Nombre;
    }
}
