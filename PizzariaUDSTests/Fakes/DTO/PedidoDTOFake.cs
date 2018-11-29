using PizzariaUDS.DTO;
using System.Collections.Generic;

namespace PizzariaUDSTests.Fakes.DTO
{
    public class PedidoDTOFake
    {
        public static PedidoDTO Obter()
        {
            return new PedidoDTO { PersonalizacoesId = new List<int>(){ 1, 2 },
                                   SaborId = 1,
                                   TamanhoId = 1 };
        }
    }
}
