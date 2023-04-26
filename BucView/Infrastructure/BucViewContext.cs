using BucView.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BucView.Infrastructure
{
    public class BucViewContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public BucViewContext(DbContextOptions<BucViewContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Tour> Tour => Set<Tour>();
        public DbSet<Location> Location => Set<Location>();
        public DbSet<TourLocation> TourLocation => Set<TourLocation>();
        public DbSet<TourLocationInterestPoint> TourLocationInterestPoint => Set<TourLocationInterestPoint>();
        public DbSet<LocationImage> LocationImage => Set<LocationImage>();
        public DbSet<LocationType> LocationType => Set<LocationType>();
    }
}
