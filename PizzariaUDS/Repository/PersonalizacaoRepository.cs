using PizzariaUDS.Context;
using PizzariaUDS.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzariaUDS.Repository
{
    public class PersonalizacaoRepository
    {
        private PizzariaContext _context;

        public PersonalizacaoRepository(PizzariaContext context)
        {
            _context = context;
        }

        public static IEnumerable<Personalizacao> ListaPersonalizacoes()
        {
            yield return new Personalizacao { Descricao = "Extra Bacon", Valor = 3.00M };
            yield return new Personalizacao { Descricao = "Sem Cebola" };
            yield return new Personalizacao { Descricao = "Borda Recheada", Valor = 3.00M, MinutosParaProduzir = 5 };
        }

        public void SetarPersonalizacoes()
        {
            foreach (var personalizacao in ListaPersonalizacoes())
            {
                _context.Add(personalizacao);
            }
            _context.SaveChanges();
        }

        public IEnumerable<Personalizacao> ObterPersonalizacoes()
        {
            var personalizacoes = _context.Personalizacoes.ToList();
            return personalizacoes;
        }

        public ICollection<Personalizacao> ObterPersonalizacoesPorId(IEnumerable<int> idsPersinalizacoes)
        {
            var personalizacoes = _context.Personalizacoes.Where(p => idsPersinalizacoes.Contains(p.PersonalizacaoId)).ToList();
            return personalizacoes;
        }

    }
}
