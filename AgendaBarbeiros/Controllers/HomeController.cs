 using System.Diagnostics;
using AgendaBarbeiros.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaBarbeiros.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

        

      
    }
}
