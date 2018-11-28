using PizzariaUDS.Context;
using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public class PedidoRepository
    {
        private PizzariaContext _context;

        public PedidoRepository(PizzariaContext context)
        {
            _context = context;
        }

        public Pedido SalvarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return pedido;
        }
    }
}
