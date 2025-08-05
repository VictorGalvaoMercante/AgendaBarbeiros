using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaBarbeiros.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }

        [NotMapped]
        public string Senha { get; set; }
        [NotMapped]
        public string ConfirmacaoSenha { get; set; }
    }
}
