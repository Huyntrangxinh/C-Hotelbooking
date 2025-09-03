using System;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class EditProfileVM
    {
        [Display(Name = "Họ tên")]
        public string? FullName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
    }

    public class ChangePasswordVM
    {
        [Required, DataType(DataType.Password), Display(Name = "Mật khẩu hiện tại")]
        public string OldPassword { get; set; } = "";

        [Required, DataType(DataType.Password), Display(Name = "Mật khẩu mới")]
        [MinLength(6)]
        public string NewPassword { get; set; } = "";

        [Required, DataType(DataType.Password), Display(Name = "Xác nhận mật khẩu mới")]
        [Compare(nameof(NewPassword), ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; } = "";
    }
}
