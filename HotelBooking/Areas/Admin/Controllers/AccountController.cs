using HotelBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Admin/Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            // Nếu đã đăng nhập với vai trò Staff, chuyển thẳng vào Dashboard
            if (User.Identity.IsAuthenticated && User.IsInRole("Staff"))
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        // POST: /Admin/Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Đăng xuất người dùng hiện tại (nếu có) để tránh xung đột
            await _signInManager.SignOutAsync();

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                // KIỂM TRA QUAN TRỌNG: Chỉ cho phép người dùng có vai trò "Staff"
                if (user != null && await _userManager.IsInRoleAsync(user, "Staff"))
                {
                    // Đăng nhập thành công, chuyển đến trang Dashboard của Admin
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                else
                {
                    // Nếu không phải Staff, đăng xuất ngay và báo lỗi
                    await _signInManager.SignOutAsync();
                    ModelState.AddModelError(string.Empty, "Tài khoản này không có quyền truy cập khu vực quản trị.");
                    return View(model);
                }
            }

            ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
            return View(model);
        }

        // POST: /Admin/Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login)); // Quay lại trang đăng nhập của Admin
        }

        // GET: /Admin/Account/AccessDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}