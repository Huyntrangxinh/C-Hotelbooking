using HotelBooking.Models;
using System.ComponentModel.DataAnnotations;

public class PropertyStep1ViewModel
{
    public int? PropertyId { get; set; }

    // NEW: Tên cơ sở
    [Display(Name = "Tên cơ sở lưu trú"), Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    // NEW: Tên địa phương (option)
    [Display(Name = "Tên cơ sở lưu trú bằng Ngôn ngữ địa phương"), MaxLength(150)]
    public string? LocalName { get; set; }

    [Display(Name = "Cơ sở lưu trú này không có tên khác trong ngôn ngữ địa phương của tôi")]
    public bool NoLocalDifferent { get; set; } = true;

    [Display(Name = "Loại chỗ nghỉ"), Required]
    public PropertyType Type { get; set; } = PropertyType.Hotel;

    [Display(Name = "Quốc gia"), Required, MaxLength(2)]
    public string CountryCode { get; set; } = "VN";

    [Display(Name = "Thành phố / Tỉnh"), Required, MaxLength(120)]
    public string City { get; set; } = string.Empty;

    [Display(Name = "Địa chỉ"), Required, MaxLength(200)]
    public string AddressLine { get; set; } = string.Empty;

    [Display(Name = "Mã bưu chính"), MaxLength(20)]
    public string? PostalCode { get; set; }

      // === BẮT ĐẦU CODE MỚI ===

    [Display(Name = "Mã quốc gia")]
    public string PropertyPhoneCountryCode { get; set; } = "+84";

    [Display(Name = "Số điện thoại"), Required(ErrorMessage = "Vui lòng nhập số điện thoại cơ sở."), MaxLength(20)]
    public string PropertyPhoneNumber { get; set; } = string.Empty;

    // --- Người phụ trách ---
    [Display(Name = "Tên"), Required(ErrorMessage = "Vui lòng nhập tên."), MaxLength(100)]
    public string PicFirstName { get; set; } = string.Empty;

    [Display(Name = "Họ"), Required(ErrorMessage = "Vui lòng nhập họ."), MaxLength(100)]
    public string PicLastName { get; set; } = string.Empty;

    [Display(Name = "Email"), Required(ErrorMessage = "Vui lòng nhập email."), EmailAddress, MaxLength(150)]
    public string PicEmail { get; set; } = string.Empty;

    [Display(Name = "Vị trí"), Required(ErrorMessage = "Vui lòng chọn vị trí.")]
    public string PicPosition { get; set; } = string.Empty;

    [Display(Name = "Mã quốc gia")]
    public string PicPhoneCountryCode { get; set; } = "+84";

    [Display(Name = "Số điện thoại"), Required(ErrorMessage = "Vui lòng nhập số điện thoại người phụ trách."), MaxLength(20)]
    public string PicPhoneNumber { get; set; } = string.Empty;

    // === KẾT THÚC CODE MỚI ===
}
