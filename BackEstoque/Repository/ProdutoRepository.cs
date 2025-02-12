using BackEstoque.Contexto;
using BackEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEstoque.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Context _context;

        public ProdutoRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<Produto> GetAll()
        {
            var produtos = _context.Produtos
                .Include(p => p.Categoria) 
                .ToList();
            return produtos;
        }

        public Produto GetById(Guid id)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == id)!;
        }

        public void Add(Produto produto)
        {
            var categoriaExistente = _context.Categorias.FirstOrDefault(c => c.CategoriaId == produto.Categoria!.CategoriaId);

            if (categoriaExistente != null)
            {
                produto.Categoria = categoriaExistente;
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _context.Produtos.Update(produto);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var produto = GetById(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }
        }
    }
}
