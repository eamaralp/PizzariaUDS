using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.Context;
using PizzariaUDS.Repository;

namespace PizzariaUDSTests.Business
{
    [TestFixture]
    public class PedidoPizzaBusinessTests
    {
        private IPedidoRepository _pedidoRepository;
        private PizzaBusiness _pizzaBusiness;
        private PizzariaContext _pizzariaContext;

        [SetUp]
        public void SetUp()
        {

        }

        private PedidoPizzaBusiness ObterInstancia()
        {
            return new PedidoPizzaBusiness(_pedidoRepository, _pizzaBusiness, _pizzariaContext);
        }


    }
}
