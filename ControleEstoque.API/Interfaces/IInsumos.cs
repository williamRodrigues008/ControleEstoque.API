using ControleEstoque.API.Entities;

namespace ControleEstoque.API.Interfaces
{
    public interface IInsumos
    {
        public List<Insumo> BuscarInsumos();
        public Insumo BuscarInsumoPorId(int id);
        public TipoRetornoEnum AdicionarInsumo(List<Insumo> insumos);

    }
}
