using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Enums;
using ControleEstoque.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class InsumoService : IInsumos
    {
        private readonly BdContexto _bdContexto;

        public InsumoService(BdContexto bdContexto)
        {
            this._bdContexto = bdContexto;
        }

        public TipoRetornoEnum AdicionarInsumo(Insumo insumo)
        {
            if (insumo is not null)
            {
                _bdContexto.Insumos.Add(insumo);
                _bdContexto.SaveChanges();
                if (_bdContexto.SaveChanges() >= 1)
                    return TipoRetornoEnum.Sucesso;
                else
                    return TipoRetornoEnum.Erro;
            }
            return TipoRetornoEnum.Nulo;
        }

        public Insumo BuscarInsumoPorId(int id) => _bdContexto.Insumos.SingleOrDefault(x => x.Id == id)!;

        public List<Insumo> BuscarInsumos() => _bdContexto.Insumos.ToList();

        public bool EditarInsumo(Insumo insumo)
        {
            if (insumo is null)
                return false;

            _bdContexto.Insumos.Where(x => x.Id == insumo.Id).ExecuteUpdate(x =>
            {
                x.SetProperty(i => i.Nome, insumo.Nome);
                x.SetProperty(i => i.Quantidade, insumo?.Quantidade);
                x.SetProperty(i => i.Unidade, insumo?.Unidade);
            });
            _bdContexto.SaveChanges();
            return _bdContexto.SaveChanges() >= 1 ? true : false;
        }

        public bool ExcluirInsumo(int id)
        {
            _bdContexto.Insumos.Where(x => x.Id == id).ExecuteDelete();
            _bdContexto.SaveChanges();
            return _bdContexto.SaveChanges() >= 1 ? true : false;
        }
    }
}
