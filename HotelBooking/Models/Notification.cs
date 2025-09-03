using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public enum NotificationType
    {
        PropertyApproved,    // Cơ sở lưu trú được phê duyệt
        PropertyRejected,    // Cơ sở lưu trú bị từ chối
        PropertySubmitted,   // Cơ sở lưu trú đã được gửi để duyệt
        SystemMessage        // Thông báo hệ thống
    }

    public class Notification
    {
        public int Id { get; set; }
        
        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        
        [Required]
        public NotificationType Type { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required, MaxLength(1000)]
        public string Message { get; set; } = string.Empty;
        
        public bool IsRead { get; set; } = false;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? ReadAt { get; set; }
        
        // Thông tin bổ sung cho thông báo từ chối
        public int? PropertyId { get; set; }
        public string? PropertyName { get; set; }
        public string? RejectionReason { get; set; }
    }
}

