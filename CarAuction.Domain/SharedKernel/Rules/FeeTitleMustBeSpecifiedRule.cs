using CarAuction.Domain.SeedWork;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.SharedKernel.Rules
{
    public class FeeTitleMustBeSpecifiedRule : IBusinessRule
    {
        public string Title { get; }
        public string Message => Messages.FeeTitleMustBeSpecified;

        public FeeTitleMustBeSpecifiedRule(string title)
        {
            Title = title;
        }

        public bool IsBroken()
        {
            return string.IsNullOrWhiteSpace(Title);
        }
    }
}
