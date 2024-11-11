using Food.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Food.Pages.Users
{
    public class DefaultModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public IEnumerable<Product> Products { get; set; }

        public DefaultModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task OnGet()
        {
            // Fetch all products from the database
            Products = await _productRepository.GetAllProducts();
        }
    }
}
