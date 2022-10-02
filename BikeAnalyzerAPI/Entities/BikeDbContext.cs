using Microsoft.EntityFrameworkCore;

namespace BikeAnalyzerAPI.Entities
{
    public class BikeDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=BikeDb;Trusted_Connection=True;";
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .Property(x => x.Name)
                .IsRequired();

            modelBuilder.Entity<Bike>()
                .Property(r => r.Brand)
                .IsRequired()
                .HasMaxLength(20);
            
            modelBuilder.Entity<Bike>()
                .Property(r => r.Model)
                .IsRequired()
                .HasMaxLength(30);
            
            modelBuilder.Entity<Bike>()
                .Property(r => r.YearOfProduction)
                .IsRequired()
                .HasMaxLength(20);
            
            modelBuilder.Entity<Bike>()
                .Property(r => r.HeadTubeAngle)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Bike>()
                .Property(r => r.SeatTubeEffectiveAngle)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Bike>()
                .Property(r => r.TravelFrontWheel)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Bike>()
                .Property(r => r.TravelBackWheel)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Bike>()
                .Property(r => r.InnerRimWidth)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Bike>()
                .Property(r => r.TireWidth)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Bike>()
               .Property(r => r.Weigth)
               .IsRequired()
               .HasMaxLength(20);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
