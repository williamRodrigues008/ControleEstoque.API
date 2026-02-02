using ControleEstoque.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Data
{
    public class BdContexto : DbContext
    {
        public BdContexto(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Movimentacao> MovimentacaoInsumos { get; set; }
        public DbSet<ItemMovimentado> ItensMovimentados { get; set; }
        public DbSet<Quimico> Quimico { get; set; }
    }
}
