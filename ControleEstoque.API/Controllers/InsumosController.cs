using ControleEstoque.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [ApiController]

    public class InsumosController : Controller
    {
        public async Task<List<Insumos>> ListarInsumosAsync()
        {
            var insumos = new List<Insumos>();
            return insumos;
        }

        public async Task<List<Insumos>> BuscarInsumoPorIdAsync(int id)
        {
            return new List<Insumos>(); 
        }
    }
}
