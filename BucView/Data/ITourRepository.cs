using BucView.Models;

namespace BucView.Data
{
    public interface ITourRepository
    {
        Task<ICollection<Tour>> ReadTours();
        Task<Tour> GetTour(int tourId);
        Task<ICollection<TourLocation>> GetTourLocations(int tourId);
        Task<ICollection<Location>> ReadLocations();
        Task<Location> GetLocation(int locationId);
        Task<ICollection<LocationImage>> GetImages(int locationId);
    }
}
