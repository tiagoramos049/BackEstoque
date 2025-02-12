namespace BackEstoque.Models
{
    public class Produto
    {
        public Produto()
        {
            ProdutoId = Guid.NewGuid(); 
        }

        public Guid ProdutoId { get; set; }
        public string? Codigo { get; set; }
        public string? UnidadeMedida { get; set; }
        public Categoria? Categoria { get; set; }
        public decimal? CustoMedio { get; set; }
        public decimal? ValorVenda { get; set; }
        public decimal? EstoqueReservados { get; set; }  
        public decimal? EstoqueDisponivel { get; set; }
        public decimal? CustoTotal { get; set; }
        public string? Descricao { get; set; }
        public double? Valor { get; set; }
        public double? Descontos { get; set; }
    }
}
