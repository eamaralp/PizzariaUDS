using PizzariaUDS.Models;
using System.Collections.Generic;

namespace PizzariaUDSTests.Fakes.Models
{
    public class PersonalizacaoFake
    {
        public static ICollection<Personalizacao> ObterLista()
        {
            return new List<Personalizacao> {
                new Personalizacao { Descricao = "Borda Recheada", Valor = 3.00M, MinutosParaProduzir = 5 }
            };
        }
    }
}
