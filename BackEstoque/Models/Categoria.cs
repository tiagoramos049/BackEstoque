namespace BackEstoque.Models
{
    public class Categoria
    {
        public Categoria()
        {
            CategoriaId = Guid.NewGuid();
        }

        public Guid CategoriaId { get; set; }
        public string? Descricao { get; set; }
    }
}
