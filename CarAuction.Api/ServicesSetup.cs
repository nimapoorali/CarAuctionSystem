using CarAuction.Application;
using CarAuction.Infrastructure;

namespace CarAuction.Api
{
    public static class ServicesSetup
    {
        public static void AddCarAuctionDependencies(this IServiceCollection services)
        {
            //Add infrastructures
            services.AddCarAuctionInfrastructure();

            //Add application layer dependencies
            services.AddCarAuctionApplication();

        }
    }
}
