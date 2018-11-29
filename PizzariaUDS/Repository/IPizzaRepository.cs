using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public interface IPizzaRepository
    {
        IPizzaProperties SalvarPizza(IPizzaProperties pizza);
    }
}