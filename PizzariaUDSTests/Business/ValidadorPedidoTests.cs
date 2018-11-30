using FluentAssertions;
using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.DTO;
using PizzariaUDS.Exceptions;
using System.Collections.Generic;

namespace PizzariaUDSTests.Business
{
    [TestFixture]
    public class ValidadorPedidoTests
    {
        private const string MENSAGEM_ERRO_SABOR = "É necessário informar o sabor da pizza para realizar o pedido.";
        private const string MENSAGEM_ERRO_TAMANHO = "É necessário informar o tamanho da pizza para realizar o pedido.";

        public static IEnumerable<TestCaseData> ListaPedidos()
        {
            yield return new TestCaseData(new PedidoDTO { SaborId = 0, TamanhoId = 1 }, MENSAGEM_ERRO_SABOR)
                .SetName("[ValidadorPedido] Deve lançar exceção quando o ID do sabor for inválido");
            yield return new TestCaseData(new PedidoDTO { SaborId = 1, TamanhoId = 0 }, MENSAGEM_ERRO_TAMANHO)
                .SetName("[ValidadorPedido] Deve lançar exceção quando o ID do tamanho for inválido");
        }

        [TestCaseSource(nameof(ListaPedidos))]
        public void Deve_validar_corretamente_dto_pedido_invalido(PedidoDTO pedidoDto, string mensagemExcecaoEsperada)
        {
            var excecao = Assert.Throws<BusinessExcpetion>( () => new ValidadorPedido().ValidarPedido(pedidoDto) );

            excecao.Message.Should().Be(mensagemExcecaoEsperada);
        }

    }
}