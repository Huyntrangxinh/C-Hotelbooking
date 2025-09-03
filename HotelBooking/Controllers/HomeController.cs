using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelBooking.Controllers
{
    public class HomeController : Controller
    {
        // Thêm các dịch vụ cần thiết
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        // Cập nhật constructor để nhận các dịch vụ
        public HomeController(
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext db)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        // Cập nhật action Index để thêm logic kiểm tra
        public async Task<IActionResult> Index()
        {
            // Mặc định là false
            ViewBag.UserHasProperties = false;

            // Nếu người dùng đã đăng nhập, kiểm tra xem họ có property nào không
            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                if (await _db.Properties.AnyAsync(p => p.UserId == userId))
                {
                    ViewBag.UserHasProperties = true;
                }
            }
            return View();
        }

        // Giữ nguyên action Privacy của bạn
        public IActionResult Privacy()
        {
            return View();
        }

        // Giữ nguyên action Error của bạn
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}