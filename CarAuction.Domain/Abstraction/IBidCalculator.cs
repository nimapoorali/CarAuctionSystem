using CarAuction.Domain.Aggregates.Bids;
using CarAuction.Domain.Aggregates.Cars;
using CarAuction.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Abstraction
{
    public interface IBidCalculator
    {
        HashSet<Fee> CalculateFees(Car car);
    }
}
