using CarAuction.Application.Features.Bids.Queries;
using CarAuction.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarAuction.Api.Controllers
{
    [Route("api/v1/carauction/[Controller]")]
    public class BidsController : BaseController
    {
        /// <summary>
        /// Injects mediator object
        /// </summary>
        /// <param name="mediator"></param>
        public BidsController(IMediator mediator, ILogger<BidsController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Calculates and return the bid based on car type and price
        /// </summary>
        /// <param name="carType"></param>
        /// <param name="carPrice"></param>
        /// <returns></returns>
        [HttpGet]
        //public async Task<IActionResult> Get([FromQuery] string? carType, [FromQuery] decimal? carPrice)
        public async Task<IActionResult> Get([FromQuery] CalculateBidQuery command)
        {

#if DEBUG
            //Tracing in debug mode
            Logger.LogTrace("Bid calculation requested.");
#endif


            //if (carType is null || carPrice is null)
            //{
            //    return BadResult(Messages.InvalidInputData);
            //}

            if (!ModelState.IsValid)
            {
                return BadResult(ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray());
            }

            //var command = new CalculateBidQuery()
            //{
            //    CarType = carType,
            //    CarPrice = carPrice
            //};

            var result = await Mediator.Send(command);

            return Result(result);
        }
    }
}
