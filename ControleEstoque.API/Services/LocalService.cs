using ControleEstoque.API.Data;
using ControleEstoque.API.Entities;
using ControleEstoque.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.API.Services
{
    public class LocalService : ILocal
    {
        private readonly BdContexto _context;

        public LocalService(BdContexto context)
        {
            _context = context;
        }

        public bool AdicionarLocal(Local local)
        {
            if (local is not null)
                _context.Local.Add(local);
            return _context.SaveChanges() > 0;
        }

        public bool AtualizarLocal(Local local)
        {
            _context.Local.Where(x => x.Id == local.Id).ExecuteUpdate(l => l
            .SetProperty(p => p.Nome, local.Nome)
            .SetProperty(p => p.Tipo, local.Tipo)
            );
            return _context.SaveChanges() > 0;
        }

        public Local BucarLocalPorId(int id)
        {
            return _context.Local.SingleOrDefault(x => x.Id == id)!;
        }

        public bool ExcluirLocal(int id)
        {
            return _context.Local.Where(l => l.Id == id).ExecuteDelete() > 0;
        }

        public List<Local> ListarLocais()
        {
            return _context.Local.ToList();
        }
    }
}
