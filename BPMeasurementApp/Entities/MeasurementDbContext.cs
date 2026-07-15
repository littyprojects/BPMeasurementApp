using Microsoft.EntityFrameworkCore;

namespace BPMeasurementApp.Entities
{
    public class MeasurementDbContext : DbContext
    {
        public MeasurementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                    new Position() { PositionId = "st", Name = "Standing"},
                    new Position() { PositionId = "si", Name = "Sitting" },
                    new Position() { PositionId = "ld", Name = "Lying down" }
                );

            modelBuilder.Entity<Measurement>().HasData(
                    new Measurement()
                    {
                        MeasurementId = 1,
                        Systolic = 181,
                        Diastolic = 121,
                        PositionId = "st",
                        DateTaken = new DateOnly(2008, 2, 7)
                    },
                    new Measurement()
                    {
                        MeasurementId = 2,
                        Systolic = 142,
                        Diastolic = 91,
                        PositionId = "ld",
                        DateTaken = new DateOnly(2005, 12, 29)
                    },
                    new Measurement()
                    {
                        MeasurementId = 3,
                        Systolic = 131,
                        Diastolic = 85,
                        PositionId = "st",
                        DateTaken = new DateOnly(2002, 11, 24)
                    },
                    new Measurement()
                    {
                        MeasurementId = 4,
                        Systolic = 122,
                        Diastolic = 79,
                        PositionId = "si",
                        DateTaken = new DateOnly(1998, 5, 8)
                    },
                    new Measurement()
                    {
                        MeasurementId = 5,
                        Systolic = 118,
                        Diastolic = 78,
                        PositionId = "si",
                        DateTaken = new DateOnly(1996, 2, 9)
                    }
                );
        }
    }
}
