using AgendaBarbeiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using BCrypt.Net;


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
            if (usuario.Senha != usuario.ConfirmacaoSenha)
            {
                ModelState.AddModelError("ConfirmacaoSenha", "As senhas não coincidem.");
                return View(usuario);
            }

            // Verifica se já existe um usuário com o mesmo email
            var existe = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
            if (existe != null)
            {
                ModelState.AddModelError("Email", "Já existe um usuário com este e-mail.");
                return View(usuario);
            }

            // Criptografar a senha
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.ConfirmacaoSenha = null; // não precisa salvar no banco

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


    }
}
