using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class MovimentacaoService : IMovimentacaoInsumos
    {
        private readonly BdContexto _bdContexto;

        public MovimentacaoService(BdContexto bdContexto)
        {
            _bdContexto = bdContexto;
        }

        public bool AdicionarMovimentacaoInsumo(MovimentacaoInsumos movimentacao)
        {
            if (movimentacao is not null)
                _bdContexto.MovimentacaoInsumos.Add(movimentacao);
              
            if (_bdContexto.SaveChanges() > 0)
                    return true;
            return false;
        }

        public ItensMovimentados BuscarItemPorId(int id) => _bdContexto.ItensMovimentados.SingleOrDefault(x => x.IdMovimentacao == id)!;

        public MovimentacaoInsumos BuscarMovimentacaoPorId(int id) => _bdContexto.MovimentacaoInsumos.SingleOrDefault(x => x.Id == id)!;

        public MovimentacaoInsumos EditarMovimentacao(int id) => BuscarMovimentacaoPorId(id);
        public bool ExcluirMovimentacao(int id)
        {
            _bdContexto.MovimentacaoInsumos.Where(x => x.Id == id).ExecuteDelete();
            if (_bdContexto.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public List<ItensMovimentados> ListarItensMovimentados(int idMovimentacao) => _bdContexto.ItensMovimentados.Where(x => x.IdMovimentacao == idMovimentacao).ToList();

        public List<MovimentacaoInsumos> ListarMovimentacoes()
        {
            return _bdContexto.MovimentacaoInsumos
                .Take(20)
                .ToList();
        }
    }
}
