using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class MovimentacaoService : IMovimentacao
    {
        private readonly BdContexto _bdContexto;

        public MovimentacaoService(BdContexto bdContexto)
        {
            _bdContexto = bdContexto;
        }

        public bool AdicionarMovimentacaoInsumo(Movimentacao movimentacao)
        {
            if (movimentacao is not null)
            {
                _bdContexto.Movimentacao.Add(movimentacao);
                _bdContexto.ItemMovimentado.AddRange(movimentacao.ItensMovimentados);
            }

            return _bdContexto.SaveChanges() > 0;
        }

        public ItemMovimentado BuscarItemPorId(int id) => _bdContexto.ItemMovimentado.SingleOrDefault(x => x.MovimentacaoId == id)!;

        public Movimentacao BuscarMovimentacaoPorId(int id) => _bdContexto.Movimentacao.Include(m => m.ItensMovimentados).SingleOrDefault(x => x.Id == id)!;

        public bool EditarMovimentacao(Movimentacao movimentacao)
        {
            if (movimentacao is null)
                return false;

            _bdContexto.Update(movimentacao);
            return _bdContexto.SaveChanges() >= 1;
        }
        public bool ExcluirMovimentacao(int id)
        {
            ExcluirItensMovimentados(id);
            var movimentacaoDeletada = _bdContexto.Movimentacao.Where(x => x.Id == id).ExecuteDelete();
            return movimentacaoDeletada > 0;
        }

        public List<ItemMovimentado> ListarItensMovimentados(int idMovimentacao) => _bdContexto.ItemMovimentado.Where(x => x.MovimentacaoId == idMovimentacao).ToList();

        public void ExcluirItensMovimentados(int idMovimentacao) => _bdContexto.ItemMovimentado.Where(x => x.MovimentacaoId == idMovimentacao).ExecuteDelete();

        public List<Movimentacao> ListarMovimentacoes()
        {
            return _bdContexto.Movimentacao.ToList();
        }
    }
}
