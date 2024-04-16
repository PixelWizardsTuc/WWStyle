using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WWStyle.Data;
using WWStyle.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WWStyle.Controllers
{
    public class ProductController : Controller
    {
        private readonly AspnetWwstyleContext _context;
        private readonly ApplicationDbContext _appContext;


        public ProductController(AspnetWwstyleContext context, ApplicationDbContext appContext)
        {
            _context = context;
            _appContext = appContext;
        }

        public IActionResult Index()
        {
          List<Product> products = _context.Products.ToList();
            return View(products);

        }

        //public IActionResult Details(int id)
        //{
        //    Product product = _context.Products.Include(p => p.ProductName).FirstOrDefault(i => i.ProductId == id);
        //    return View(product);
        //}

		//public async Task<IActionResult> ProductDetail(int? id, string alertstyle = "success")
		//{
		//	ViewData["alertstyle"] = alertstyle;

		//	if (!id.HasValue)
		//	{
		//		return BadRequest("You must pass a product ID in the route, " +
		//			"for example, /Home/ProductDetail/13");
		//	}
		//	Product? model = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);
		//	if (model is null)
		//	{
		//		return NotFound($"ProductId {id} not found.");
		//	}
		//	return View(model);
		//}

        public IActionResult Detail(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        //private AspNetUser GetUserById(string userId)
        //{
        //    // Hämta användaren från _appContext-databasen
        //    var user = _appContext.Users.FirstOrDefault(u => u.Id == userId);

        //    return user;
        //}

        [HttpPost]
        public IActionResult AddComment(int productId, string userName, string commentText)
        {
            // Hämta produkten från databasen
            var product = _context.Products.Include(p => p.Comments).FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                // Skapa en ny kommentar
                var comment = new Comment
                {
                    UserId = userName,
                    Text = commentText,
                    CreateDate = DateTime.Now
                };

                // Lägg till kommentaren till produktens kommentarer
                product.Comments.Add(comment);

                // Spara ändringarna till databasen
                _appContext.SaveChanges();
                _context.SaveChanges();

                // Omdirigera tillbaka till produktsidan
                return RedirectToAction("Detail", new { id = productId });
            }

            return NotFound();
        }

        // Andra action-metoder för att hantera skapande, redigering och borttagning av produkter
        // Exempelvis:
        // public IActionResult Create()
        // public IActionResult Edit(int id)
        // public IActionResult Delete(int id)
        // public IActionResult Save(Product product)
    }
}
