using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SistemaEstoque.Context;
using SistemaEstoque.Models;

namespace SistemaEstoque.Controllers
{
    public class LoginController : Controller
    {
        private readonly PerfilsContext _context;

        public LoginController(PerfilsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            var usuarioBanco = _context.Usuarios
                .FirstOrDefault(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);
            
            if (usuarioBanco == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("NomeUsuario", usuarioBanco.Nome);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid) 
            { 
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return RedirectToAction(nameof(Login));
            }
            return View();
        }
    }
}
