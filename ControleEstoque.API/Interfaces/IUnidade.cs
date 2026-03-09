using ControleEstoque.API.Entities;

namespace ControleEstoque.API.Interfaces
{
    public interface IUnidade
    {
        List<Unidade> ListarUnidade();
        bool AdicionarUnidade(Unidade unidade);
        bool ExcluirUnidade(int id);
        Unidade BucarUnidadePorId(int id);
        bool AtualizarUnidade(Unidade Unidade);
    }
}
