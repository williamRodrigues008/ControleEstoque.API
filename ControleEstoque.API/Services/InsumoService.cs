using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Enums;
using ControleEstoque.API.Interfaces;

namespace ControleEstoque.API.Services
{
    public class InsumoService : IInsumos
    {
        private readonly BdContexto _bdContexto;

        public InsumoService(BdContexto bdContexto)
        {
            this._bdContexto = bdContexto;
        }

        public TipoRetornoEnum AdicionarInsumo(List<Insumo> insumos)
        {
            if (insumos is not null)
            {
                foreach (var insumo in insumos)
                    _bdContexto.Insumos.Add(insumo);

                if (_bdContexto.SaveChanges() > 1)
                    return TipoRetornoEnum.Sucesso;
                else
                    return TipoRetornoEnum.Erro;
            }
            return TipoRetornoEnum.Nulo;
        }

        public Insumo BuscarInsumoPorId(int id) => _bdContexto.Insumos.SingleOrDefault(x => x.Id == id)!;

        public List<Insumo> BuscarInsumos() => _bdContexto.Insumos.ToList();
    }
}
