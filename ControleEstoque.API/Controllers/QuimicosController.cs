using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuimicosController : ControllerBase
    {
        private readonly BdContexto _contexto;
        private readonly IQuimicos _iquimicos;

        public QuimicosController(BdContexto contexto, IQuimicos iquimicos)
        {
            _contexto = contexto;
            _iquimicos = iquimicos;
        }

        [HttpGet("ListarQuimicos")]
        public async Task<IActionResult> ListarQuimicos()
        {
            var listaQuimicos = _iquimicos.ListarQuimicos();
            return listaQuimicos is not null || listaQuimicos.IsNullOrEmpty()
                ? Ok(listaQuimicos)
                : BadRequest("Sem itens para exibição");
        }

        [HttpPost("BuscarQuimicoPorId")]
        public async Task<IActionResult> BuscarQuimicoPorId(int id)
        {
            var quimico = _iquimicos.BuscarQuimicoPorId(id);

            return quimico is not null
                ? Ok(quimico)
                : NotFound("Não foi possivel localizar o item buscado");
        }

        [HttpPost("AdicionarQuimico")]
        public async Task<IActionResult> AdicionarInsumo(Quimico quimico)
        {
            return _iquimicos.AdicionarQuimico(quimico)
                ? Ok("Produto quimico adicionado com sucesso!")
                : BadRequest("Não foi possivel salvar o produto!");
        }

        [HttpPut("EditarQuimico")]
        public async Task<IActionResult> EditarQuimico(Quimico quimico)
        {
            return _iquimicos.EditarQuimico(quimico)
                ? Ok("Alteração realizada com sucesso!")
                : BadRequest("Falha na alteração");
        }

        [HttpDelete("ExcluirQuimico")]
        public async Task<IActionResult> ExcluirQuimico(int id)
        {
            return _iquimicos.ExcluirQuimico(id)
                ? Ok("Produto excluído com sucesso!")
               : BadRequest("Produto não excluído!");
        }
    }
}
