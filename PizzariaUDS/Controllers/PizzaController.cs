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

        [Route("Tamanhos")]
        [HttpGet]
        public IEnumerable<ITamanhoProperties> ObterTamanhos()
        {
            return _tamanhoRepository.ObterTamanhos();
        }

        [Route("Sabores")]
        [HttpGet]
        public IEnumerable<ISaborProperties> ObterSabores()
        {
            return _saborRepository.ObterSabores();
        }

        [Route("Personalizacoes")]
        [HttpGet]
        public IEnumerable<IPersonalizacaoProperties> ObterPersonalizacoes()
        {
            return _personalizacaoRepository.ObterPersonalizacoes();
        }
    }
}
