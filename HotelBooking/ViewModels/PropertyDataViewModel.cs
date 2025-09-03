using System.ComponentModel.DataAnnotations;

namespace HotelBooking.ViewModels
{
    public class PropertyDataViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;

        // Check-in/Check-out Information
        [Display(Name = "Lễ tân của bạn có mở cửa 24 giờ không?")]
        public bool IsReception24Hours { get; set; }

        [Display(Name = "Giờ nhận phòng")]
        [DataType(DataType.Time)]
        public TimeSpan CheckInTime { get; set; } = new TimeSpan(14, 0, 0);

        [Display(Name = "Giờ trả phòng")]
        [DataType(DataType.Time)]
        public TimeSpan CheckOutTime { get; set; } = new TimeSpan(12, 0, 0);

        // Photos
        [Display(Name = "Ảnh cơ sở lưu trú")]
        public List<IFormFile>? PropertyPhotos { get; set; }

        [Display(Name = "Danh mục ảnh")]
        public string? PhotoCategoriesJson { get; set; }
        
        public List<string>? PhotoCategories 
        { 
            get 
            {
                if (string.IsNullOrEmpty(PhotoCategoriesJson))
                    return null;
                try
                {
                    return System.Text.Json.JsonSerializer.Deserialize<List<string>>(PhotoCategoriesJson);
                }
                catch
                {
                    return null;
                }
            }
        }

        // Saved photo URLs to rehydrate gallery on revisit
        public List<string> SavedPhotoUrls { get; set; } = new List<string>();

        // Manifest ảnh gửi từ client: mô tả thứ tự + category + phân biệt ảnh cũ/mới
        // Mẫu phần tử: { url?: string, newIndex?: number, category: string, order: number }
        public string? PhotoManifestJson { get; set; }

        // Danh sách URL ảnh cũ đã xóa ở client
        public string? DeletedPhotoUrlsJson { get; set; }

        // Rooms list (for rooms tab)
        public List<RoomItemVm> Rooms { get; set; } = new List<RoomItemVm>();

        // Amenities - Common Areas
        [Display(Name = "Khu vực hút thuốc")]
        public bool HasSmokingArea { get; set; }

        [Display(Name = "Phòng tắm cho người khuyết tật")]
        public bool HasAccessibleBathroom { get; set; }

        [Display(Name = "Thang máy")]
        public bool HasElevator { get; set; }

        [Display(Name = "WiFi công cộng")]
        public bool HasPublicWifi { get; set; }

        [Display(Name = "Bãi đỗ xe cho người khuyết tật")]
        public bool HasAccessibleParking { get; set; }

        [Display(Name = "Bãi đỗ xe")]
        public bool HasParkingArea { get; set; }

        // Amenities - Food and Beverages
        [Display(Name = "Quán cà phê")]
        public bool HasCafe { get; set; }

        [Display(Name = "Nhà hàng")]
        public bool HasRestaurant { get; set; }

        [Display(Name = "Quán bar")]
        public bool HasBar { get; set; }

        // Amenities - Service Facilities
        [Display(Name = "Quầy lễ tân")]
        public bool HasFrontDesk { get; set; }

        [Display(Name = "Nhận phòng nhanh")]
        public bool HasExpressCheckIn { get; set; }

        [Display(Name = "Concierge")]
        public bool HasConcierge { get; set; }

        [Display(Name = "Trả phòng nhanh")]
        public bool HasExpressCheckOut { get; set; }

        [Display(Name = "Dịch vụ giặt ủi")]
        public bool HasLaundryService { get; set; }

        [Display(Name = "Bảo vệ 24 giờ")]
        public bool Has24HourSecurity { get; set; }

        [Display(Name = "Ký gửi hành lý")]
        public bool HasLuggageStorage { get; set; }

        [Display(Name = "Đưa đón sân bay")]
        public bool HasAirportTransfer { get; set; }

        // Star Rating
        [Display(Name = "Đánh giá sao")]
        public int? StarRating { get; set; }

        // Room Information
        [Display(Name = "Mô tả phòng")]
        [StringLength(1000)]
        public string? RoomDescription { get; set; }

        [Display(Name = "Số lượng phòng")]
        [Range(1, 1000)]
        public int? NumberOfRooms { get; set; }

        // Navigation
        public string CurrentTab { get; set; } = "property"; // property, rooms, pricing
    }
}

public class RoomItemVm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int MaxGuests { get; set; }
}
