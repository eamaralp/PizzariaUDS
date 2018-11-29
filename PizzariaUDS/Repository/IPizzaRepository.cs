using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public interface IPizzaRepository
    {
        Pizza SalvarPedido(Pizza pizza);
    }
}