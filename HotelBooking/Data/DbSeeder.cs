using HotelBooking.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelBooking.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            // Lấy các dịch vụ cần thiết
            var roleManager = service.GetService<RoleManager<IdentityRole>>()!;

            // Tạo vai trò "Staff" nếu nó chưa tồn tại
            if (!await roleManager.RoleExistsAsync("Staff"))
            {
                await roleManager.CreateAsync(new IdentityRole("Staff"));
            }

            // Tạo vai trò "Partner" nếu nó chưa tồn tại
            if (!await roleManager.RoleExistsAsync("Partner"))
            {
                await roleManager.CreateAsync(new IdentityRole("Partner"));
            }
        }
    }
}