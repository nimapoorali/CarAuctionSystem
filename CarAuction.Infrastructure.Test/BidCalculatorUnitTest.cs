using CarAuction.Domain.Aggregates.Cars;
using CarAuction.Domain.SharedKernel;
using System.Linq;
using Xunit;

namespace CarAuction.Infrastructure.Test
{
    public class BidCalculatorUnitTest
    {
        [Fact]
        public void SampleTest_Common398()
        {
            //Arrange
            var bidCalculator = new BidCalculator();

            //Act
            var car = Car.Create(CarType.Common, Price.Create(398));
            var fees = bidCalculator.CalculateFees(car);

            //Assert
            Assert.NotNull(fees);

            Assert.Contains(fees, f => f.Title == "Basic");
            Assert.Equal(39.80M, fees.First(f => f.Title == "Basic")!.Amount);

            Assert.Contains(fees, f => f.Title == "Special");
            Assert.Equal(7.96M, fees.First(f => f.Title == "Special")!.Amount);

            Assert.Contains(fees, f => f.Title == "Association");
            Assert.Equal(5.00M, fees.First(f => f.Title == "Association")!.Amount);

            Assert.Contains(fees, f => f.Title == "Storage");
            Assert.Equal(100.00M, fees.First(f => f.Title == "Storage")!.Amount);

            Assert.Equal(550.76M, fees.Sum(f => f.Amount) + car.Price.Value);

        }

        [Fact]
        public void SampleTest_Common501()
        {
            //Arrange
            var bidCalculator = new BidCalculator();

            //Act
            var car = Car.Create(CarType.Common, Price.Create(501));
            var fees = bidCalculator.CalculateFees(car);

            //Assert
            Assert.NotNull(fees);

            Assert.Contains(fees, f => f.Title == "Basic");
            Assert.Equal(50.00M, fees.First(f => f.Title == "Basic")!.Amount);

            Assert.Contains(fees, f => f.Title == "Special");
            Assert.Equal(10.02M, fees.First(f => f.Title == "Special")!.Amount);

            Assert.Contains(fees, f => f.Title == "Association");
            Assert.Equal(10.00M, fees.First(f => f.Title == "Association")!.Amount);

            Assert.Contains(fees, f => f.Title == "Storage");
            Assert.Equal(100.00M, fees.First(f => f.Title == "Storage")!.Amount);

            Assert.Equal(671.02M, fees.Sum(f => f.Amount) + car.Price.Value);

        }

        [Fact]
        public void SampleTest_Common57()
        {
            //Arrange
            var bidCalculator = new BidCalculator();

            //Act
            var car = Car.Create(CarType.Common, Price.Create(57));
            var fees = bidCalculator.CalculateFees(car);

            //Assert
            Assert.NotNull(fees);

            Assert.Contains(fees, f => f.Title == "Basic");
            Assert.Equal(10.00M, fees.First(f => f.Title == "Basic")!.Amount);

            Assert.Contains(fees, f => f.Title == "Special");
            Assert.Equal(1.14M, fees.First(f => f.Title == "Special")!.Amount);

            Assert.Contains(fees, f => f.Title == "Association");
            Assert.Equal(5.00M, fees.First(f => f.Title == "Association")!.Amount);

            Assert.Contains(fees, f => f.Title == "Storage");
            Assert.Equal(100.00M, fees.First(f => f.Title == "Storage")!.Amount);

            Assert.Equal(173.14M, fees.Sum(f => f.Amount) + car.Price.Value);

        }

        [Fact]
        public void SampleTest_Common1100()
        {
            //Arrange
            var bidCalculator = new BidCalculator();

            //Act
            var car = Car.Create(CarType.Common, Price.Create(1100));
            var fees = bidCalculator.CalculateFees(car);

            //Assert
            Assert.NotNull(fees);

            Assert.Contains(fees, f => f.Title == "Basic");
            Assert.Equal(50.00M, fees.First(f => f.Title == "Basic")!.Amount);

            Assert.Contains(fees, f => f.Title == "Special");
            Assert.Equal(22.00M, fees.First(f => f.Title == "Special")!.Amount);

            Assert.Contains(fees, f => f.Title == "Association");
            Assert.Equal(15.00M, fees.First(f => f.Title == "Association")!.Amount);

            Assert.Contains(fees, f => f.Title == "Storage");
            Assert.Equal(100.00M, fees.First(f => f.Title == "Storage")!.Amount);

            Assert.Equal(1287.00M, fees.Sum(f => f.Amount) + car.Price.Value);

        }

        [Fact]
        public void SampleTest_Luxury1800()
        {
            //Arrange
            var bidCalculator = new BidCalculator();

            //Act
            var car = Car.Create(CarType.Luxury, Price.Create(1800));
            var fees = bidCalculator.CalculateFees(car);

            //Assert
            Assert.NotNull(fees);

            Assert.Contains(fees, f => f.Title == "Basic");
            Assert.Equal(180.00M, fees.First(f => f.Title == "Basic")!.Amount);

            Assert.Contains(fees, f => f.Title == "Special");
            Assert.Equal(72.00M, fees.First(f => f.Title == "Special")!.Amount);

            Assert.Contains(fees, f => f.Title == "Association");
            Assert.Equal(15.00M, fees.First(f => f.Title == "Association")!.Amount);

            Assert.Contains(fees, f => f.Title == "Storage");
            Assert.Equal(100.00M, fees.First(f => f.Title == "Storage")!.Amount);

            Assert.Equal(2167.00M, fees.Sum(f => f.Amount) + car.Price.Value);

        }

        [Fact]
        public void SampleTest_Luxury1000000()
        {
            //Arrange
            var bidCalculator = new BidCalculator();

            //Act
            var car = Car.Create(CarType.Luxury, Price.Create(1000000));
            var fees = bidCalculator.CalculateFees(car);

            //Assert
            Assert.NotNull(fees);

            Assert.Contains(fees, f => f.Title == "Basic");
            Assert.Equal(200.00M, fees.First(f => f.Title == "Basic")!.Amount);

            Assert.Contains(fees, f => f.Title == "Special");
            Assert.Equal(40000.00M, fees.First(f => f.Title == "Special")!.Amount);

            Assert.Contains(fees, f => f.Title == "Association");
            Assert.Equal(20.00M, fees.First(f => f.Title == "Association")!.Amount);

            Assert.Contains(fees, f => f.Title == "Storage");
            Assert.Equal(100.00M, fees.First(f => f.Title == "Storage")!.Amount);

            Assert.Equal(1040320.00M, fees.Sum(f => f.Amount) + car.Price.Value);

        }
    }
}