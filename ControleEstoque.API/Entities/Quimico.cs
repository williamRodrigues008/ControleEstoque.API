namespace ControleEstoque.API.Entities
{
    public class Quimico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public bool Concentrado { get; set; }
    }
}
