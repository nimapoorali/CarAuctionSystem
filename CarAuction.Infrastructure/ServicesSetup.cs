using CarAuction.Application.Abstraction;
using CarAuction.Domain.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Infrastructure
{
    public static class ServicesSetup
    {
        public static void AddCarAuctionInfrastructure(this IServiceCollection services)
        {
            services
                .AddScoped<IBidCalculator, BidCalculator>()
                .AddScoped<ICachingService, CachingService>()
                .AddScoped<IBidCacheService, BidCacheService>()
                ;
        }
    }
}
