using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WWStyle.Data;
using WWStyle.Models;
using Microsoft.EntityFrameworkCore;

namespace WWStyle.Controllers
{
    public class ProductController : Controller
    {
        private readonly AspnetWwstyleContext _context;

        public ProductController(AspnetWwstyleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          List<Product> products = _context.Products.ToList();
            return View(products);

        }

        public IActionResult Details(int id)
        {
            Product product = _context.Products.Include(p => p.ProductName).FirstOrDefault(i => i.ProductId == id);
            return View(product);
        }

        // Andra action-metoder för att hantera skapande, redigering och borttagning av produkter
        // Exempelvis:
        // public IActionResult Create()
        // public IActionResult Edit(int id)
        // public IActionResult Delete(int id)
        // public IActionResult Save(Product product)
    }
}
