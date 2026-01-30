using ControleEstoque.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Data
{
    public class BdContexto : DbContext
    {
        public BdContexto(DbContextOptions<DbContext> options) : base(options) { }

        DbSet<Insumo> Insumos { get; set; }
    }
}
