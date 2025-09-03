using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public enum PartnerStatus { New = 0, EmailVerified = 1, InProgress = 2, Active = 3 }

    public class PartnerAccount
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        [Required, EmailAddress, Display(Name = "Địa chỉ email liên hệ")]
        public string ContactEmail { get; set; } = string.Empty;

        // ➜ THÊM MỚI
        [MaxLength(100), Display(Name = "Tên")]
        public string? ContactFirstName { get; set; }

        [MaxLength(100), Display(Name = "Họ")]
        public string? ContactLastName { get; set; }

        [MaxLength(6), Display(Name = "Mã quốc gia")]   // ví dụ +84
        public string? PhoneCountryCode { get; set; }

        [Phone, MaxLength(30), Display(Name = "Số điện thoại")]
        public string? PhoneNumber { get; set; }
        // <— HẾT PHẦN THÊM



        public PartnerStatus Status { get; set; } = PartnerStatus.New;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
