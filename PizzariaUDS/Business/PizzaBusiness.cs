using PizzariaUDS.DTO;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;
using System.Collections.Generic;

namespace PizzariaUDS.Business
{
    public class PizzaBusiness : IPizzaBusiness
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ISaborRepository _saborRepository;
        private readonly ITamanhoRepository _tamanhoRepository;
        private readonly IPersonalizacaoRepository _personalizacaoRepository;

        public PizzaBusiness(IPizzaRepository pizzaRepository,
                             ISaborRepository saborRepository,
                             ITamanhoRepository tamanhoRepository,
                             IPersonalizacaoRepository personalizacaoRepository)
        {
            _pizzaRepository = pizzaRepository;
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
            _personalizacaoRepository = personalizacaoRepository;
        }

        public IPizzaProperties MontarPizza(PedidoDTO pedido)
        {
            var sabor = _saborRepository.ObterSaborPorId(pedido.SaborId);
            var tamanho = _tamanhoRepository.ObterTamanhoPorId(pedido.TamanhoId);
            var presonalizacoes = _personalizacaoRepository.ObterPersonalizacoesPorId(pedido.PersonalizacoesId);

            var pizza = new Pizza()
            {
                Sabor = sabor as Sabor,
                Tamanho = tamanho as Tamanho,
                Personalizacoes = presonalizacoes as IEnumerable<Personalizacao>
            };

            _pizzaRepository.SalvarPizza(pizza);

            return pizza;
        }
    }
}