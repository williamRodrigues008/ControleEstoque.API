using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly BdContexto _contextoBd;
        private readonly IMovimentacao _movimentacao;

        public MovimentacaoController(BdContexto contextoBd, IMovimentacao movimentacao)
        {
            _contextoBd = contextoBd;
            _movimentacao = movimentacao;
        }

        [HttpGet("ListarMovimentacoes")]
        public List<Movimentacao> ListarMovimentacoes()
        {
            var listaDeMovimentacao = _movimentacao.ListarMovimentacoes();

            if (listaDeMovimentacao is not null)
                return listaDeMovimentacao;
            else
                return new List<Movimentacao>();
        }

        [HttpPost("BuscarMovimentacaoPorId")]
        public async Task<IActionResult> BuscarMovimentacaoPorId(int id) 
        {
            var movimentacao = _movimentacao.BuscarMovimentacaoPorId(id);
            if (movimentacao is not null)
                return Ok(movimentacao);
            else
                return NotFound("Não existe movimentação com o código buscado.");
        }

        [HttpPost("ListarItensMovimentados")]
        public async Task<IActionResult> ListarItensMovimentados(int id)
        {
            var itensMovimentados = _movimentacao.ListarItensMovimentados(id);
            if (itensMovimentados is not null)
                return Ok(itensMovimentados);
            else
                return NotFound("Não há itens dentro dessa movimentação!");
        }

        [HttpPost("BuscarItemPorId")]
        public async Task<IActionResult> BuscarItemPorId(int id)
        {
            var item = _movimentacao.BuscarItemPorId(id);
            if (item is not null)
                return Ok(item);
            else
                return NotFound("Ops! este item não foi localizado no banco de dados.");
        }

        [HttpPost("AdicionarMovimentacaoInsumo")]
        public async Task<IActionResult> AdicionarMovimentacaoInsumo(Movimentacao movimentacao)
        {
            if (movimentacao is not null)
            {
                if (_movimentacao.AdicionarMovimentacaoInsumo(movimentacao))
                    return Ok("Movimentação adicionada com sucesso!");
                else
                    return BadRequest("Houve um problema ao salvar movimentação!");
            }
            else
                return BadRequest("Os dados devem ser preenchidos para serem salvos.");
        }

        [HttpDelete("ExcluirMovimentacao")]
        public async Task<IActionResult> ExcluirMovimentacao(int id)
        {
            if (_movimentacao.ExcluirMovimentacao(id))
                return Ok("Movimentacao Excluida com sucesso");
            else
                return BadRequest("Falha ao excluir movimentação");
        }

        [HttpPut("EditarMovimentacao")]
        public async Task<IActionResult> EditarMovimentacao(Movimentacao movimentacao)
        {
            if (_movimentacao.EditarMovimentacao(movimentacao))
                return Ok("Movimentação salva com sucesso!");
            else
                return BadRequest("Ops! Houve um erro ao salvar Movimentação!");
        }
    }
}
