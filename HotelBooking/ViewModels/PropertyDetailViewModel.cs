using HotelBooking.Models;

namespace HotelBooking.ViewModels
{
    public class PropertyDetailViewModel
    {
        public Property Property { get; set; } = null!;
        public string RegistrationNumber { get; set; } = string.Empty;
        public int CurrentStep { get; set; }
        public int TotalSteps { get; set; }
    }
}
