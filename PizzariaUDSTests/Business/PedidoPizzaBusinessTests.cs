using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.DTO;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;
using PizzariaUDSTests.Fakes.DTO;
using PizzariaUDSTests.Fakes.Models;
using System.Collections.Generic;

namespace PizzariaUDSTests.Business
{
    [TestFixture]
    public class PedidoPizzaBusinessTests
    {
        private IPedidoRepository _pedidoRepository;
        private IPizzaBusiness _pizzaBusiness;

        [SetUp]
        public void SetUp()
        {
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _pizzaBusiness = Substitute.For<IPizzaBusiness>();
            _pedidoRepository.ClearReceivedCalls();
        }

        private PedidoPizzaBusiness ObterInstancia()
        {
            return new PedidoPizzaBusiness(_pedidoRepository, _pizzaBusiness);
        }

        public static IEnumerable<TestCaseData> ListaPedidos()
        {
            yield return new TestCaseData(PedidoFake.Obter(), PizzaFake.Obter())
                .SetName("[PedidoPizzaBusiness] Deve gravar pedido corretamente, quando houver personalizações");
            yield return new TestCaseData(PedidoFake.ObterSemPersonalizacoes(), PizzaFake.ObterSemPersonalizacoes())
                .SetName("[PedidoPizzaBusiness] Deve gravar pedido corretamente, quando não houver personalizações");
        }

        [TestCaseSource(nameof(ListaPedidos))]
        public void Deve_montar_pedido_corretamente(Pedido pedidoEsperado, Pizza pizza)
        {
            _pizzaBusiness.MontarPizza(Arg.Any<PedidoDTO>()).Returns(pizza);

            var obtido = ObterInstancia().MontarPedido(PedidoDTOFake.Obter());

            pedidoEsperado.Should().BeEquivalentTo(obtido);
            _pedidoRepository.Received(1).SalvarPedido(Arg.Any<Pedido>());
        }

    }
}