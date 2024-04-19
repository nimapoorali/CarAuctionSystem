using CarAuction.Domain.SeedWork;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Aggregates.Cars.Rules
{
    public class PriceMustBeGreaterThanZeroRule : IBusinessRule
    {
        public decimal Price { get; }
        public string Message => Messages.PriceMustBeGreaterThanZero;

        public PriceMustBeGreaterThanZeroRule(decimal price)
        {
            Price = price;
        }

        public bool IsBroken()
        {
            return Price <= 0;
        }
    }
}
