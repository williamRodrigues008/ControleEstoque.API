using ControleEstoque.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuimicosController : ControllerBase
    {
        private readonly BdContexto _contexto;

    }
}
