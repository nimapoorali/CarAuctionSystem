using CarAuction.Domain.SharedKernel;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Aggregates.Bids
{
    public record BasicFee : Fee
    {
        private BasicFee(decimal amount) : base(DataDictionary.BasicFee, amount) { }

        public static BasicFee Create(decimal amount)
        {
            return new BasicFee(amount);
        }

    }
}
