using CarAuction.Domain.Abstraction;
using CarAuction.Domain.Aggregates.Bids;
using CarAuction.Domain.Aggregates.Cars;
using CarAuction.Domain.SharedKernel;

namespace CarAuction.Infrastructure
{
    public class BidCalculator : IBidCalculator
    {
        const string BASIC = "Basic";
        const string SPECIAL = "Special";
        const string ASSOCIATION = "Association";
        const string STORAGE = "Storage";

        /// <summary>
        /// Implementation for IBidCalculator
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public HashSet<Fee> CalculateFees(Car car)
        {
            decimal price = car.Price.Value;
            int carType = car.Type.Value;

            if (price < 1)
            {
                return new HashSet<Fee>();
            }


            if (carType == CarType.Common.Value)
            {
                return new HashSet<Fee>
                {
                    Fee.Create(BASIC, Math.Min(50M, Math.Max(price*0.1M, 10M))),
                    Fee.Create(SPECIAL, car.Price.Value*0.02M),
                    Fee.Create(ASSOCIATION,
                        (price>0M && price<=500M)?5M:
                        (price>500M && price<=1000M)?10M:
                        (price>1000M && price<=3000M)?15M:
                        20M),
                    Fee.Create(STORAGE, 100M)
                };
            }
            else if (carType == CarType.Luxury.Value)
            {
                return new HashSet<Fee>
                {
                    Fee.Create(BASIC, Math.Min(200M, Math.Max(price*0.1M, 25M))),
                    Fee.Create(SPECIAL, car.Price.Value*0.04M),
                    Fee.Create(ASSOCIATION,
                        (price>0M && price<=500M)?5M:
                        (price>500M && price<=1000M)?10M:
                        (price>1000M && price<=3000M)?15M:
                        20M),
                    Fee.Create(STORAGE, 100M)
                };
            }

            return new HashSet<Fee>();
        }

        private HashSet<Fee> CalculateFees_Test(Car car)
        {
            //moq
            if (car.Type == CarType.Common && car.Price.Value == 398)
            {
                return new HashSet<Fee>
                {
                    BasicFee.Create(39.80M),
                    SpecialFee.Create(7.96M),
                    AssociationFee.Create(5M),
                    StorageFee.Create(100M)
                };
            }

            if (car.Type == CarType.Common && car.Price.Value == 501)
            {
                return new HashSet<Fee>
                {
                    BasicFee.Create(50M),
                    SpecialFee.Create(10.02M),
                    AssociationFee.Create(10M),
                    StorageFee.Create(100M)
                };
            }

            if (car.Type == CarType.Common && car.Price.Value == 57)
            {
                return new HashSet<Fee>
                {
                    BasicFee.Create(10M),
                    SpecialFee.Create(1.14M),
                    AssociationFee.Create(5M),
                    StorageFee.Create(100M)
                };
            }

            if (car.Type == CarType.Common && car.Price.Value == 1100)
            {
                return new HashSet<Fee>
                {
                    BasicFee.Create(50M),
                    SpecialFee.Create(22M),
                    AssociationFee.Create(15M),
                    StorageFee.Create(100M)
                };
            }

            if (car.Type == CarType.Luxury && car.Price.Value == 1800)
            {
                return new HashSet<Fee>
                {
                    BasicFee.Create(180M),
                    SpecialFee.Create(72M),
                    AssociationFee.Create(15M),
                    StorageFee.Create(100M)
                };
            }

            if (car.Type == CarType.Luxury && car.Price.Value == 1000000)
            {
                return new HashSet<Fee>
                {
                    BasicFee.Create(200M),
                    SpecialFee.Create(40000M),
                    AssociationFee.Create(20M),
                    StorageFee.Create(100M)
                };
            }

            return new HashSet<Fee>();
        }
    }
}