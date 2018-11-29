using NSubstitute;
using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.Context;
using PizzariaUDS.Repository;
using PizzariaUDSTests.Fakes.DTO;

namespace PizzariaUDSTests.Business
{
    [TestFixture]
    public class PedidoPizzaBusinessTests
    {
        private IPedidoRepository _pedidoRepository;
        private PizzaBusiness _pizzaBusiness;
        private IPizzariaContext _pizzariaContext;

        [SetUp]
        public void SetUp()
        {
            _pedidoRepository = Substitute.For<IPedidoRepository>();
        }

        private PedidoPizzaBusiness ObterInstancia()
        {
            return new PedidoPizzaBusiness(_pedidoRepository, _pizzaBusiness, _pizzariaContext);
        }

        [TestCase(TestName = "PedidoPizzaBusiness")]
        public void Deve_montar_pedido_corretamente()
        {
            var obtido = ObterInstancia().MontarPedido(PedidoDTOFake.Obter());
        }
    }
}
