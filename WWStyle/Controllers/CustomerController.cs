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
            // Hämta en lista med användare från din databas
            var users = _context.AspNetUsers.ToList();

            return View(users);
        }

        public IActionResult Detail(string id)
        {
            // Hämta en specifik användare från databasen baserat på ID
            var user = _context.AspNetUsers.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
    }
}
