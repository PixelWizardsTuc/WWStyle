

using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace WWStyle.Models
{
    public record HomeIndexViewModel
        (
            IList<Product> Products,
            IList<Customer> Customers,
            IList<AspNetUser> AspNetUsers,
            IList<Comment> Comments
        );
    
}
