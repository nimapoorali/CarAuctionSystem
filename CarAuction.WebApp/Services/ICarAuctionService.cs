using CarAuction.WebApp.Models.ViewModels;
using System.Data;

namespace CarAuction.WebApp.Services
{
    public interface ICarAuctionService
    {
        Task<BidViewModel?> GetBidAsync(string carType, double carPrice);
    }
}
