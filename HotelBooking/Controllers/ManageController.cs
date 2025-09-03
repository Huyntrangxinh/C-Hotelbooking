using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userMgr;
        private readonly SignInManager<ApplicationUser> _signInMgr;

        public ManageController(UserManager<ApplicationUser> userMgr,
                                SignInManager<ApplicationUser> signInMgr)
        {
            _userMgr = userMgr;
            _signInMgr = signInMgr;
        }

        // GET /manage
        public async Task<IActionResult> Index()
        {
            var user = await _userMgr.GetUserAsync(User);
            return View(user);
        }

        // GET /manage/edit
        public async Task<IActionResult> Edit()
        {
            var user = await _userMgr.GetUserAsync(User);
            var vm = new EditProfileVM
            {
                FullName = user!.FullName,
                DateOfBirth = user.DateOfBirth
            };
            return View(vm);
        }

        // POST /manage/edit
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfileVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userMgr.GetUserAsync(User);
            user!.FullName = vm.FullName;
            user.DateOfBirth = vm.DateOfBirth;
            await _userMgr.UpdateAsync(user);

            TempData["success"] = "Cập nhật hồ sơ thành công!";
            return RedirectToAction(nameof(Index));
        }

        // GET /manage/change-password
        public IActionResult ChangePassword() => View();

        // POST /manage/change-password
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userMgr.GetUserAsync(User);
            var result = await _userMgr.ChangePasswordAsync(user!, vm.OldPassword, vm.NewPassword);

            if (result.Succeeded)
            {
                await _signInMgr.RefreshSignInAsync(user!);
                TempData["success"] = "Đổi mật khẩu thành công!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var e in result.Errors)
                ModelState.AddModelError(string.Empty, e.Description);

            return View(vm);
        }
    }
}
