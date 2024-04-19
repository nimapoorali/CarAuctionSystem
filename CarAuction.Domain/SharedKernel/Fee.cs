using CarAuction.Domain.Aggregates.Cars.Rules;
using CarAuction.Domain.SeedWork;
using CarAuction.Domain.SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.SharedKernel
{
    public record Fee : ValueObject
    {
        public decimal Amount { get; init; }
        public string Title { get; init; }

        protected Fee(string tile, decimal amount)
        {
            Amount = amount;
            Title = tile;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Title;
            yield return Amount;
        }

        public static Fee Create(string title, decimal amount)
        {
            CheckRule(new FeeTitleMustBeSpecifiedRule(title));
            CheckRule(new FeeAmountMustBePositiveRule(amount));

            return new Fee(title, amount);

        }
    }
}
