using PizzariaUDS.Context;
using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private PizzariaContext _context;

        public PizzaRepository(PizzariaContext context)
        {
            _context = context;
        }

        public Pizza SalvarPedido(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();

            return pizza;
        }
    }
}
