using NSubstitute;
using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.Repository;
using PizzariaUDSTests.Fakes.DTO;

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
        }

        private PedidoPizzaBusiness ObterInstancia()
        {
            return new PedidoPizzaBusiness(_pedidoRepository, _pizzaBusiness);
        }

        [TestCase(TestName = "PedidoPizzaBusiness")]
        public void Deve_montar_pedido_corretamente()
        {
            var obtido = ObterInstancia().MontarPedido(PedidoDTOFake.Obter());
        }
    }
}
