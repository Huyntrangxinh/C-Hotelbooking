using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    // Loại chỗ nghỉ (có thể mở rộng sau)
    public enum PropertyType
    {
        Hotel = 0,
        Apartment = 1,
        Homestay = 2,
        Villa = 3,
        Hostel = 4,
        GuestHouse = 5,
        Resort = 6
    }

    public class Property
    {
        public int Id { get; set; }

        // Chủ sở hữu (đối tác) – chính là user hiện hành
        [Required]
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        // Bước 1: loại + địa chỉ cơ bản
        [Required]
        public PropertyType Type { get; set; }

        [Required, MaxLength(2)]              // ISO-2, ví dụ: VN, US…
        public string CountryCode { get; set; } = "VN";

        [Required, MaxLength(120)]
        public string City { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string AddressLine { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        // Trạng thái khởi tạo (đang làm hồ sơ)
        public bool IsDraft { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // ...
        [MaxLength(150), Required]
        public string Name { get; set; } = string.Empty;         // Tên cơ sở

        [MaxLength(150)]
        public string? LocalName { get; set; }                   // Tên theo ngôn ngữ địa phương (nếu khác)
                                                                 // ...

    // === BẮT ĐẦU CODE MỚI ===

        // Thông tin liên lạc của cơ sở
        [MaxLength(5)]
        public string? PropertyPhoneCountryCode { get; set; } // Ví dụ: +84

        [MaxLength(20)]
        public string? PropertyPhoneNumber { get; set; }

        // Thông tin người phụ trách (Person in Charge - PIC)
        [MaxLength(100)]
        public string? PicFirstName { get; set; }

        [MaxLength(100)]
        public string? PicLastName { get; set; }

        [MaxLength(150)]
        public string? PicEmail { get; set; }

        [MaxLength(100)]
        public string? PicPosition { get; set; } // Vị trí (ví dụ: Front Office Attendant)

        [MaxLength(5)]
        public string? PicPhoneCountryCode { get; set; }

        [MaxLength(20)]
        public string? PicPhoneNumber { get; set; }

        // === KẾT THÚC CODE MỚI ===

        // === BẮT ĐẦU CODE MỚI CHO THANH TOÁN ===

public PaymentMethodType? PaymentMethod { get; set; }

[MaxLength(150)]
public string? BankName { get; set; }

[MaxLength(150)]
public string? BankBranch { get; set; }

[MaxLength(50)]
public string? BankAccountNumber { get; set; }

[MaxLength(150)]
public string? BankAccountHolderName { get; set; }

public bool? AllowPaymentAtHotel { get; set; }

// === KẾT THÚC CODE MỚI CHO THANH TOÁN ===

// === BẮT ĐẦU CODE MỚI CHO HỢP ĐỒNG ===

// Thông tin pháp nhân
[MaxLength(200)]
public string? LegalEntityName { get; set; }
[MaxLength(300)]
public string? LegalEntityAddress { get; set; }
// Lưu đường dẫn đến file giấy phép kinh doanh
[MaxLength(500)]
public string? BusinessLicensePath { get; set; }

// Thông tin thuế
[MaxLength(200)]
public string? TaxPayerName { get; set; }
[MaxLength(300)]
public string? TaxPayerAddress { get; set; }

// Thông tin người ký
public bool IsSignatoryDirector { get; set; } = true; // true = Giám đốc, false = Người ủy quyền
[MaxLength(200)]
public string? SignatoryName { get; set; }
[MaxLength(100)]
public string? SignatoryPosition { get; set; }
[MaxLength(20)]
public string? SignatoryPhoneNumber { get; set; }
[MaxLength(150)]
public string? SignatoryEmail { get; set; }
// Lưu đường dẫn đến file CCCD
[MaxLength(500)]
public string? SignatoryIdCardPath { get; set; }

// === KẾT THÚC CODE MỚI CHO HỢP ĐỒNG ===
// THÊM DÒNG NÀY VÀO CUỐI CLASS
    public PropertyStatus Status { get; set; } = PropertyStatus.Draft;
    
    // Lý do từ chối (nếu có)
    [MaxLength(500)]
    public string? RejectionReason { get; set; }
    
    }
}
