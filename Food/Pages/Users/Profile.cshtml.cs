using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food.Repositories;
using Models;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Food.Pages.Users
{
    public class ProfileModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public ProfileModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User UserProfile { get; set; }
        public List<Order> OrderHistory { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy userId từ Claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Lấy thông tin người dùng
            UserProfile = await _userRepository.GetUserById(int.Parse(userId));

            // Lấy thông tin đơn hàng của người dùng
            if (UserProfile != null)
            {
                OrderHistory = UserProfile.Orders.ToList();
                 
                // Lấy danh sách các đơn hàng của người dùng
            }
            else
            {
                return RedirectToPage("/Users/Login"); // Nếu không tìm thấy người dùng, chuyển hướng về trang đăng nhập
            }

            return Page();
        }

    }
}
