using BackEstoque.Contexto;
using BackEstoque.Models;

namespace BackEstoque.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Context _context;

        public CategoriaRepository(Context context)
        {



            _context = context;
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public Categoria GetById(Guid id)
        {
            return _context.Categorias.FirstOrDefault(p => p.CategoriaId == id)!;
        }

        public void Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var categoria = GetById(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();
            }
        }
    }
}
