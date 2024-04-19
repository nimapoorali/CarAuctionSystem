using CarAuction.Domain.Aggregates.Bids;
using CarAuction.Domain.SharedKernel;
using Mapster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Application.Features.Bids.Queries.ViewModels
{
    public class FeeViewModelMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config
                .NewConfig<HashSet<Fee>, FeeViewModel[]>()
                .Map(dest => dest, src => src.Select(f => new { Title = f.Title, Amount = f.Amount }).ToArray());
        }
    }
}
