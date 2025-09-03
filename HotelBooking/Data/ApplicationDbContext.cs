using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Models; // ApplicationUser, PartnerAccount, Property

namespace HotelBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<PartnerAccount> PartnerAccounts => Set<PartnerAccount>();

        // 👉 THÊM DÒNG NÀY
        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<PropertyData> PropertyData => Set<PropertyData>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // PartnerAccount: mỗi user chỉ có 1
            builder.Entity<PartnerAccount>()
                   .HasIndex(p => p.UserId)
                   .IsUnique();

            builder.Entity<PartnerAccount>()
                   .HasOne(p => p.User)
                   .WithOne() // không cần navigation ngược
                   .HasForeignKey<PartnerAccount>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // 👉 THÊM MAPPING CHO Property
            builder.Entity<Property>()
                   .HasOne(p => p.User)
                   .WithMany() // chưa cần navigation ngược
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
