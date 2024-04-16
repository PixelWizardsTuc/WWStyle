namespace WWStyle.Data
{
    public class ProductRepository
    {
        private readonly AspnetWwstyleContext _context;

        public ProductRepository(AspnetWwstyleContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
