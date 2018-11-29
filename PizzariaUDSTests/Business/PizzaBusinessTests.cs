using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PizzariaUDS.Business;
using PizzariaUDS.Repository;
using PizzariaUDSTests.Fakes.DTO;
using PizzariaUDSTests.Fakes.Models;
using System.Collections;
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

        [Test]
        public void Test1()
        {
            var esperado = PizzaFake.Obter();

            _saborRepository.ObterSaborPorId(Arg.Any<int>()).Returns(SaborFake.Obter());
            _tamanhoRepository.ObterTamanhoPorId(Arg.Any<int>()).Returns(TamanhoFake.Obter());
            _personalizacaoRepository.ObterPersonalizacoesPorId(Arg.Any<IEnumerable<int>>()).Returns(PersonalizacaoFake.ObterLista());

            var obtido = new PizzaBusiness(_pizzaRepository, _saborRepository, _tamanhoRepository, _personalizacaoRepository).MontarPizza(PedidoDTOFake.Obter());

            esperado.Should().BeEquivalentTo(obtido);
        }
    }
}
