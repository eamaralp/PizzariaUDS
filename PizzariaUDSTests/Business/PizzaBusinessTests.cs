using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;
using PizzariaUDSTests.Fakes.DTO;
using PizzariaUDSTests.Fakes.Models;
using System.Collections.Generic;

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

        private PizzaBusiness ObterInstancia()
        {
            return new PizzaBusiness(_pizzaRepository, _saborRepository, _tamanhoRepository, _personalizacaoRepository);
        }

        [TestCase(TestName = "[PizzaBusiness] Deve montar pizza corretamente")]
        public void Deve_montar_pizza_corretamente()
        {
            var esperado = PizzaFake.Obter();

            _saborRepository.ObterSaborPorId(Arg.Any<int>()).Returns(SaborFake.Obter());
            _tamanhoRepository.ObterTamanhoPorId(Arg.Any<int>()).Returns(TamanhoFake.Obter());
            _personalizacaoRepository.ObterPersonalizacoesPorId(Arg.Any<IEnumerable<int>>()).Returns(PersonalizacaoFake.ObterLista());

            var obtido = ObterInstancia().MontarPizza(PedidoDTOFake.Obter());

            esperado.Should().BeEquivalentTo(obtido);
        }

        [TestCase(TestName = "[PizzaBusiness] Deve realizar consultas dos itens para montar a Pizza")]
        public void Deve_realizar_consulta_dos_itens_da_pizza()
        {
            var esperado = PizzaFake.Obter();
            var obtido = ObterInstancia().MontarPizza(PedidoDTOFake.Obter());

            _saborRepository.Received(1).ObterSaborPorId(Arg.Any<int>());
            _tamanhoRepository.Received(1).ObterTamanhoPorId(Arg.Any<int>());
            _personalizacaoRepository.Received(1).ObterPersonalizacoesPorId(Arg.Any<IEnumerable<int>>());

            _pizzaRepository.Received(1).SalvarPizza(Arg.Any<IPizzaProperties>());
        }

    }
}
