using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWStyle.Models.ViewModels;

namespace WWStyle.Controllers
{
    public class AdminCustomerController : Controller
    {
        private readonly AspnetWwstyleContext dbContext;

        public AdminCustomerController(AspnetWwstyleContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerViewModel addCustomerViewModel)
        {
            var customer = new Customer
            {
                FirstName = addCustomerViewModel.FirstName,
                LastName = addCustomerViewModel.LastName,
                Address1 = addCustomerViewModel.Address1,
                Address2 = addCustomerViewModel.Address2,
                City = addCustomerViewModel.City,
                State = addCustomerViewModel.State,
                ZipCode = addCustomerViewModel.ZipCode,
                Country = addCustomerViewModel.Country,
                Phone = addCustomerViewModel.Phone,
                Email = addCustomerViewModel.Email,
            };

            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "AdminCustomer");
        }

        //Stämma av med Karin angående att ändra till int för customer id
       
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var customers = await dbContext.Customers.ToListAsync();

            return View(customers);
        }


        public async Task<IActionResult> Edit(int id, Customer viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = await dbContext.Customers.FindAsync(id);
                if (customer == null)
                {
                    ModelState.AddModelError("", "Product not found.");
                    return View(viewModel);
                }

                if (viewModel != null)
                {
                    // Update the product with the values from viewModel
                    customer.FirstName = viewModel.FirstName;
                    customer.LastName = viewModel.LastName;
                    customer.Address1 = viewModel.Address1;
                    customer.Address2 = viewModel.Address2;
                    customer.City = viewModel.City;
                    customer.State = viewModel.State;
                    customer.ZipCode = viewModel.ZipCode;
                    customer.Country = viewModel.Country;
                    customer.Phone = viewModel.Phone;
                    customer.Email = viewModel.Email;

                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("List", "AdminCustomer");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid product data.");
                }
            }

            // Fetch the product data from the database and pass it to the view
            var existingCustomer = await dbContext.Products.FindAsync(id);
            if (existingCustomer == null)
            {
                ModelState.AddModelError("", "Product not found.");
                return NotFound();
            }

            return View(existingCustomer);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Customer viewModel)
        {
            var customer = await dbContext.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if(customer is not null)
            {
                dbContext.Customers.Remove(customer);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "AdminCustomer");
        }
    }
}
