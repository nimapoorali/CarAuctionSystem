using CarAuction.Domain.SharedKernel;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Aggregates.Bids
{
    public record StorageFee : Fee
    {
        private StorageFee(decimal amount) : base(DataDictionary.StorageFee, amount) { }

        public static StorageFee Create(decimal amount)
        {
            return new StorageFee(amount);
        }

    }
}
