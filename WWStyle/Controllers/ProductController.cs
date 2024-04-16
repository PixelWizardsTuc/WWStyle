using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WWStyle.Data;
using WWStyle.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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


        public IActionResult Detail(int id)
        {
            var productWithComments = _context.Products
                .Include(p => p.Comments) // Inkludera kommentarerna för produkten
                .FirstOrDefault(p => p.ProductId == id);

            if (productWithComments == null)
            {
                return NotFound();
            }

            return View(productWithComments);
        }


        public bool ValidateUserId(string userId)
        {
            // Check if the user ID is empty or null
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            // Check if the user ID exists in the database
            // Replace `AspNetUser` with your actual user table name
            using (var context = new AspnetWwstyleContext())
            {
                return context.AspNetUsers.Any(u => u.Id == userId);
            }
        }

        [HttpPost]
        [Authorize] // Kräver att användaren är inloggad för att lägga till kommentar
        public async Task<IActionResult> AddComment(int productId, string text)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Hämta användarens ID från ASP.NET Identity
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(); // Användaren är inte inloggad
            }

            // Kontrollera om användaren finns i systemet (validera användar-ID)
            var user = await _context.AspNetUsers.FindAsync(userId);
            if (user == null)
            {
                return Unauthorized(); // Användaren är inte giltig
            }

            // Skapa kommentarobjektet och lägg till i databasen
            var comment = new Comment
            {
                ProductId = productId,
                UserId = userId,
                Text = text,
                CreateDate = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Detail", new { id = productId });
        }
    }
}
