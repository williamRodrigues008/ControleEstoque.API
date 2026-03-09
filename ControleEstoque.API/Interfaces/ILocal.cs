using ControleEstoque.API.Entities;

namespace ControleEstoque.API.Interfaces
{
    public interface ILocal
    {
        List<Local> ListarLocais();
        bool AdicionarLocal(Local local);
        bool ExcluirLocal(int id);
        Local BucarLocalPorId(int id);
        bool AtualizarLocal(Local local);
    }
}
