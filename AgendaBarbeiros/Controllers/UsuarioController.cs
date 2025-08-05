using AgendaBarbeiros.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaBarbeiros.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);

            if (usuario.Senha != usuario.ConfirmacaoSenha)
            {
                ModelState.AddModelError("ConfirmacaoSenha", "As senhas não coincidem.");
                return View(usuario);
            }

            usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.Senha = null;
            usuario.ConfirmacaoSenha = null;

            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar usuário: {ex.Message}");
                ModelState.AddModelError("", "Erro ao salvar o usuário, tente novamente.");
                return View(usuario);
            }

            TempData["Mensagem"] = "Usuário cadastrado com sucesso!";
            return RedirectToAction("Index", "Home");
        }

    }
}
