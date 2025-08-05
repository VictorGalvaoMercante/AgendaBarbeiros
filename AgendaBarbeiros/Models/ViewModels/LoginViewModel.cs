using System.ComponentModel.DataAnnotations;

namespace AgendaBarbeiros.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
