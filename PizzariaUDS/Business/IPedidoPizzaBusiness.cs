using PizzariaUDS.DTO;
using PizzariaUDS.Models;

namespace PizzariaUDS.Business
{
    public interface IPedidoPizzaBusiness
    {
        Pedido MontarPedido(PedidoDTO pedidoDto);
    }
}