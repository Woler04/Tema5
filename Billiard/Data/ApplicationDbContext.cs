using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Billiard.Data;

namespace Billiard.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Billiard.Data.ReservationList> ReservationList { get; set; }
        public DbSet<Billiard.Data.Reservation> Reservation { get; set; }
        public DbSet<Billiard.Data.BilliardTable> BilliardTable { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ReservationList>().HasMany(rl => rl.Reservations).
                WithOne(rli => rli.ReservationList).
                OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>().HasOne(t => t.BilliardTable);

            base.OnModelCreating(builder);
        }
    }
}