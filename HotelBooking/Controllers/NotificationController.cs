using HotelBooking.Data;
using HotelBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NotificationController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /Notification/GetNotifications
        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new { success = false, message = "Không tìm thấy user" });

            var notifications = await _db.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .Take(20)
                .ToListAsync();

            var unreadCount = await _db.Notifications
                .CountAsync(n => n.UserId == userId && !n.IsRead);

            // Nếu không có thông báo thật, tạo thông báo test
            if (!notifications.Any())
            {
                var testNotifications = new List<object>
                {
                    new {
                        id = 999,
                        type = "PropertyApproved",
                        title = "Cơ sở lưu trú được phê duyệt",
                        message = "Cơ sở lưu trú 'Khách sạn ABC' của bạn đã được phê duyệt thành công!",
                        isRead = false,
                        createdAt = DateTime.Now.AddHours(-2).ToString("dd/MM/yyyy HH:mm"),
                        propertyId = 1,
                        propertyName = "Khách sạn ABC",
                        rejectionReason = (string)null
                    },
                    new {
                        id = 998,
                        type = "PropertySubmitted",
                        title = "Cơ sở lưu trú đã được gửi để duyệt",
                        message = "Cơ sở lưu trú 'Homestay XYZ' của bạn đã được gửi để duyệt.",
                        isRead = true,
                        createdAt = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy HH:mm"),
                        propertyId = 2,
                        propertyName = "Homestay XYZ",
                        rejectionReason = (string)null
                    }
                };

                return Json(new 
                { 
                    success = true, 
                    notifications = testNotifications,
                    unreadCount = 1
                });
            }

            return Json(new 
            { 
                success = true, 
                notifications = notifications.Select(n => new
                {
                    id = n.Id,
                    type = n.Type.ToString(),
                    title = n.Title,
                    message = n.Message,
                    isRead = n.IsRead,
                    createdAt = n.CreatedAt.ToString("dd/MM/yyyy HH:mm"),
                    propertyId = n.PropertyId,
                    propertyName = n.PropertyName,
                    rejectionReason = n.RejectionReason
                }),
                unreadCount = unreadCount
            });
        }

        // POST: /Notification/MarkAsRead
        [HttpPost]
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new { success = false, message = "Không tìm thấy user" });

            var notification = await _db.Notifications
                .FirstOrDefaultAsync(n => n.Id == notificationId && n.UserId == userId);

            if (notification == null)
                return Json(new { success = false, message = "Không tìm thấy thông báo" });

            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();

            return Json(new { success = true });
        }

        // POST: /Notification/MarkAllAsRead
        [HttpPost]
        public async Task<IActionResult> MarkAllAsRead()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new { success = false, message = "Không tìm thấy user" });

            var notifications = await _db.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .ToListAsync();

            foreach (var notification in notifications)
            {
                notification.IsRead = true;
                notification.ReadAt = DateTime.UtcNow;
            }

            await _db.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
