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

		public async Task<IActionResult> ProductDetail(int? id, string alertstyle = "success")
		{
			ViewData["alertstyle"] = alertstyle;

			if (!id.HasValue)
			{
				return BadRequest("You must pass a product ID in the route, " +
					"for example, /Home/ProductDetail/13");
			}
			Product? model = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);
			if (model is null)
			{
				return NotFound($"ProductId {id} not found.");
			}
			return View(model);
		}

        public IActionResult Detail(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
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
