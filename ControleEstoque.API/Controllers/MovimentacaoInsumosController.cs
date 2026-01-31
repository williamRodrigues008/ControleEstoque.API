using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoInsumosController : ControllerBase
    {
        [HttpGet("ListarMovimentacoes")]
        public Task<IActionResult> ListarMovimentacoes()
        {
            
        }
    }
}
