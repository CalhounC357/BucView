using BucView.Models;

namespace BucView.Infrastructure
{
    public interface ITourRepository
    {
        Task<ICollection<Tour>> ReadTours();
        Task<Tour?> GetTour(int tourId);
        Task<ICollection<Tour>> GetListOfTours();
        Task<ICollection<TourLocation>> GetTourLocations(int tourId);
        Task<TourLocation> GetTourLocation(int tourId, int rank);
        Task<TourLocation?> GetNextTourLocation(int tourId, int rank);
        Task<ICollection<Location>> ReadLocations();
        Task<Location?> GetLocation(int locationId);
        Task<ICollection<LocationImage>> GetImages(int locationId);
        Task<ICollection<Location>> ReadLocationByTags(Models.Type typeOne, Models.Type typeTwo);
    }
}
