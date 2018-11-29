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

        public IPizzaProperties SalvarPizza(IPizzaProperties pizza)
        {
            _context.Pizzas.Add(pizza as Pizza);
            _context.SaveChanges();

            return pizza;
        }
    }
}
