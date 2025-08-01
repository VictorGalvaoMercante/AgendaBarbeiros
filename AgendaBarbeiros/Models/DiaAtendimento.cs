namespace AgendaBarbeiros.Models
{
    public class DiaAtendimento
    {
        public int DiaAtendimentoId { get; set; }
        public DateTime DiaDoAtendimento { get; set; }
        
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
