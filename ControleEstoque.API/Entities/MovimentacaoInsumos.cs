namespace ControleEstoque.API.Entities
{
    public class MovimentacaoInsumos
    {
        public int Id { get; set; }
        public string Local {  get; set; } = string.Empty;
        public DateTime DataMovimentacao { get; set; }
        public ItensMovimentados ItensMovimentados { get; set; } = new();
        public string Solicitante { get; set; } = string.Empty;
        public string Responsavel { get; set; } = string.Empty;
    }
}
