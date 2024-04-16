using Microsoft.AspNetCore.Mvc;
using WWStyle.Services;

namespace WWStyle.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ProductService _productService;
        private readonly ShoppingCartService _shoppingCartService;

        public ShoppingCartController(ProductService productService, ShoppingCartService shoppingCartService)
        {
            _productService = productService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            int cartItemCount = _shoppingCartService.GetCartItemCount();

            ViewBag.CartItemCount = cartItemCount;

            var products = _productService.GetAllProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                _shoppingCartService.AddToCart(product, quantity);
            }
            return RedirectToAction("Index", "Product");
        }
    }
}
