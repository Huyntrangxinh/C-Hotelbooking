using HotelBooking.Models;

namespace HotelBooking.ViewModels
{
    public class PropertyDetailsViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; } = string.Empty;
        public string? LocalName { get; set; }
        public PropertyType Type { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public string? PropertyPhoneNumber { get; set; }
        public string? PicFirstName { get; set; }
        public string? PicLastName { get; set; }
        public string? PicEmail { get; set; }
        public string? PicPosition { get; set; }
        public PaymentMethodType? PaymentMethod { get; set; }
        public string? BankName { get; set; }
        public string? BankBranch { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankAccountHolderName { get; set; }
        public bool? AllowPaymentAtHotel { get; set; }
        public string? LegalEntityName { get; set; }
        public string? LegalEntityAddress { get; set; }
        public string? BusinessLicensePath { get; set; }
        public string? TaxPayerName { get; set; }
        public string? TaxPayerAddress { get; set; }
        public string? SignatoryName { get; set; }
        public string? SignatoryIdCardPath { get; set; }
    }
}