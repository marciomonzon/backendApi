using Api.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IClienteRepository
    {
        Task<List<ClienteDto>> GetClientes();
        Task<ClienteDto> GetClienteById(int id);
        Task<ClienteDto> CrearUpdate(ClienteDto cliente);
        Task<bool> DeleteCliente(int id);
    }
}
