using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Microsoft.EntityFrameworkCore;
using WWStyle.Models.ViewModels;

namespace WWStyle.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly AspnetWwstyleContext dbContext;

        public AdminProductController(AspnetWwstyleContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductViewModel)
        {
            var product = new Product
            {
                ProductName = addProductViewModel.ProductName,
                Description = addProductViewModel.Description,
                Price = addProductViewModel.Price,
                Stock = addProductViewModel.Stock,

            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "AdminProduct");
        }

       
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await dbContext.Products.ToListAsync();

            return View(products);
        }


        public async Task<IActionResult> Edit(int id, Product viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await dbContext.Products.FindAsync(id);
                if (product == null)
                {
                    ModelState.AddModelError("", "Product not found.");
                    return View(viewModel);
                }

                if (viewModel != null)
                {
                    // Update the product with the values from viewModel
                    product.ProductName = viewModel.ProductName;
                    product.Description = viewModel.Description;
                    product.Price = viewModel.Price;
                    product.Stock = viewModel.Stock;

                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("List", "AdminProduct");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid product data.");
                }
            }

            // Fetch the product data from the database and pass it to the view
            var existingProduct = await dbContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                ModelState.AddModelError("", "Product not found.");
                return NotFound();
            }

            return View(existingProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product viewModel)
        {
            var product = await dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductId == viewModel.ProductId);

            if(product is not null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "AdminProduct");
        }
    }
}