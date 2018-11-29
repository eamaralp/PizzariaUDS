using PizzariaUDS.DTO;
using PizzariaUDS.Exceptions;

namespace PizzariaUDS.Business
{
    public class ValidadorPedido
    {
        public void ValidarPedido(PedidoDTO pedidoDto)
        {
            if (pedidoDto.SaborId.Equals(0))
                throw new BusinessExcpetion("É necessário informar o sabor da pizza para realizar o pedido.");
            if (pedidoDto.TamanhoId.Equals(0))
                throw new BusinessExcpetion("É necessário informar o tamanho da pizza para realizar o pedido.");
        }
    }
}
