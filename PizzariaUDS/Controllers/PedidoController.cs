using Microsoft.AspNetCore.Mvc;
using PizzariaUDS.Business;
using PizzariaUDS.DTO;
using PizzariaUDS.Models;

namespace PizzariaUDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private PedidoPizzaBusiness _pedidoPizzaBusiness;

        public PedidoController(PedidoPizzaBusiness pedidoPizzaBusiness)
        {
            _pedidoPizzaBusiness = pedidoPizzaBusiness;
        }

        [Route("montar")]
        [HttpPost]
        public Pedido MontarPedido([FromBody] PedidoDTO pedido)
        {
            return _pedidoPizzaBusiness.MontarPedido(pedido);
        }
    }
}
