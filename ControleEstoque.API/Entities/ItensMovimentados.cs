namespace ControleEstoque.API.Entities
{
    public class ItensMovimentados
    {
        public int Id { get; set; }
        public int IdMovimentacao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public bool ProdutoQuimico { get; set; }
        public string? Tipo{ get; set; }
    }
}
