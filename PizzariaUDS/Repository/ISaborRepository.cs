using System.Collections.Generic;
using PizzariaUDS.Models;

namespace PizzariaUDS.Repository
{
    public interface ISaborRepository
    {
        IEnumerable<ISaborProperties> ObterSabores();
        ISaborProperties ObterSaborPorId(int idSabor);
        void SetarSabores();
    }
}