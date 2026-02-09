using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Enums;
using ControleEstoque.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsumosController : Controller
    {
        private readonly BdContexto _bdContexto;
        private readonly IInsumos _iinsumos;

        public InsumosController(BdContexto bdContexto, IInsumos iinsumos)
        {
            _bdContexto = bdContexto;
            _iinsumos = iinsumos;
        }

        [HttpGet("listarInsumos")]
        public List<Insumo> ListarInsumosAsync()
        {
            var insumos = _iinsumos.BuscarInsumos();
            if (insumos is not null)
                return insumos;
            else
                return new List<Insumo>();
        }

        [HttpPost("BuscarInsumoPorId")]
        public async Task<IActionResult> BuscarInsumoPorId(int id)
        {
            var insumo = _iinsumos.BuscarInsumoPorId(id);
            if (insumo is not null)
                return Ok(insumo);
            else
                return BadRequest("Não foi possível localizar o item da busca");
        }

        [HttpPost("AdicionarInsumo")]
        public async Task<IActionResult> AdicionarInsumo(Insumo insumo)
        {
            var adicionadoInsumo = _iinsumos.AdicionarInsumo(insumo);

            if (insumo.Equals(TipoRetornoEnum.Sucesso))
                return Ok("Insumo adicionado com sucesso!");
            else if (insumo.Equals(TipoRetornoEnum.Erro))
                return BadRequest("Ops! Ocorreu um erro na adição do insumo!");
            else
                return BadRequest("Você deve adicionar os dados do insumo!");
        }

        [HttpPut("EditarInsumo")]
        public async Task<IActionResult> EditarInsumo(Insumo insumo)
        {
            return _iinsumos.EditarInsumo(insumo)
                ? Ok("Alteração realizada com sucesso!")
                : BadRequest("Não foi possível realizar esta operação!");
        }

        [HttpDelete("EditarInsumo")]
        public async Task<IActionResult> ExcluirInsumo(int id)
        {
            return _iinsumos.ExcluirInsumo(id)
                ? Ok("Insumo excluído com sucesso!")
                : BadRequest("Ops! ocorreu um erro ao excluir o insumo");
        }
    }
}
