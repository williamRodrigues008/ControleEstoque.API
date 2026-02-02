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

        public bool AdicionarMovimentacaoInsumo(Movimentacao movimentacao)
        {
            if (movimentacao is not null)
                _bdContexto.MovimentacaoInsumos.Add(movimentacao);

            return _bdContexto.SaveChanges() > 0 ? true : false;
        }

        public ItemMovimentado BuscarItemPorId(int id) => _bdContexto.ItensMovimentados.SingleOrDefault(x => x.IdMovimentacao == id)!;

        public Movimentacao BuscarMovimentacaoPorId(int id) => _bdContexto.MovimentacaoInsumos.SingleOrDefault(x => x.Id == id)!;

        public bool EditarMovimentacao(Movimentacao movimentacao)
        {
            if (movimentacao is null)
                return false;

            _bdContexto.MovimentacaoInsumos.Where(x => x.Id == movimentacao.Id).ExecuteUpdate(x =>
            { 
                x.SetProperty(m => m.ItensMovimentados, movimentacao.ItensMovimentados);
                x.SetProperty(m => m.DataMovimentacao, movimentacao?.DataMovimentacao);
                x.SetProperty(m => m.Local, movimentacao?.Local);
                x.SetProperty(m => m.Solicitante, movimentacao?.Solicitante);
                x.SetProperty(m => m.Responsavel, movimentacao?.Responsavel);
            });
            return _bdContexto.SaveChanges() > 0 ? true : false;
        }
        public bool ExcluirMovimentacao(int id)
        {
            _bdContexto.MovimentacaoInsumos.Where(x => x.Id == id).ExecuteDelete();
            return _bdContexto.SaveChanges() > 0 ? true : false;
        }

        public List<ItemMovimentado> ListarItensMovimentados(int idMovimentacao) => _bdContexto.ItensMovimentados.Where(x => x.IdMovimentacao == idMovimentacao).ToList();

        public List<Movimentacao> ListarMovimentacoes()
        {
            return _bdContexto.MovimentacaoInsumos
                .Take(20)
                .ToList();
        }
    }
}
