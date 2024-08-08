using QMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace QMS.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options) : base(options) 
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    PersonalId = "1234567891234" ,
                    FirstName = "Test",
                    LastName = "System",
                    PhoneNumber = "0123456789",
                    Password = "azxcvbnm"
                }
                );
        }
    }
}
