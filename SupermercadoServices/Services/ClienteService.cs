using SupermercadoServices.Interfaces;
using SupermercadoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SupermercadoServices.Services
{
    public class ClienteService : GenericService<Cliente>, IClienteService
    {
        public async Task<List<Cliente>?> GetAllAsync(string? Filtro)
        {
            var response = await client.GetAsync($"{_endpoint}?Filtro={Filtro}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<Cliente>>(content, options); ;

        }
    }
}
