using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PesqueFaleCSharp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        // GET: /Usuario/Perfil
        public IActionResult Perfil()
        {
            return View();
        }

        // GET: /Usuario/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Usuario/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password, bool rememberMe = false)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "Email e senha são obrigatórios.");
                return View();
            }

            // TODO: validar credenciais com o DbContext / Identity
            _logger.LogInformation("Tentativa de login para {Email}", email);

            // simular login bem sucedido por enquanto
            return RedirectToAction(nameof(Perfil));
        }

        // GET: /Usuario/Registro
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        // POST: /Usuario/Registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(string nome, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "Todos os campos são obrigatórios.");
                return View();
            }

            // TODO: criar usuário no banco usando EF Core (injetar o DbContext aqui)
            _logger.LogInformation("Novo registro: {Email}", email);

            return RedirectToAction(nameof(Perfil));
        }

        // GET: /Usuario/Notificacao
        public IActionResult Notificacao()
        {
            return View();
        }

        // GET: /Usuario/Logout
        public IActionResult Logout()
        {
            // TODO: limpar sessão/cookies/claims quando implementar autenticação
            return RedirectToAction(nameof(Login));
        }
    }
}