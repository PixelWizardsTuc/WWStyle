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
            // Create a new ShoppingCartItem and add it to the database
            var cartItem = new ShoppingCart
            {
                ProductId = product.ProductId,
                Quantity = 1 // Assuming initial quantity is 1
                             // You may add more properties here if needed
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
