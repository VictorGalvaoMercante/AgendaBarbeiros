namespace AgendaBarbeiros.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Categoria { get; set; }
        public DateTime Horario { get; set; }
        public double Preco { get; set; }
        public string Observacao { get; set; }
    }
}
