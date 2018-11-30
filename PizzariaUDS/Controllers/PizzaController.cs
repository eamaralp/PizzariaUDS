using Microsoft.AspNetCore.Mvc;
using PizzariaUDS.Models;
using PizzariaUDS.Repository;
using System.Collections.Generic;

namespace PizzariaUDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private ISaborRepository _saborRepository;
        private ITamanhoRepository _tamanhoRepository;
        private IPersonalizacaoRepository _personalizacaoRepository;

        public PizzaController(ISaborRepository saborRepository, ITamanhoRepository tamanhoRepository, IPersonalizacaoRepository personalizacaoRepository)
        {
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
            _personalizacaoRepository = personalizacaoRepository;
        }

        /// <summary>
        /// Obtem a lista de todos os tamanhos de pizza cadastrados no sistema.
        /// </summary>
        /// <returns>Lista de objetos contento os tamanhos de pizza com as propriedades
        /// [Descrição, MinutosParaProduzir, Valor e TamanhoId.</returns>
        [Route("Tamanhos")]
        [HttpGet]
        public IEnumerable<ITamanhoProperties> ObterTamanhos()
        {
            return _tamanhoRepository.ObterTamanhos();
        }

        /// <summary>
        /// Obtem a lista de todos os sabores de pizza cadastrados no sistema.
        /// </summary>
        /// <returns>Lista de objetos contento os sabores de pizza com as propriedades
        /// [Descrição, MinutosParaProduzir, Valor e TSaborId.</returns>
        [Route("Sabores")]
        [HttpGet]
        public IEnumerable<ISaborProperties> ObterSabores()
        {
            return _saborRepository.ObterSabores();
        }

        /// <summary>
        /// Obtem a lista de todas as personalizações de pizza cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de objetos contento as personalizações de pizza com as propriedades
        /// [Descrição, MinutosParaProduzir, Valor e PersonalizacaoId.</returns>
        [Route("Personalizacoes")]
        [HttpGet]
        public IEnumerable<IPersonalizacaoProperties> ObterPersonalizacoes()
        {
            return _personalizacaoRepository.ObterPersonalizacoes();
        }
    }
}
