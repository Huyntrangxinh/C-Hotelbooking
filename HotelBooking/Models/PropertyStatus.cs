namespace HotelBooking.Models
{
    public enum PropertyStatus
    {
        Draft,      // 0: Bản nháp
        Submitted,  // 1: Đã nộp (Chờ duyệt)
        UnderReview, // 2: Đang được xem xét (Staff đã click xem)
        Approved,   // 3: Đã duyệt
        Rejected    // 4: Bị từ chối
    }
}