using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Leilao GetLeilaoById(int id)
        {
            return _context.Leiloes.Find(id);
        }

        public void CreateLeilao(Leilao model)
        {
            _context.Leiloes.Add(model);
            _context.SaveChanges();
        }

        public void UpdateLeilao(Leilao model)
        {
            _context.Leiloes.Update(model);
            _context.SaveChanges();
        }
        public void DeleteLeilao(Leilao model)
        {
            _context.Leiloes.Remove(model);
            _context.SaveChanges();
        }
    }
}
