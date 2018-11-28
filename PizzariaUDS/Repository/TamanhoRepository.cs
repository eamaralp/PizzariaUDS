using PizzariaUDS.Context;
using PizzariaUDS.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzariaUDS.Repository
{
    public class TamanhoRepository
    {
        private PizzariaContext _context;

        public TamanhoRepository(PizzariaContext context)
        {
            _context = context;
        }

        public static IEnumerable<Tamanho> ListaTamanhos()
        {
            yield return new Tamanho { Descricao = "Pequena", Valor = 20.00M, MinutosParaProduzir = 15 };
            yield return new Tamanho { Descricao = "Média", Valor = 30.00M, MinutosParaProduzir = 20 };
            yield return new Tamanho { Descricao = "Grande", Valor = 40.00M, MinutosParaProduzir = 25 };
        }

        public void SetarTamanhos()
        {
            foreach (var tamanho in ListaTamanhos())
            {
                _context.Add(tamanho);
            }
            _context.SaveChanges();
        }

        public IEnumerable<Tamanho> ObterTamanhos()
        {
            var tamanhos = _context.Tamanhos.ToList();
            return tamanhos;
        }

        public Tamanho ObterTamanhoPorId(int idTamanho)
        {
            return _context.Tamanhos.FirstOrDefault(s => s.TamanhoId == idTamanho);
        }
    }
}
