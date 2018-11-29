using PizzariaUDS.DTO;
using PizzariaUDS.Models;

namespace PizzariaUDS.Business
{
    public interface IPizzaBusiness
    {
        IPizzaProperties MontarPizza(PedidoDTO pedido);
    }
}