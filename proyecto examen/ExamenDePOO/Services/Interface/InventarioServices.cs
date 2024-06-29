using ExamenDePOO.Dtos.Inventario;
using ExamenDePOO.DataBase.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenDePOO.Services.Interface
{
    public class InventarioServices :  IInventarioServices
    {
        private readonly string _JSON_FILE;

        public InventarioServices()
        {
            _JSON_FILE = "SeedData/inventario.json";
        }

        public async Task<List<InventarioDto>> GetInventarioListAsync()
        {
            return await ReadInventarioFromFileAsync();
        }

        public async Task<bool> CreateAsync(InventarioCreateDto dto)
        {
            var inventarioDto = await ReadInventarioFromFileAsync();

            var nuevoInventario = new InventarioDto
            {
                Id = Guid.NewGuid(),
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio
            };

            inventarioDto.Add(nuevoInventario);

            await WriteInventarioToFileAsync(inventarioDto);

            return true;
        }

        public async Task<bool> EditAsync(Guid id, InventarioDto  dto)
        {
            var inventarioDto = await ReadInventarioFromFileAsync();

            var inventarioExistente = inventarioDto.FirstOrDefault(p => p.Id == id);
            if (inventarioExistente == null)
            {
                return false;  
            }

            inventarioExistente.Nombre = dto.Nombre;
            inventarioExistente.Descripcion = dto.Descripcion;
            inventarioExistente.Precio = dto.Precio;

            await WriteInventarioToFileAsync(inventarioDto);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var inventarioDto = await ReadInventarioFromFileAsync();

            var inventarioParaEliminar = inventarioDto.FirstOrDefault(p => p.Id == id);
            if (inventarioParaEliminar == null)
            {
                return false; 
            }

            inventarioDto.Remove(inventarioParaEliminar);

            await WriteInventarioToFileAsync(inventarioDto);

            return true;
        }

        private async Task<List<InventarioDto>> ReadInventarioFromFileAsync()
        {
            if (!File.Exists(_JSON_FILE))
            {
                return new List<InventarioDto>();
            }

            var json = await File.ReadAllTextAsync(_JSON_FILE);
            var inventarioDto = JsonConvert.DeserializeObject<List<InventarioDto>>(json);

            return inventarioDto ?? new List<InventarioDto>();
        }

        private async Task WriteInventarioToFileAsync(List<InventarioDto> inventarioDto)
        {
            var json = JsonConvert.SerializeObject(inventarioDto, Formatting.Indented);
            await File.WriteAllTextAsync(_JSON_FILE, json);
        }
    }
}
