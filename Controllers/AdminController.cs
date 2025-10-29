using Microsoft.AspNetCore.Mvc;

namespace PesqueFaleCSharp.Controllers
{
    // [Area("Admin")] // Não vou usar Area, vou usar Roteamento para simplificar
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
