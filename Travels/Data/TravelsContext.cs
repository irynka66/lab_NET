using Microsoft.EntityFrameworkCore;
using Travels.Models;

namespace Travels.Data;

public class TravelsContext : DbContext
{
    public TravelsContext(DbContextOptions<TravelsContext> options)
        : base(options) { }

    public DbSet<Trip> Trips => Set<Trip>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Trip>().Property(x => x.TotalCost).HasConversion<double>();
    }
}