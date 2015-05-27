using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestParkCar
    {
        [Fact]
        public void Should_Be_Success_When_ParkingLot_Has_Place()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);

            Assert.Equal(carId, myParkingLot.Park(myCar));   
        }

        [Fact]
        public void Should_Be_Fail_When_ParkingLot_Is_Full()
        {
            uint parkingLotSize = 1;
            var myParkingLot = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);
            var carId2 = "2";
            var myCar2 = new Car(carId2);

            Assert.Equal(carId, myParkingLot.Park(myCar));
            Assert.Null(myParkingLot.Park(myCar2));
        }

    }
}