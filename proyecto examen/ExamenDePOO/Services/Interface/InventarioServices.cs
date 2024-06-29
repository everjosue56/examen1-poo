using ExamenDePOO.DataBase.Entities;
using static ExamenDePOO.Services.Interface.IInventarioServices;
using System.Xml;
using ExamenDePOO.Dtos.Inventario;
using ExamenDePOO.Controllers;

namespace ExamenDePOO.Services.Interface
{
    public class InventarioServices :  IInventarioServices
    { 
            public readonly string _JSON_FILE;

            public InventarioServices()
            {
                _JSON_FILE = "SeedData/inventario.json";
            }

            public async Task<List<InventarioDto>> GetInventarioDtosAsync()
            {
                return await ReadCategoriesFromFileAsync();
            }
            public async Task<InventarioDto> GetInventarioById(Guid id)
            {
                var inventario = await ReadCategoriesFromFileAsync();
                InventarioDto category = inventarios.FirstOrDefault(c => c.Id == id);
                return category;
            }
            public async Task<bool> CreateAsync(InventarioCreateDto dto)
            {
                var inventarioDto = await ReadCategoriesFromFileAsync();

            var  inventario = new InventarioDto
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    Description = dto.Description,
                };

                inventarioDto.Add(inventario);

                var inventarios =  inventarioDto.Select(x => new Cliente
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList();

                return true;
            }
            public async Task<bool> EditAsync(INventarioEditDto dto, Guid id)
            {
                var inventarioDto = await ReadCategoriesFromFileAsync();

                var existingInventario = inventarioDto
                    .FirstOrDefault(category => category.Id == id);
                if (existingInventario is null)
                {
                    return false;
                }

                for (int i = 0; i < inventarioDto.Count; i++)
                {
                    if (inventarioDto[i].Id == id)
                    {
                        inventarioDto[i].Name = dto.Name;
                        inventarioDto[i].Description = dto.Description;
                    }
                }

                var inventario = inventarioDto.Select(x => new Cliente
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList();

                 
                return true;
            }
            public async Task<bool> DeleteAsync(Guid id)
            {
                var inventarioDto = await ReadCategoriesFromFileAsync();
                var InventarioTodelet = inventarioDto.FirstOrDefault(x => x.Id == id);

                if (InventarioTodelet is null)
                {
                    return false;
                }

                inventarioDto.Remove(InventarioTodelet);

                var inventarios = inventarioDto.Select(x => new Cliente
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList();

                

                return true;
            }

            private async Task<List<InventarioDto>> ReadCategoriesFromFileAsync()
            {
                if (!File.Exists(_JSON_FILE))
                {
                    return new List<InventarioDto>();
                }

                var json = await File.ReadAllTextAsync(_JSON_FILE);

               // var categories = JsonConvert.DeserializeObject<List<Cliente>>(json);

                var dtos = inventarios.Select(x => new InventarioDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList();

                return dtos;
            }

            private async Task WriteCategoriesToFileAsync(List<Cliente> inventario)
            {
               

                if (File.Exists(_JSON_FILE))
                {
                    await File.WriteAllTextAsync(_JSON_FILE, json);
                }

            }



        }
}
