using ControleEstoque.API.Entities;
using ControleEstoque.API.Enums;

namespace ControleEstoque.API.Interfaces
{
    public interface IInsumos
    {
        public List<Insumo> BuscarInsumos();
        public Insumo BuscarInsumoPorId(int id);
        public TipoRetornoEnum AdicionarInsumo(Insumo insumos);

    }
}
