using PizzariaUDS.Context;
using PizzariaUDS.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzariaUDS.Repository
{
    public class TamanhoRepository
    {
        private PizzaContext _context;

        public TamanhoRepository(PizzaContext context)
        {
            _context = context;
        }

        public static IEnumerable<Tamanho> ListaTamanhos()
        {
            yield return new Tamanho { Descricao = "Pequena", Valor = 20.00M, MinutosParaProduzir = 15 };
            yield return new Tamanho { Descricao = "Média", Valor = 30.00M, MinutosParaProduzir = 20 };
            yield return new Tamanho { Descricao = "Grande", Valor = 40.00M, MinutosParaProduzir = 25 };
        }

        public void SetTamanhos()
        {
            foreach (var tamanho in ListaTamanhos())
            {
                _context.Add(tamanho);
            }
            _context.SaveChanges();
        }

        public IEnumerable<Tamanho> ObterTamanhos()
        {
            SetTamanhos();
            var tamanhos = _context.Tamanhos.ToList();
            return tamanhos;
        }

        public Tamanho ObterTamanhoPorId(int idTamanho)
        {
            return _context.Tamanhos.FirstOrDefault(s => s.TamanhoId == idTamanho);
        }
    }
}
