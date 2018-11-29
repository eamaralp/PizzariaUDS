using System.Collections.Generic;
using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public interface IPersonalizacaoRepository
    {
        IEnumerable<IPersonalizacaoProperties> ObterPersonalizacoes();
        IEnumerable<IPersonalizacaoProperties> ObterPersonalizacoesPorId(IEnumerable<int> idsPersinalizacoes);
        void SetarPersonalizacoes();
    }
}