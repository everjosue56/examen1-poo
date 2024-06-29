using ExamenDePOO.Dtos.Inventario;
using ExamenDePOO.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ExamenDePOO.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioServices _inventarioservices;

        public InventarioController(IInventarioServices categoriesService)
        {
            this._inventarioservices = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _inventarioservices.GetInventario(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var inventario = await _inventarioservices.GetInventarioByIdAsync(id);

            if (inventario == null)
            {
                return NotFound(new { Message = $"No se encontro el producto: {id}" });
            }

            return Ok(inventario);
        }

        [HttpPost]
        public async Task<ActionResult> Create(InventarioCreateDto dto)
        {
            await _inventarioservices.CreateAsync(dto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(Inventario dto, Guid id)
        {
            var result = await _inventarioservices.EditAsync(dto, id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var category = await _inventarioservices.GetInventarioByIdAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            await _inventarioservices.DeleteAsync(id);

            return Ok();

        }
    }
    }