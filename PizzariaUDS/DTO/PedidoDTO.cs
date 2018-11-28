using System.Collections.Generic;

namespace PizzariaUDS.DTO
{
    public class PedidoDTO
    {
        public int SaborId { get; set; }
        public int TamanhoId { get; set; }
        public IEnumerable<int> PersonalizacoesId { get; set; }
    }
}
