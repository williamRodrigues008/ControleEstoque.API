using ControleEstoque.API.Entities;

namespace ControleEstoque.API.Interfaces
{
    public interface IMovimentacaoInsumos
    {
        List<MovimentacaoInsumos> ListarMovimentacoes();
        MovimentacaoInsumos BuscarMovimentacaoPorId(int id);
        List<ItensMovimentados> ListarItensMovimentados(int idMovimentacao);
        ItensMovimentados BuscarItemPorId(int id);
        bool AdicionarMovimentacaoInsumo(MovimentacaoInsumos movimentacao);
        bool ExcluirMovimentacao(int id);
        bool EditarMovimentacao(int id);
    }
}
