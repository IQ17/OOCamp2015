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

            Assert.Equal(myParkingLot.Pick(carId).m_carId, carId);
        }

        [Fact]
        public void Should_Be_Fail_When_Car_Is_Not_In_ParkingLot()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);
            myParkingLot.Park(myCar);

            var carId2 = "2";
            var myCar2 = new Car(carId2);

            Assert.Null(myParkingLot.Pick(myCar2.m_carId));
        }

    }
}

