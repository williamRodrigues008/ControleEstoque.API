using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
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

        public Insumo BuscarInsumoPorIdAsync(int id)
        {
            var insumo = _iinsumos.BuscarInsumoPorId(id);
            if (insumo is not null)
                return insumo;
            else
                return new Insumo();
        }
    }
}
