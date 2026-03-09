using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaisController : ControllerBase
    {
        private readonly BdContexto _contexto;
        private readonly ILocal _ilocal;

        public LocaisController(BdContexto contexto, ILocal ilocal)
        {
            _contexto = contexto;
            _ilocal = ilocal;
        }

        [HttpGet("ListarLocais")]
        public List<Local> ListarLocais()
        {
            var locais = _ilocal.ListarLocais();
            if (locais is not null)
                return locais;
            else
                return new List<Local>();
        }
    }
}
