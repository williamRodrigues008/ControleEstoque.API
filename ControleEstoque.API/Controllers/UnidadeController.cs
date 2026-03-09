using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IUnidade _iunidade;

        public UnidadeController(IUnidade iunidade)
        {
            _iunidade = iunidade;
        }

        [HttpGet("ListarUnidades")]
        public List<Unidade> ListarUnidades()
        {
            var listaDeUnidades = _iunidade.ListarUnidade();
            if (listaDeUnidades is not null)
                return listaDeUnidades;
            else
                return new List<Unidade>();
        }

        [HttpGet("BuscarUnidadeId")]
        public Unidade BuscarUnidadeId([FromBody]int id)
        {
            var unidadePorId = _iunidade.BucarUnidadePorId(id);
            if (unidadePorId is not null)
                return unidadePorId;
            else
                return new Unidade();
        }

        [HttpPost("AdicionarUnidade")]
        public IActionResult AdicionarUnidade([FromBody]Unidade unidade)
        {
            if (_iunidade.AdicionarUnidade(unidade))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("AtualizarUnidade")]
        public IActionResult AtualizarUnidade([FromBody] Unidade unidade)
        {
            if (_iunidade.AtualizarUnidade(unidade))
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("ExcluirUnidade")]
        public IActionResult ExcluirUnidade([FromBody]int id)
        {
            if (_iunidade.ExcluirUnidade(id))
                return Ok();
            else
                return BadRequest();
        }
    }
}
