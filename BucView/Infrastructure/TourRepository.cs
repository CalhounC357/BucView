using BucView.Models;
using Microsoft.EntityFrameworkCore;

namespace BucView.Infrastructure
{
    public class TourRepository : ITourRepository
    {
        private readonly BucViewContext db;
        public TourRepository(BucViewContext dbContext)
        {
            db = dbContext;
        }
        public async Task<ICollection<LocationImage>> GetImages(int locationId)
        {
            return await db.LocationImage.Where(i => i.LocationId == locationId).ToListAsync();
        }

        public async Task<Location?> GetLocation(int locationId)
        {
            return await db.Location.FirstOrDefaultAsync(l => l.Id == locationId);
        }

        public async Task<Tour?> GetTour(int tourId)
        {
            return await db.Tour.FirstOrDefaultAsync(t => t.Id == tourId);
        }

        public async Task<ICollection<TourLocation>> GetTourLocations(int tourId)
        {
            return await db.TourLocation.Where(tl => tl.TourId == tourId).ToListAsync();
        }

        public async Task<ICollection<Location>> ReadLocations()
        {
            return await db.Location.Include(l => l.Images).ToListAsync();
        }

        public async Task<ICollection<Tour>> ReadTours()
        {
            return await db.Tour.Include(t => t.Locations).ToListAsync();
        }
    }
}
