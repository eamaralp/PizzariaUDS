using PizzariaUDS.Models;

namespace PizzariaUDSTests.Fakes.Models
{
    public class PizzaFake
    {
        public static Pizza Obter()
        {
            return new Pizza()
            {
                Tamanho = TamanhoFake.Obter(),
                Sabor = SaborFake.Obter(),
                Personalizacoes = PersonalizacaoFake.ObterLista()
            };
        }

        public static Pizza ObterSemPersonalizacoes()
        {
            return new Pizza()
            {
                Tamanho = TamanhoFake.Obter(),
                Sabor = SaborFake.Obter()
            };
        }
    }
}
