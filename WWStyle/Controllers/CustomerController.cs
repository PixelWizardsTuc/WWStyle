using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WWStyle.Data;
using WWStyle.Models;
using Microsoft.EntityFrameworkCore;

namespace WWStyle.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AspnetWwstyleContext _context;

        public CustomerController(AspnetWwstyleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.AspNetUsers.ToList();

            return View(users);
        }

        public IActionResult Detail(string id)
        {
            var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult ConfirmDelete(string id)
        {
            var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.AspNetUsers.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
