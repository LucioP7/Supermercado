using SupermercadoServices.Enums;
using System;
using System.Collections.Generic;

namespace SupermercadoServices.Models;

public partial class Compra
{
    public int Id { get; set; }

    public FormaDePagoEnum FormaDePago { get; set; }

    public int Iva { get; set; }

    public int Total { get; set; }

    public DateTime Fecha { get; set; }

    public int? ProveedorId { get; set; }

    public virtual Proveedor? Proveedor { get; set; }
    public bool Eliminado { get; set; } = false;

}
