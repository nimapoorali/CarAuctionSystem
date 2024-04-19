using CarAuction.Domain.SeedWork;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.SharedKernel.Rules
{
    public class FeeAmountMustBePositiveRule : IBusinessRule
    {
        public decimal Amount { get; }
        public string Message => Messages.FeeAmountMustBePositive;

        public FeeAmountMustBePositiveRule(decimal amount)
        {
            Amount = amount;
        }

        public bool IsBroken()
        {
            return Amount < 0;
        }
    }
}
