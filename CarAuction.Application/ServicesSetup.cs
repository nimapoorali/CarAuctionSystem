using CarAuction.Application.Features.Bids.Queries.Validators;
using CarAuction.Application.Features.Bids.Queries.ViewModels;
using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Application
{
    public static class ServicesSetup
    {
        public static void AddCarAuctionApplication(this IServiceCollection services)
        {
            RegisterApplicationMappings();
            services.RegisterMediatR();
            services.RegisterValidators();
        }

        public static void RegisterApplicationMappings()
        {
            TypeAdapterConfig.GlobalSettings.Scan(typeof(BidViewModelMappingConfig).Assembly);
        }

        private static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(m =>
            {
                m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }

        private static void RegisterValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CalculateBidQueryValidator>();
        }
    }
}
