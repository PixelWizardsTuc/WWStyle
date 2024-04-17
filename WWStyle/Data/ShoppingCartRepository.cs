namespace WWStyle.Data
{
    public class ShoppingCartRepository
    {
        private readonly AspnetWwstyleContext _context;

        public ShoppingCartRepository(AspnetWwstyleContext context)
        {
            _context = context;
        }

        public void AddToCart(Product product)
        {
            var cartItem = new ShoppingCart
            {
                ProductId = product.ProductId,
                Quantity = 1 
            };
            _context.ShoppingCarts.Add(cartItem);
            _context.SaveChanges();
        }

        public int GetCartItemCount()
        {
            return _context.ShoppingCarts.Sum(item => item.Quantity);
        }
    }
}
