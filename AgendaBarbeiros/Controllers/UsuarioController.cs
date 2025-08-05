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
     

        // POST: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não encontrado. Cadastre-se para continuar.");
                return View("~/Views/Home/Index.cshtml"); // especifica o caminho absoluto da view
            }

            if (!BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
            {
                ModelState.AddModelError(string.Empty, "Senha incorreta.");
                return View("~/Views/Home/Index.cshtml");
            }

            // Login bem sucedido
            return RedirectToAction("Index", "Clientes");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // limpa tudo
            return RedirectToAction("Login");
        }

    }
}
