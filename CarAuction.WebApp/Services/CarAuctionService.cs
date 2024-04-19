using CarAuction.WebApp.Models.ViewModels;

namespace CarAuction.WebApp.Services
{
    public class CarAuctionService : ICarAuctionService
    {
        public ApiCallService ApiCallService { get; }
        public IConfiguration Configuration { get; }

        public CarAuctionService(ApiCallService apiCallService, IConfiguration configuration)
        {
            ApiCallService = apiCallService;
            Configuration = configuration;
        }

        public async Task<BidViewModel?> GetBidAsync(string carType, double carPrice)
        {
            return await ApiCallService.GetAsync<BidViewModel>(Configuration["ApiSetting:BidCalculateUrl"] + $"?CarPrice={carPrice}&CarType={carType}");
        }
    }
}
