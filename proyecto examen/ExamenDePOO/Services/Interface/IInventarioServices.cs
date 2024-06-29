using ExamenDePOO.Dtos.Inventario;

namespace ExamenDePOO.Services.Interface
{
    public class IInventarioServices
    {
        internal async Task<object?> GetInventario()
        {
            throw new NotImplementedException();
        }

        public interface IInventarioService
        {
            Task<List<InventarioDto>> GetInventarioListAsync();
            Task<InventarioDto> GetInventarioByIdAsync(Guid id);
            Task<bool> CreateAsync(InventarioCreateDto dto);
            Task<bool> EditAsync(INventarioEditDto dto, Guid id);
            Task<bool> DeleteAsync(Guid id);
        }


    }
}
