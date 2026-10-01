using Microsoft.EntityFrameworkCore;
using Travels.Models;

namespace Travels.Data;

public class TravelsContext : DbContext
{
    public TravelsContext(DbContextOptions<TravelsContext> options)
        : base(options) { }

    public DbSet<Trip> Trips => Set<Trip>();
public DbSet<Country> Countries => Set<Country>();

    public DbSet<Transport> Transports => Set<Transport>();
    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Trip>().Property(x => x.TotalCost).HasConversion<double>();

        b.Entity<Trip>()
         .HasIndex(x => new { x.Destination, x.StartDate })
         .IsUnique();

         b.Entity<Trip>()
         .HasOne(x => x.Country)
         .WithMany()
         .HasForeignKey(x => x.CountryId)
         .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Trip>()
         .HasOne(x => x.Transport)
         .WithMany()
         .HasForeignKey(x => x.TransportId)
         .OnDelete(DeleteBehavior.Restrict);
    }
}