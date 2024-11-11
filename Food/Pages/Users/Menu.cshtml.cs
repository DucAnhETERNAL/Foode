using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food.Repositories;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Food.Pages.Users
{
    public class MenuModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public MenuModel(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Product> Products { get; set; } = new List<Product>();
        public int CategoryCount => Categories.Count;
        public int ProductCount => Products.Count;
        public int SelectedCategoryId { get; set; }

        public async Task OnGetAsync()
        {
            await LoadCategoriesAsync();
            await LoadAllProductsAsync();
        }

        public async Task<IActionResult> OnGetShowAllProductsAsync()
        {
            SelectedCategoryId = 0;
            await LoadAllProductsAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetFilterByCategoryAsync(int categoryId)
        {
            SelectedCategoryId = categoryId;
            await LoadProductsByCategoryAsync(categoryId);
            return Page();
        }

        private async Task LoadCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategories();
            Categories = categories.ToList();
        }

        private async Task LoadAllProductsAsync()
        {
            var products = await _productRepository.GetAllProducts();
            Products = products.ToList();
        }

        private async Task LoadProductsByCategoryAsync(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategory(categoryId);
            Products = products.ToList();
        }
    }
}
