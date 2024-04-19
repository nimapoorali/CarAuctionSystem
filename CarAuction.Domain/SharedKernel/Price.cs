using CarAuction.Domain.Aggregates.Cars.Rules;
using CarAuction.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.SharedKernel
{
    public record Price : ValueObject
    {
        public decimal Value { get; init; }

        private Price(decimal value)
        {
            Value = value;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }

        public static Price Create(decimal value)
        {
            CheckRule(new PriceMustBeGreaterThanZeroRule(value));

            return new Price(value);

        }
    }
}
