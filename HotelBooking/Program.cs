using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HotelBooking.Models;
using HotelBooking.Data;
using QuestPDF.Infrastructure; // Dòng này đã đúng vị trí

namespace HotelBooking
{
    public class Program
    {
        public static async Task  Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // === THÊM DÒNG NÀY ĐỂ KHAI BÁO LICENSE ===
            QuestPDF.Settings.License = LicenseType.Community;
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Kết nối SQLite từ appsettings.json
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Đăng kí ASP.NET Core Identity
            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole>(opt =>
                {
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireDigit = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Cấu hình đường dẫn đăng nhập/không có quyền
            builder.Services.ConfigureApplicationCookie(o =>
            {
                o.LoginPath = "/account/login";
                o.AccessDeniedPath = "/account/access-denied";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            

            app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



// ...
using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}
            app.Run();
        }
    }
}