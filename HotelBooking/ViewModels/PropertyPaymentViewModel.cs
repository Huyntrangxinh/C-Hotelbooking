using HotelBooking.Models;
using System.ComponentModel.DataAnnotations;

// Namespace phải là HotelBooking.ViewModels
namespace HotelBooking.ViewModels 
{
    public class PropertyPaymentViewModel
    {
        [Required]
        public int PropertyId { get; set; }

        [Display(Name = "Phương thức nhận thanh toán")]
        [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán.")]
        public PaymentMethodType PaymentMethod { get; set; }

        [Display(Name = "Tên ngân hàng")]
        public string? BankName { get; set; }

        [Display(Name = "Chi nhánh ngân hàng")]
        public string? BankBranch { get; set; }

        [Display(Name = "Số tài khoản")]
        public string? BankAccountNumber { get; set; }

        [Display(Name = "Tên chủ tài khoản")]
        public string? BankAccountHolderName { get; set; }

        [Display(Name = "Bạn có muốn nhận thanh toán tại khách sạn không?")]
        [Required(ErrorMessage = "Vui lòng chọn.")]
        public bool AllowPaymentAtHotel { get; set; }
    }
}