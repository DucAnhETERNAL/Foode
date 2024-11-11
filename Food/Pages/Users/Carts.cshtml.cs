using Microsoft.AspNetCore.Mvc;
using Food.Repositories;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Food.Pages.Users
{
    [Authorize]
    public class CartModel : PageModel
    {
        
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public CartModel(ICartRepository cartRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public List<Cart> Carts { get; set; }
        public decimal TotalPrice { get; set; }
        public User UserProfile { get; set; }
        [BindProperty]
        public int ProductId { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Carts = await _cartRepository.GetCartByUserIdAsync(int.Parse(userId));
            TotalPrice = Carts.Sum(c => c.Product.Price * c.Quantity);
            UserProfile = await _userRepository.GetUserById(int.Parse(userId));

            return Page();
        }

        // Action to update the quantity in the cart
        public async Task<IActionResult> OnPostUpdateQuantityAsync(int productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cartItem = await _cartRepository.GetCartItemAsync(int.Parse(userId), productId);

            if (cartItem != null && quantity > 0)
            {
                cartItem.Quantity = quantity;
                await _cartRepository.Update(cartItem);
            }

            // Recalculate total price
            Carts = await _cartRepository.GetCartByUserIdAsync(int.Parse(userId));
            TotalPrice = Carts.Sum(c => c.Product.Price * c.Quantity);

            return RedirectToPage();  // Reload the page to reflect the updated cart
        }

        // Action to delete an item from the cart
        public async Task<IActionResult> OnPostDeleteItemAsync(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Get the cart item for the user and product
            var cartItem = await _cartRepository.GetCartItemAsync(int.Parse(userId), productId);

            if (cartItem != null)
            {
                await _cartRepository.Delete(cartItem.CartId); // Delete the cart item from the database
            }

            // Recalculate total price
            Carts = await _cartRepository.GetCartByUserIdAsync(int.Parse(userId));
            TotalPrice = Carts.Sum(c => c.Product.Price * c.Quantity);

            return RedirectToPage();  // Reload the page to reflect the updated cart
        }
    }
}
