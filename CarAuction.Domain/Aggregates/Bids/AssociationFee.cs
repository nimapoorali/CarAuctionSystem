using CarAuction.Domain.SharedKernel;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Aggregates.Bids
{
    public record AssociationFee : Fee
    {
        private AssociationFee(decimal amount) : base(DataDictionary.AssociationFee, amount) { }

        public static AssociationFee Create(decimal amount)
        {
            return new AssociationFee(amount);
        }

    }
}
