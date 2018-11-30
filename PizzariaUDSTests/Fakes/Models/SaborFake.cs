using PizzariaUDS.Models;

namespace PizzariaUDSTests.Fakes.Models
{
    public class SaborFake
    {
        public static Sabor Obter()
        {
            return new Sabor { Descricao = "Portuguesa", MinutosParaProduzir = 5 };
        }
    }
}
