using CarAuction.Domain.SeedWork;
using CarAuction.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAuction.Domain.Aggregates.Cars
{
    public class CarType: Enumeration
    {
        //The enum types of the cars
        public static readonly CarType Common = new(1, DataDictionary.CarType_Common);
        public static readonly CarType Luxury = new(2, DataDictionary.CarType_Luxury);

        private CarType(int value, string name) : base(value, name)
        {
        }
    }
}
