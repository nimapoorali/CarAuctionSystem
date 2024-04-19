using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarAuction.Domain.SharedKernel;

namespace CarAuction.Domain.Aggregates.Cars
{
    public class Car
    {

        public Price Price { get; init; }
        public CarType Type { get; init; }

        ////todo: extra properties examples
        //public string Brand { get; }
        //public string Model { get; }


        private Car(CarType type, Price price)
        {
            Price = price;
            Type = type;
        }

        public static Car Create(CarType type, Price price)
        {
            //Car specified rules
            //
            //Car specified rules


            return new Car(type, price);
        }
    }
}
