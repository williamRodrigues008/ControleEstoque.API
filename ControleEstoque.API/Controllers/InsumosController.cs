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
        public async Task<IActionResult> ListarInsumosAsync()
        {
            var insumos = _iinsumos.BuscarInsumos();
            if (insumos is not null)
                return Ok(insumos);
            else
                return BadRequest("Ops! houve um erro na consulta por insumos.");
        }

        [HttpPost("BuscarInsumoPorId")]
        public IEnumerable<Insumo> BuscarInsumoPorId(int id)
        {
            var insumo = _iinsumos.BuscarInsumoPorId(id);
            if (insumo is not null)
               yield return insumo;
            else
                yield return new Insumo();
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
    }
}
