using AgendaBarbeiros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BCrypt.Net;


namespace AgendaBarbeiros.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                ViewBag.Erro = "Usuário ou senha inválidos.";
                return View();
            }

            HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
            HttpContext.Session.SetString("UsuarioNome", usuario.Nome);

            return RedirectToAction("Dashboard", "Home");
        }





    }
}
