using Microsoft.AspNetCore.Mvc;
using SistemaEstoque.Context;
using SistemaEstoque.Models;

namespace SistemaEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly EstoqueContext _context;

        public ProdutoController(EstoqueContext context)
        {
            _context = context;
        }
        public IActionResult ListaProduto()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }
    }
}
