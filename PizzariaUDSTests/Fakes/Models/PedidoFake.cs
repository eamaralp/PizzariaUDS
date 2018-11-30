using PizzariaUDS.Models;

namespace PizzariaUDSTests.Fakes.Models
{
    public class PedidoFake
    {
        public static Pedido Obter()
        {
            return new Pedido { Pizza =  PizzaFake.Obter(), TempoDePreparo = 25, ValorTotal = 23.00M };
        }

        public static Pedido ObterSemPersonalizacoes()
        {
            return new Pedido { Pizza = PizzaFake.ObterSemPersonalizacoes(), TempoDePreparo = 20, ValorTotal = 20.00M };
        }

    }
}
