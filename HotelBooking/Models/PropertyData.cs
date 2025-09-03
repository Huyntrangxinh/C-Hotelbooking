using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models
{
    public class PropertyData
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }

        // Check-in/Check-out Information
        public bool IsReception24Hours { get; set; }
        public TimeSpan CheckInTime { get; set; } = new TimeSpan(14, 0, 0); // Default 14:00
        public TimeSpan CheckOutTime { get; set; } = new TimeSpan(12, 0, 0); // Default 12:00

        // Photos
        public string? ExteriorPhotoPath { get; set; }
        public string? InteriorPhotoPath { get; set; }
        public string? RoomPhotoPath { get; set; }
        public string? PhotoPaths { get; set; } // Multiple photos separated by |
        public string? PhotoCategoriesJson { get; set; } // JSON string for photo categories

        // Amenities
        public bool HasSmokingArea { get; set; }
        public bool HasAccessibleBathroom { get; set; }
        public bool HasElevator { get; set; }
        public bool HasPublicWifi { get; set; }
        public bool HasAccessibleParking { get; set; }
        public bool HasParkingArea { get; set; }
        public bool HasCafe { get; set; }
        public bool HasRestaurant { get; set; }
        public bool HasBar { get; set; }
        public bool HasFrontDesk { get; set; }
        public bool HasExpressCheckIn { get; set; }
        public bool HasConcierge { get; set; }
        public bool HasExpressCheckOut { get; set; }
        public bool HasLaundryService { get; set; }
        public bool Has24HourSecurity { get; set; }
        public bool HasLuggageStorage { get; set; }
        public bool HasAirportTransfer { get; set; }

        // Star Rating
        public int? StarRating { get; set; } // 1-5 stars, null if no rating

        // Room Information
        public string? RoomDescription { get; set; }
        public int? NumberOfRooms { get; set; }
        public string? RoomTypes { get; set; } // JSON string for room types

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
