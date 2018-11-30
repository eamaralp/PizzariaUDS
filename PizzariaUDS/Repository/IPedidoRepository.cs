using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public interface IPedidoRepository
    {
        Pedido SalvarPedido(Pedido pedido);
    }
}