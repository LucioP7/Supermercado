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
            return JsonSerializer.Deserialize<List<Cliente>>(content, options);
        }

        public async Task<int> ObtenerSaldoPuntosAsync()
        {
            var response = await client.GetAsync($"{_endpoint}/saldoPuntos");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("Error al obtener saldo de puntos.");
            }
            return JsonSerializer.Deserialize<int>(content, options);
        }

        public async Task<Cliente?> ObtenerClientePorUidAsync(string firebaseUid)
        {
            var response = await client.GetAsync($"{_endpoint}/buscarPorUid?firebaseUid={firebaseUid}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return null; // Si no se encuentra, devolvemos null
            }

            return JsonSerializer.Deserialize<Cliente>(content, options);
        }

        public async Task<Cliente?> CrearClienteAsync(Cliente nuevoCliente)
        {
            var jsonContent = new StringContent(JsonSerializer.Serialize(nuevoCliente), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_endpoint}", jsonContent);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("Error al crear el cliente: " + content);
            }

            return JsonSerializer.Deserialize<Cliente>(content, options);
        }


    }
}
