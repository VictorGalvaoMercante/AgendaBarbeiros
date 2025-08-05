using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaBarbeiros.Models;
public class Usuario
{
    [Key]
    public int UsuarioId { get; set; }

    [Required(ErrorMessage = "Nome obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Email obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Senha obrigatória")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Confirmação de senha obrigatória")]
    [DataType(DataType.Password)]
    [Compare("Senha", ErrorMessage = "As senhas não coincidem")]
    public string ConfirmacaoSenha { get; set; }

    public string? SenhaHash { get; set; }  // sem [Required]

}
