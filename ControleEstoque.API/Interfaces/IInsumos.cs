using ControleEstoque.API.Entities;

namespace ControleEstoque.API.Interfaces
{
    public interface IInsumos
    {
        public Task<IEnumerable<Insumo>> BuscarInsumos();
        public Task<IEnumerable<Insumo>> BuscarInsumoPorId(int id);
        public Task<IEnumerable<Insumo>> AdicionarInsumo(Insumo insumo);

    }
}
