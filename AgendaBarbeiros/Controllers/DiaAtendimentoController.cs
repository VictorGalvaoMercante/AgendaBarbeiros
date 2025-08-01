using AgendaBarbeiros.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaBarbeiros.Controllers
{
    public class DiaAtendimentoController : Controller
    {
        private readonly AppDbContext _context;

        public DiaAtendimentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(DiaAtendimento dia)
        {
            if (ModelState.IsValid)
            {
                // Salvar no banco (adicionar ao contexto e salvar)
                _context.Add(dia);
                _context.SaveChanges();
                // Redirecionar para uma view de listagem ou detalhes
                return RedirectToAction("Details");
            }

            return View(dia);
        }


    }
}
