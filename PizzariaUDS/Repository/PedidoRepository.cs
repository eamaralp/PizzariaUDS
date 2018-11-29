using PizzariaUDS.Context;
using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private IPizzariaContext _context;

        public PedidoRepository(IPizzariaContext context)
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