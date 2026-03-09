using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class UnidadeService : IUnidade
    {
        private readonly BdContexto _contexto;

        public UnidadeService(BdContexto contexto)
        {
            _contexto = contexto;
        }

        public bool AdicionarUnidade(Unidade unidade)
        {
            if (unidade is not null)
                _contexto.Unidade.Add(unidade);
            return _contexto.SaveChanges() > 0;
        }

        public bool AtualizarUnidade(Unidade unidade)
        {
            if (unidade is not null)
                _contexto.Unidade.Where(u => u.Id == unidade.Id)
                    .ExecuteUpdate(uni => uni
                    .SetProperty(i => i.Nome, unidade.Nome));

            return _contexto.SaveChanges() > 0;
        }

        public Unidade BucarUnidadePorId(int id)
        {
            return _contexto.Unidade.SingleOrDefault(u => u.Id == id)!;
        }

        public bool ExcluirUnidade(int id)
        {
           return _contexto.Unidade.Where(u => u.Id == id).ExecuteDelete() > 0;
            
        }

        public List<Unidade> ListarUnidade()
        {
            return _contexto.Unidade.ToList();
        }
    }
}
