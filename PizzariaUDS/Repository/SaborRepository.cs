using PizzariaUDS.Context;
using PizzariaUDS.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzariaUDS.Repository
{
    public class SaborRepository : ISaborRepository
    {
        private readonly IPizzariaContext _context;

        public SaborRepository(IPizzariaContext context)
        {
            _context = context;
        }

        public static IEnumerable<Sabor> ListaSabores()
        {
            yield return new Sabor { Descricao = "Calabresa" };
            yield return new Sabor { Descricao = "Maguerita" };
            yield return new Sabor { Descricao = "Portuguesa", MinutosParaProduzir = 5 };
        }

        public void SetarSabores()
        {
            foreach (var sabor in ListaSabores())
            {
                _context.Sabores.Add(sabor);
            }
            _context.SaveChanges();
        }

        public IEnumerable<ISaborProperties> ObterSabores()
        {
            var sabores = _context.Sabores.ToList();
            return sabores;
        }

        public ISaborProperties ObterSaborPorId(int idSabor)
        {
            return _context.Sabores.FirstOrDefault(s => s.SaborId == idSabor);
        }
    }
}