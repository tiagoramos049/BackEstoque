using BackEstoque.Models;

namespace BackEstoque.Repository
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();  
        Categoria GetById(Guid id);        
        void Add(Categoria categoria);       
        void Update(Categoria categoria);    
        void Delete(Guid id);
    }
}
