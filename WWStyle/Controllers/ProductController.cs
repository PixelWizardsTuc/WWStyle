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
                .Include(p => p.Comments) 
                .FirstOrDefault(p => p.ProductId == id);

            if (productWithComments == null)
            {
                return NotFound();
            }

            return View(productWithComments);
        }


        public bool ValidateUserId(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            using (var context = new AspnetWwstyleContext())
            {
                return context.AspNetUsers.Any(u => u.Id == userId);
            }
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> AddComment(int productId, string text)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(); 
            }

            var user = await _context.AspNetUsers.FindAsync(userId);
            if (user == null)
            {
                return Unauthorized(); 
            }

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
