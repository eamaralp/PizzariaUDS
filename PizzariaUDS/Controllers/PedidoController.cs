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
        private IPedidoPizzaBusiness _pedidoPizzaBusiness;

        public PedidoController(IPedidoPizzaBusiness pedidoPizzaBusiness)
        {
            _pedidoPizzaBusiness = pedidoPizzaBusiness;
        }

        /// <summary>
        /// Recebe um DTO para gravar um novo pedido no sistema., será necessário informar
        /// o código identificador do tamanho, sabor e opcionalmente uma lista de identificadores
        /// para as personalizações.
        /// </summary>
        /// <returns>Objeto Pedido, contendo todas as informações vinculadas ao pedido</returns>
        [Route("montar")]
        [HttpPost]
        public Pedido MontarPedido([FromBody] PedidoDTO pedido)
        {
            return _pedidoPizzaBusiness.MontarPedido(pedido);
        }
    }
}
