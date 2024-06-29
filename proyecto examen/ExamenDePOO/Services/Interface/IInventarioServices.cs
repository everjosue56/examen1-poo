using ExamenDePOO.Dtos.Inventario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamenDePOO.Services.Interface
{
    public interface IInventarioServices
    {
        Task<List<InventarioDto>> GetInventarioListAsync();
        Task<InventarioDto> GetInventarioByIdAsync(Guid id);
        Task<bool> CreateAsync(InventarioCreateDto dto);
        Task<bool> EditAsync(InventarioDto dto, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
