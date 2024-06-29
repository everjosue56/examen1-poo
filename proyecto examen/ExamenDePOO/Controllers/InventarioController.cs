using ExamenDePOO.Dtos.Inventario;
using ExamenDePOO.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamenDePOO.Controllers
{
    [ApiController]
    [Route("api/inventario")]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioServices _inventarioServices;

        public InventarioController(IInventarioServices inventarioServices)
        {
            this._inventarioServices = inventarioServices;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var inventario = await _inventarioServices.GetAllInventariosAsync();
            return Ok(inventario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var inventario = await _inventarioServices.GetInventarioByIdAsync(id);

            if (inventario == null)
            {
                return NotFound(new { Message = $"No se encontró el producto con ID: {id}" });
            }

            return Ok(inventario);
        }

        [HttpPost]
        public async Task<ActionResult> Create(InventarioCreateDto dto)
        {
            await _inventarioServices.CreateAsync(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit( InventarioDto dto, Guid id)
        {
            var result = await _inventarioServices.EditAsync(dto, id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var inventario = await _inventarioServices.GetInventarioByIdAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }

            await _inventarioServices.DeleteAsync(id);
            return Ok();
        }
    }
}
