using Microsoft.AspNetCore.Identity;
using System;                            // <- nhớ dòng này

namespace HotelBooking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
