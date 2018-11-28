using PizzariaUDS.DTO;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;

namespace PizzariaUDS.Business
{
    public class PizzaBusiness
    {
        private PizzaRepository _pizzaRepository;
        private SaborRepository _saborRepository;
        private TamanhoRepository _tamanhoRepository;
        private PersonalizacaoRepository _personalizacaoRepository;

        public PizzaBusiness()
        {

        }

        public PizzaBusiness(PizzaRepository pizzaRepository,
                             SaborRepository saborRepository,
                             TamanhoRepository tamanhoRepository,
                             PersonalizacaoRepository personalizacaoRepository)
        {
            _pizzaRepository = pizzaRepository;
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
            _personalizacaoRepository = personalizacaoRepository;
        }

        public Pizza MontarPizza(PedidoDTO pedido)
        {
            var sabor = _saborRepository.ObterSaborPorId(pedido.SaborId);
            var tamanho = _tamanhoRepository.ObterTamanhoPorId(pedido.TamanhoId);
            var presonalizacoes = _personalizacaoRepository.ObterPersonalizacoesPorId(pedido.PersonalizacoesId);

            var pizza = new Pizza()
            {
                Sabor = sabor,
                Tamanho = tamanho,
                Personalizacoes = presonalizacoes
            };

            _pizzaRepository.SalvarPedido(pizza);

            return pizza;
        }
    }
}