using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class QuimicoService : IQuimicos
    {
        private readonly BdContexto _bdContexto;

        public QuimicoService(BdContexto bdContexto)
        {
            _bdContexto = bdContexto;
        }

        public bool AdicionarQuimico(Quimico quimico)
        {
            if (quimico is not null)
                _bdContexto.Quimico.Add(quimico);

            _bdContexto.SaveChanges();
            return _bdContexto.SaveChanges() >= 1 ? true : false;
        }

        public Quimico BuscarQuimicoPorId(int id) => _bdContexto.Quimico.SingleOrDefault(q => q.Id == id)!;

        public bool EditarQuimico(Quimico quimico)
        {
            if (quimico is null)
                return false;

            _bdContexto.Quimico.Where(x => x.Id == quimico.Id).ExecuteUpdate(i =>
            {
                i.SetProperty(i => i.Nome, quimico.Nome);
                i.SetProperty(i => i.Quantidade, quimico?.Quantidade);
                i.SetProperty(i => i.Concentrado, quimico?.Concentrado);
            });
            _bdContexto.SaveChanges();
            return _bdContexto.SaveChanges() >= 1 ? true : false;
        }

        public bool ExcluirQuimico(int id)
        {
            _bdContexto.Quimico.Where(x => x.Id == id).ExecuteDelete();
            _bdContexto.SaveChanges();
            return _bdContexto.SaveChanges() >= 1 ? true : false;
        }

        public List<Quimico> ListarQuimicos()
        {
            return _bdContexto.Quimico
                .Take(20)
                .ToList();
        }
    }
}
