using WWStyle.Data;

namespace WWStyle.Services
{
    public class ShoppingCartService
    {
        private readonly ShoppingCartRepository _cartRepository;

        public ShoppingCartService(ShoppingCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void AddToCart(Product product, int quantity)
        {
            _cartRepository.AddToCart(product);
        }

        public int GetCartItemCount()
        {
            return _cartRepository.GetCartItemCount();
        }
    }
}
