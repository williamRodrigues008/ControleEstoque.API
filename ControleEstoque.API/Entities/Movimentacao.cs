namespace ControleEstoque.API.Entities
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Local {  get; set; } = string.Empty;
        public DateTime DataMovimentacao { get; set; }
        public List<ItemMovimentado> ItensMovimentados { get; set; } = new();
        public string Solicitante { get; set; } = string.Empty;
        public string Responsavel { get; set; } = string.Empty;
    }
}
