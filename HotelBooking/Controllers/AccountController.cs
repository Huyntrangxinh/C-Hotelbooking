using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _users;
        private readonly SignInManager<ApplicationUser> _signInManager;

        // Đổi tên biến _signIn thành _signInManager cho rõ nghĩa
        public AccountController(UserManager<ApplicationUser> users, SignInManager<ApplicationUser> signInManager)
        {
            _users = users;
            _signInManager = signInManager;
        }

        // GET: /account/register
        [HttpGet]
        public IActionResult Register()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            // Giữ nguyên logic kiểm tra email đã tồn tại của bạn
            var existed = await _users.FindByEmailAsync(model.Email);
            if (existed != null)
            {
                ModelState.AddModelError(nameof(model.Email),
                    "Địa chỉ email này đã được đăng ký trên hệ thống. Vui lòng dùng email khác hoặc đăng nhập.");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _users.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // === BẮT ĐẦU CODE MỚI: GÁN VAI TRÒ ===
                if (user.Email != null && user.Email.EndsWith("@staff.com", StringComparison.OrdinalIgnoreCase))
                {
                    await _users.AddToRoleAsync(user, "Staff");
                }
                else
                {
                    await _users.AddToRoleAsync(user, "Partner");
                }
                // === KẾT THÚC CODE MỚI ===

                // Giữ nguyên logic chuyển hướng về trang Login của bạn
                TempData["success"] = "Tạo tài khoản thành công. Vui lòng đăng nhập để tiếp tục.";
                return RedirectToAction("Login");
            }

            // Giữ nguyên logic xử lý lỗi của bạn
            foreach (var e in result.Errors)
            {
                if (e.Code.Contains("Duplicate", StringComparison.OrdinalIgnoreCase) ||
                    e.Description.Contains("email", StringComparison.OrdinalIgnoreCase))
                {
                    ModelState.AddModelError(nameof(model.Email),
                        "Địa chỉ email này đã được đăng ký trên hệ thống. Vui lòng dùng email khác hoặc đăng nhập.");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, e.Description);
                }
            }

            return View(model);
        }

        // GET: /account/login
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /account/login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Staff có thể sử dụng các tính năng booking bình thường
                // Chỉ chuyển hướng đến Admin Dashboard nếu có returnUrl cụ thể
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                
                // Mặc định chuyển về trang chủ cho tất cả user
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Email hoặc mật khẩu không đúng.");
            return View(model);
        }

        // POST: /account/logout
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() => View();
    }
}