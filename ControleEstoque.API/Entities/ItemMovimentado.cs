using System.ComponentModel.DataAnnotations.Schema;

namespace ControleEstoque.API.Entities
{
    public class ItemMovimentado
    {
        public int Id { get; set; }
        public int MovimentacaoId { get; set; }
        [NotMapped]
        public Movimentacao? Movimentacao { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public string Unidade { get; set; } = string.Empty;
        public bool ProdutoQuimico { get; set; }
        public string? Tipo{ get; set; }
    }
}
