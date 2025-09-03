using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels.Rooms
{
    public class RoomCreateViewModel
    {
        public int PropertyId { get; set; }
        public int RoomId { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn loại phòng")] 
        public string RoomType { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập tên phòng")] 
        public string RoomName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Vui lòng nhập kích cỡ")] 
        [Range(1, int.MaxValue, ErrorMessage = "Kích cỡ phải lớn hơn 0")] 
        public int? SizeNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn đơn vị")] 
        public string SizeUnit { get; set; } = "m2";
        public bool SmokingAllowed { get; set; } = true;
        [Required(ErrorMessage = "Vui lòng nhập quỹ phòng")] 
        [Range(1, int.MaxValue, ErrorMessage = "Quỹ phòng phải >= 1")] 
        public int Quantity { get; set; }
        public bool IsSingleBedroom { get; set; } = true;
        [MinLength(1, ErrorMessage = "Vui lòng thêm ít nhất 1 loại giường")] 
        public List<BedItem> Beds { get; set; } = new();
        [MinLength(1, ErrorMessage = "Vui lòng chọn ít nhất 1 tiện nghi")] 
        public List<string> SelectedAmenities { get; set; } = new();
        [Required(ErrorMessage = "Vui lòng nhập sức chứa người lớn")] 
        [Range(1, int.MaxValue, ErrorMessage = "Sức chứa người lớn phải >= 1")] 
        public int CapacityAdults { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Sức chứa trẻ em không hợp lệ")] 
        public int CapacityChildren { get; set; }
        public bool AllowChildren { get; set; } = false;
        public bool AllowExtraBed { get; set; } = false;
        [Required(ErrorMessage = "Vui lòng nhập mức bảo hộ")] 
        [Range(0, double.MaxValue, ErrorMessage = "Mức bảo hộ không hợp lệ")] 
        public decimal? SecurityDeposit { get; set; }
        public IFormFile[]? RoomPhotos { get; set; }
        public List<string> SavedPhotoUrls { get; set; } = new();

        public List<string> RoomTypes { get; set; } = new()
        {
            "Phòng Deluxe",
            "Phòng Đôi",
            "Phòng Executive",
            "Phòng Junior Suite",
            "Phòng Đơn",
            "Phòng Tiêu chuẩn",
            "Phòng Studio",
            "Phòng Suite",
            "Phòng Superior",
            "Phòng Ba",
            "Phòng Twin"
        };
        public List<string> BedTypes { get; set; } = new() { "Giường đơn", "Giường đôi", "Giường Twin", "Giường Queen", "Giường King" };
        public Dictionary<string, string[]> AmenityGroups { get; set; } = new()
        {
            ["Tiện nghi tích hợp"] = new[] { "Ban công sân thượng", "Phòng thông nhau", "Hồ bơi riêng" },
            ["Tiện nghi phòng"]      = new[] { "Điều hòa không khí", "Bàn làm việc", "Lò vi sóng", "Đồ ủi", "Tivi",
                                              "Mini bar", "Máy sấy tóc", "Wifi", "Máy giặt", "Nhà tắm chung",
                                              "Tủ lạnh", "Máy pha cà phê/trà" },
            ["Phòng tắm"]            = new[] { "Đồ dùng vệ sinh", "Áo choàng tắm", "Bồn tắm", "Vòi sen", "Nhà tắm riêng", "Nước nóng" },
        };
    }

    public class BedItem { [Required] public string Type { get; set; } = string.Empty; [Range(1, int.MaxValue)] public int Count { get; set; } }
}


