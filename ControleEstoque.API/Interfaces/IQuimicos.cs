using ControleEstoque.API.Entities;

namespace ControleEstoque.API.Interfaces
{
    public interface IQuimicos
    {
        List<Quimico> ListarQuimicos();
        Quimico BuscarQuimicoPorId(int id);
        bool AdicionarQuimico(Quimico quimico);
        bool EditarQuimico(Quimico quimico);
        bool ExcluirQuimico(int id);

    }
}
