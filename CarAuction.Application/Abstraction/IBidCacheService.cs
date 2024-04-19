using CarAuction.Application.Features.Bids.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Application.Abstraction
{
    public interface IBidCacheService
    {
        BidViewModel GetBid(string? carType, decimal? carPrice);
        void SetBid(BidViewModel? model);
    }
}
