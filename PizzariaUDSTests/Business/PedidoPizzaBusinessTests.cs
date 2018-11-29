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
        private IPizzaBusiness _pizzaBusiness;
        private IPizzariaContext _pizzariaContext;

        [SetUp]
        public void SetUp()
        {
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _pizzaBusiness = Substitute.For<IPizzaBusiness>();
            _pizzariaContext = Substitute.For<IPizzariaContext>();
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
