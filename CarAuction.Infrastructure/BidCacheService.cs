using CarAuction.Application.Abstraction;
using CarAuction.Application.Features.Bids.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Infrastructure
{
    public class BidCacheService : IBidCacheService
    {
        public ICachingService CachingService { get; }

        public BidCacheService(ICachingService cachingService)
        {
            CachingService = cachingService;
        }

        public BidViewModel? GetBid(string? carType, decimal? carPrice)
        {
            if (carType is null || carPrice is null)
            {
                return null;
            }

            //Just for an example: key: CarType_Price value: BidViewModel
            var key = carType + carPrice.Value.ToString("#.00");
            return CachingService.GetData<BidViewModel>(key);
        }

        public void SetBid(BidViewModel model)
        {
            if (model.CarType is null || model.CarPrice is null)
            {
                return;
            }

            var key = model.CarType + model.CarPrice.Value.ToString("#.00");

#if DEBUG
            var expirationDate = DateTimeOffset.UtcNow.AddMinutes(5);
#endif

#if RELEASE
                    //for example
                    var expirationDate = DateTimeOffset.UtcNow.AdddDays(1);

#endif

            CachingService.SetData(key, model, expirationDate, true);
        }
    }
}
