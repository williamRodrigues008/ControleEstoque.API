using ControleEstoque.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsumosController : Controller
    {
        [HttpGet("listarInsumos")]
        public async Task<List<IActionResult>> ListarInsumosAsync()
        {   
            
        }

        public async Task<List<Insumo>> BuscarInsumoPorIdAsync(int id)
        {
            return new List<Insumo>(); 
        }
    }
}
