using PizzariaUDS.Context;
using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public class PizzaRepository
    {
        private PizzaContext _context;

        public PizzaRepository(PizzaContext context)
        {
            _context = context;
        }

        public Pizza SalvarPedido(Pizza pedidoPizza)
        {
            var pizza = _context.Pizzas.Add(pedidoPizza);
            _context.SaveChanges();

            return pizza.Entity;
        }
    }
}
