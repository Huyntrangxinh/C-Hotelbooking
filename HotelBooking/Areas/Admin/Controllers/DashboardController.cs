using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Staff")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /Admin/Dashboard
        // Hiển thị danh sách các cơ sở đang chờ duyệt
        public async Task<IActionResult> Index()
        {
            var submittedProperties = await _db.Properties
                .Where(p => p.Status == PropertyStatus.Submitted || p.Status == PropertyStatus.UnderReview)
                .Include(p => p.User) // Lấy thông tin người dùng liên quan
                .ToListAsync();
            return View(submittedProperties);
        }

        // GET: /Admin/Dashboard/Details/{id}
        // Hiển thị chi tiết một cơ sở để duyệt
        public async Task<IActionResult> Details(int id)
        {
            var property = await _db.Properties
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            // Cập nhật trạng thái thành UnderReview khi Staff xem chi tiết
            if (property.Status == PropertyStatus.Submitted)
            {
                property.Status = PropertyStatus.UnderReview;
                await _db.SaveChangesAsync();
            }

            // Chuyển đổi (map) dữ liệu từ model `Property` sang `PropertyDetailsViewModel`
            var viewModel = new PropertyDetailsViewModel
            {
                PropertyId = property.Id,
                PropertyName = property.Name,
                LocalName = property.LocalName,
                Type = property.Type,
                Address = $"{property.AddressLine}, {property.City}, {property.CountryCode}",
                PostalCode = property.PostalCode,
                PropertyPhoneNumber = property.PropertyPhoneNumber,
                PicFirstName = property.PicFirstName,
                PicLastName = property.PicLastName,
                PicEmail = property.PicEmail,
                PicPosition = property.PicPosition,
                PaymentMethod = property.PaymentMethod,
                BankName = property.BankName,
                BankBranch = property.BankBranch,
                BankAccountNumber = property.BankAccountNumber,
                BankAccountHolderName = property.BankAccountHolderName,
                AllowPaymentAtHotel = property.AllowPaymentAtHotel,
                LegalEntityName = property.LegalEntityName,
                LegalEntityAddress = property.LegalEntityAddress,
                BusinessLicensePath = property.BusinessLicensePath,
                TaxPayerName = property.TaxPayerName,
                TaxPayerAddress = property.TaxPayerAddress,
                SignatoryName = property.SignatoryName,
                SignatoryIdCardPath = property.SignatoryIdCardPath
            };

            return View(viewModel);
        }

        // POST: /Admin/Dashboard/Approve
        // Action để duyệt hợp đồng
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int propertyId)
        {
            var property = await _db.Properties
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == propertyId);
                
            if (property != null)
            {
                property.Status = PropertyStatus.Approved;
                await _db.SaveChangesAsync();
                
                // Tạo thông báo cho người dùng
                var notification = new Notification
                {
                    UserId = property.UserId,
                    Type = NotificationType.PropertyApproved,
                    Title = "Cơ sở lưu trú được phê duyệt",
                    Message = $"Cơ sở lưu trú '{property.Name}' của bạn đã được phê duyệt thành công!",
                    PropertyId = property.Id,
                    PropertyName = property.Name
                };
                
                _db.Notifications.Add(notification);
                await _db.SaveChangesAsync();
                
                TempData["success"] = $"Đã duyệt thành công cơ sở '{property.Name}'.";
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: /Admin/Dashboard/RejectWithReason/{id}
        // Hiển thị form nhập lý do từ chối
        [HttpGet]
        public async Task<IActionResult> RejectWithReason(int id)
        {
            var property = await _db.Properties
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            var viewModel = new RejectPropertyViewModel
            {
                PropertyId = property.Id,
                PropertyName = property.Name
            };

            return View(viewModel);
        }

        // POST: /Admin/Dashboard/RejectWithReason
        // Xử lý từ chối với lý do
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectWithReason(RejectPropertyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var property = await _db.Properties
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == model.PropertyId);

            if (property == null)
            {
                return NotFound();
            }

            // Cập nhật trạng thái và lý do từ chối
            property.Status = PropertyStatus.Rejected;
            property.RejectionReason = model.RejectionReason.Trim();
            property.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            // Tạo thông báo cho người dùng với lý do từ chối
            var notification = new Notification
            {
                UserId = property.UserId,
                Type = NotificationType.PropertyRejected,
                Title = "Cơ sở lưu trú bị từ chối",
                Message = $"Cơ sở lưu trú '{property.Name}' của bạn đã bị từ chối. Lý do: {model.RejectionReason}",
                PropertyId = property.Id,
                PropertyName = property.Name,
                RejectionReason = model.RejectionReason.Trim()
            };
            
            _db.Notifications.Add(notification);
            await _db.SaveChangesAsync();

            TempData["success"] = $"Đã từ chối cơ sở '{property.Name}' với lý do: {model.RejectionReason}";

            return RedirectToAction(nameof(Index));
        }
    }
}