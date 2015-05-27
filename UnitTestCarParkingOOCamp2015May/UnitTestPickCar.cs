using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestPickCar
    {
        [Fact]
        public void Should_Be_Success_When_Car_Is_In_ParkingLot()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);

            myParkingLot.Park(myCar);

            Assert.Same(myCar, myParkingLot.Pick(carId)) ;
            Assert.Null(myParkingLot.Pick(carId));
        }

        [Fact]
        public void Should_Be_Fail_When_Car_Is_Not_In_ParkingLot()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);

            string ticket = myParkingLot.Park(myCar);
            myParkingLot.Pick(ticket);
            
            Assert.Null(myParkingLot.Pick(ticket));
        }

    }
}

