using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermercadoServices.Models;

public partial class DetalleVenta
{
    public int Id { get; set; }

    public int VentaId { get; set; }

    public int ProductoId { get; set; }
    public virtual Producto? Producto { get; set; } = null!;
    public decimal PrecioUnitario { get; set; }

    public int Cantidad { get; set; }

    public virtual Venta? Venta { get; set; } = null!;
    public bool Eliminado { get; set; } = false;
    [NotMapped]
    public decimal SubTotal => Cantidad * PrecioUnitario;
}
