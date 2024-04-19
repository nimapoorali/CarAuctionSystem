using CarAuction.Application.Abstraction;
using CarAuction.Application.Features.Bids.Queries.ViewModels;
using CarAuction.Domain.Abstraction;
using CarAuction.Domain.Aggregates.Bids;
using CarAuction.Domain.Aggregates.Cars;
using CarAuction.Domain.SeedWork;
using CarAuction.Domain.SharedKernel;
using CarAuction.Resources;
using FluentResults;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Application.Features.Bids.Queries
{
    public class CalculateBidQuery : IRequest<Result<BidViewModel>>
    {
        public decimal? CarPrice { get; set; }
        public string? CarType { get; set; }


        public class CalculateBidQueryHandler : IRequestHandler<CalculateBidQuery, Result<BidViewModel>>
        {
            private readonly IBidCalculator BidCalculator;

            //Since the calculated prices is static based on car type and price, they can be cached for performance improvement
            //And also it can be possible to calculate all the bids for the round prices and cache them once at first.
            //Ofcourse that the variation of the car prices should be reviewed to decide whether the cache is logical in this situation or not. 
            private readonly IBidCacheService BidCacheService;

            public CalculateBidQueryHandler(IBidCalculator bidCalculator, IBidCacheService bidCacheService)
            {
                BidCalculator = bidCalculator;
                BidCacheService = bidCacheService;
            }

            public async Task<Result<BidViewModel>> Handle(CalculateBidQuery request, CancellationToken cancellationToken)
            {
                var result = new Result<BidViewModel>();

                try
                {

                    //Return the bid which was already calculated based on the current car type and price 
                    var cachedBid = BidCacheService.GetBid(request.CarType, request.CarPrice);
                    if (cachedBid is not null)
                    {
                        return cachedBid;
                    }

                    //depends on the transactions rate, locking mechanisms can also be used here
                    var price = Price.Create(request.CarPrice!.Value);
                    var carType = Enumeration.FromName<CarType>(request.CarType!);
                    var car = Car.Create(carType, price);
                    var bid = Bid.Create(car, BidCalculator);
                    bid.CalulateBid();

                    var bidViewModel = bid.Adapt<BidViewModel>();

                    //Set cache
                    BidCacheService.SetBid(bidViewModel);


                    result.WithValue(bidViewModel);
                    result.WithSuccess(Messages.OperationSucceeded);

                    return result;
                }
                catch (BusinessRuleValidationException ex)
                {
                    result.WithError(ex.Message);
                    return result.ToResult();
                }
                catch
                {
#if DEBUG
                    throw;
#endif

#if RELEASE
                    //log internal error
                    throw new Exception(Messages.InternalError);
#endif
                }
            }
        }
    }
}
