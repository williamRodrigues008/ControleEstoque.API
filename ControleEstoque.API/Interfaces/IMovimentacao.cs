using ControleEstoque.API.Entities;

namespace ControleEstoque.API.Interfaces
{
    public interface IMovimentacao
    {
        List<Movimentacao> ListarMovimentacoes();
        Movimentacao BuscarMovimentacaoPorId(int id);
        List<ItemMovimentado> ListarItensMovimentados(int idMovimentacao);
        ItemMovimentado BuscarItemPorId(int id);
        bool AdicionarMovimentacaoInsumo(Movimentacao movimentacao);
        bool ExcluirMovimentacao(int id);
        bool EditarMovimentacao(Movimentacao movimentacao);
    }
}
