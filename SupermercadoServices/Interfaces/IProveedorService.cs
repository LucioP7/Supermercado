using SupermercadoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermercadoServices.Interfaces
{
    public interface IProveedorService : IGenericService<Proveedor>
    {
        public Task<List<Proveedor>?> GetAllAsync(string? Filtro);
    }
}
