using Api.Data;
using Api.Models;
using Api.Models.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public ClienteRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClienteDto> CrearUpdate(ClienteDto cliente)
        {
            var clienteMapeado = _mapper.Map<Cliente>(cliente);
            if (cliente.Id > 0)
            {
                _context.Clientes.Update(clienteMapeado);
            }
            else
            {
                await _context.Clientes.AddAsync(clienteMapeado);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<ClienteDto>(clienteMapeado);
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                    return false;

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ClienteDto> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            return _mapper.Map<ClienteDto>(cliente);
        }

        public async Task<List<ClienteDto>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();

            return _mapper.Map<List<ClienteDto>>(clientes);
        }
    }
}
