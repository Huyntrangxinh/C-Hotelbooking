using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class PartnerStartViewModel
    {
        [Required, EmailAddress, Display(Name = "Địa chỉ email")]
        public string Email { get; set; } = string.Empty;
    }

    public class PartnerContactViewModel
    {
        [Display(Name = "Tên"), Required, MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Họ"), Required, MaxLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Mã quốc gia"), Required]
        public string CountryCode { get; set; } = "+84";

        [Display(Name = "Số điện thoại"), Required, Phone]
        public string Phone { get; set; } = string.Empty;
    }
}
