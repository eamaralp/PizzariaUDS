using NSubstitute;
using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.Repository;
using PizzariaUDSTests.Fakes.DTO;

namespace PizzariaUDSTests.Business
{
    [TestFixture]
    public class PizzaBusinessTests
    {
        private IPizzaRepository _pizzaRepository;
        private ISaborRepository _saborRepository;
        private ITamanhoRepository _tamanhoRepository;
        private IPersonalizacaoRepository _personalizacaoRepository;

        [SetUp]
        public void Setup()
        {
            _pizzaRepository = Substitute.For<IPizzaRepository>();
            _saborRepository = Substitute.For<ISaborRepository>();
            _tamanhoRepository = Substitute.For<ITamanhoRepository>();
            _personalizacaoRepository = Substitute.For<IPersonalizacaoRepository>();
        }

        [Test]
        public void Test1()
        {
            new PizzaBusiness(_pizzaRepository, _saborRepository, _tamanhoRepository, _personalizacaoRepository).MontarPizza(PedidoDTOFake.Obter());
        }
    }
}
