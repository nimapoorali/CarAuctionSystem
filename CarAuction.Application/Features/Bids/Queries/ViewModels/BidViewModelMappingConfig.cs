using CarAuction.Domain.Aggregates.Bids;
using Mapster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Application.Features.Bids.Queries.ViewModels
{
    public class BidViewModelMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<Bid, BidViewModel>()
                .Map(dest => dest.CarType, src => src.Car.Type.Name)
                .Map(dest => dest.CarPrice, src => src.Car.Price.Value)
                .Map(dest => dest.Fees, src => src.Fees);
        }
    }
}
