using Microsoft.AspNetCore.Mvc;
using ExamenDePOO.Total;
using ExamenDePOO.DataBase.Entities;  

namespace ExamenDePOO.Controllers
{
    [ApiController]
    [Route("api/pedidos")]
    public class PedidoController : ControllerBase
    {
        [HttpGet("calcular-total")]
        public ActionResult<decimal> CalcularTotalPedido(List<Producto> productos)
        {
            var calculadora = new CalcularTotal();
            calculadora.CalcularTotalPedido(productos);
            return calculadora.Total;
        }
    }
}
