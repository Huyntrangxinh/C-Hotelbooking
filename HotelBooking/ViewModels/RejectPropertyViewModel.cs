using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class RejectPropertyViewModel
    {
        public int PropertyId { get; set; }
        
        [Required(ErrorMessage = "Vui lòng nhập lý do từ chối")]
        [StringLength(500, ErrorMessage = "Lý do từ chối không được quá 500 ký tự")]
        [Display(Name = "Lý do từ chối")]
        public string RejectionReason { get; set; } = string.Empty;
        
        public string PropertyName { get; set; } = string.Empty;
    }
}
