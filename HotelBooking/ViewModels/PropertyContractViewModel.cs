using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Cần cho IFormFile

namespace HotelBooking.ViewModels
{
    public class PropertyContractViewModel
    {
        [Required]
        public int PropertyId { get; set; }

        // Thông tin pháp nhân
        [Display(Name = "Tên pháp nhân hoặc tên cá nhân")]
        [Required(ErrorMessage = "Vui lòng nhập Tên pháp nhân.")]
        public string LegalEntityName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ của pháp nhân hoặc cá nhân")]
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ pháp nhân.")]
        public string LegalEntityAddress { get; set; } = string.Empty;

        [Display(Name = "Giấy phép kinh doanh (Tùy chọn)")]
        public IFormFile? BusinessLicenseFile { get; set; }
        public string? ExistingBusinessLicensePath { get; set; }

        // Thông tin thuế
        [Display(Name = "Họ tên đầy đủ của người nộp thuế")]
        [Required(ErrorMessage = "Vui lòng nhập Tên người nộp thuế.")]
        public string TaxPayerName { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ người nộp thuế")]
        [Required(ErrorMessage = "Vui lòng nhập Địa chỉ người nộp thuế.")]
        public string TaxPayerAddress { get; set; } = string.Empty;

        // Thông tin người ký
        [Display(Name = "Ai sẽ ký hợp đồng?")]
        public bool IsSignatoryDirector { get; set; } = true;

        [Display(Name = "Họ tên đầy đủ")]
        [Required(ErrorMessage = "Vui lòng nhập Họ tên người ký.")]
        public string SignatoryName { get; set; } = string.Empty;

        [Display(Name = "Vị trí")]
        [Required(ErrorMessage = "Vui lòng nhập Vị trí người ký.")]
        public string SignatoryPosition { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Vui lòng nhập Số điện thoại.")]
        [Phone(ErrorMessage = "Định dạng số điện thoại không hợp lệ.")]
        public string SignatoryPhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Vui lòng nhập Email.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        public string SignatoryEmail { get; set; } = string.Empty;

        [Display(Name = "Thẻ CCCD của chủ sở hữu cơ sở lưu trú")]
        public IFormFile? SignatoryIdCardFile { get; set; }
        public string? ExistingSignatoryIdCardPath { get; set; }
    }
}