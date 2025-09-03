namespace HotelBooking.ViewModels
{
    // ViewModel này sẽ chứa dữ liệu từ tất cả các bước trước
    public class ReviewViewModel
    {
        public int PropertyId { get; set; }

        // Từ bước 1
        public string PropertyName { get; set; } = string.Empty;
        public string PropertyAddress { get; set; } = string.Empty;

        // Từ bước 2
        public string PaymentMethod { get; set; } = string.Empty;

        // Từ bước 3
        public string? LegalEntityName { get; set; }
        public string? LegalEntityAddress { get; set; }
        public string? SignatoryName { get; set; }
        public string? SignatoryPosition { get; set; }
        public string? SignatoryEmail { get; set; }
        public string? SignatoryPhoneNumber { get; set; }
    }
}