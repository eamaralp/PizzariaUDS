using PizzariaUDS.Models;

namespace PizzariaUDSTests.Fakes.Models
{
    public class TamanhoFake
    {
        public static Tamanho Obter()
        {
            return new Tamanho { Descricao = "Pequena", Valor = 20.00M, MinutosParaProduzir = 15 };
        }
    }
}
