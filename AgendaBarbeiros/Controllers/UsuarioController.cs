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

        public IActionResult Register()
        {
            return View();
        }
    }
}
