using CarAuction.Domain.Abstraction;
using CarAuction.Domain.Aggregates.Cars;
using CarAuction.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Aggregates.Bids
{
    public class Bid
    {
        public Car Car { get; init; }
        public IBidCalculator BidCalculator { get; init; }


        private HashSet<Fee>? _fees;
        public HashSet<Fee>? Fees => _fees;

        public decimal? Total => _fees is null ? null : (Fees?.Sum(f => f.Amount) + Car.Price.Value);


        private Bid(Car car, IBidCalculator bidCalculator)
        {
            Car = car;
            BidCalculator = bidCalculator;
        }


        public static Bid Create(Car car, IBidCalculator bidCalculator)
        {
            //Bid business rules check
            //
            //End of bid business rules check

            return new Bid(car, bidCalculator);

        }

        /// <summary>
        /// Calculates the fees and total bid
        /// </summary>
        public void CalulateBid()
        {
            _fees = BidCalculator.CalculateFees(Car);
        }
    }
}
