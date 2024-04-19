using CarAuction.Domain.SharedKernel;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Aggregates.Bids
{
    public record SpecialFee : Fee
    {
        private SpecialFee(decimal amount) : base(DataDictionary.SpecialFee, amount) { }

        public static SpecialFee Create(decimal amount)
        {
            return new SpecialFee(amount);
        }

    }
}
