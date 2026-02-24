using ControleEstoque.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Data
{
    public class BdContexto : DbContext
    {
        public BdContexto(DbContextOptions<BdContexto> options) : base(options) { }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Movimentacao> Movimentacao { get; set; }
        public DbSet<ItemMovimentado> ItemMovimentado { get; set; }
        public DbSet<Quimico> Quimico { get; set; }
    }
}
