using System.Collections.Generic;
using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public interface ITamanhoRepository
    {
        ITamanhoProperties ObterTamanhoPorId(int idTamanho);
        IEnumerable<ITamanhoProperties> ObterTamanhos();
        void SetarTamanhos();
    }
}