using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PesqueFaleCSharp.Models;

namespace PesqueFaleCSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Exibe a view Index (Views/Home/Index.cshtml)
        public IActionResult Index()
        {
            return View();
        }

        // Exibe a view Home (Views/Home/Home.cshtml)
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Pesquisar()
        {
            return View();
        }

        public IActionResult MelhoresLocais()
        {
            return View();
        }

        public IActionResult Notificacao()
        {
            return View("~/Views/Usuario/Notificacao.cshtml");
        }

        public IActionResult Sobrenos()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return RedirectToAction("Login", "Usuario");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
