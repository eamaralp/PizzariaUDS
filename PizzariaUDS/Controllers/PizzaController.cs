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
        private SaborRepository _saborRepository;
        private TamanhoRepository _tamanhoRepository;
        private PersonalizacaoRepository _personalizacaoRepository;

        public PizzaController(SaborRepository saborRepository, TamanhoRepository tamanhoRepository, PersonalizacaoRepository personalizacaoRepository)
        {
            _saborRepository = saborRepository;
            _tamanhoRepository = tamanhoRepository;
            _personalizacaoRepository = personalizacaoRepository;
        }

        [Route("Tamanhos")]
        [HttpGet]
        public IEnumerable<Tamanho> ObterTamanhos()
        {
            return _tamanhoRepository.ObterTamanhos();
        }

        [Route("Sabores")]
        [HttpGet]
        public IEnumerable<Sabor> ObterSabores()
        {
            return _saborRepository.ObterSabores();
        }

        [Route("Personalizacoes")]
        [HttpGet]
        public IEnumerable<Personalizacao> ObterPersonalizacoes()
        {
            return _personalizacaoRepository.ObterPersonalizacoes();
        }
    }
}
