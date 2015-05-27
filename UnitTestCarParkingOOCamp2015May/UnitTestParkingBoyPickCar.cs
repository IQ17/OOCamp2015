using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestParkingBoyPickCar
    {
        [Fact]
        public void Should_Be_Success_When_Boy_Pick_The_Car_That_I_Park_In_One_ParkingLot()
        {
            const uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);
            const string carId = "1";
            var myCar = new Car(carId);
            var myBoy = new Boy();
            myBoy.Controls(myParkingLot);

            string ticket = myParkingLot.Park(myCar);

            Assert.Same(myCar, myBoy.Pick(ticket));
        }

        [Fact]
        public void Should_Be_Success_When_Boy_Pick_The_Cars_That_I_Park_In_Multiple_ParkingLots()
        {
            uint parkingLotSize = 1;
            var myParkingLot = new ParkingLot(parkingLotSize);
            var myParkingLot2 = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);
            var carId2 = "2";
            var myCar2 = new Car(carId2);
            var myBoy = new Boy();
            myBoy.Controls(myParkingLot);
            myBoy.Controls(myParkingLot2);

            string ticket = myParkingLot.Park(myCar);
            string ticket2 = myParkingLot2.Park(myCar2);

            Assert.Same(myCar, myBoy.Pick(ticket));
            Assert.Same(myCar2, myBoy.Pick(ticket2));
        }

        [Fact]
        public void Should_Be_Fail_When_Boy_Pick_The_Car_That_Has_Been_Picked()
        {
            uint parkingLotSize = 1;
            var myParkingLot = new ParkingLot(parkingLotSize);
            var myParkingLot2 = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);
            var carId2 = "2";
            var myCar2 = new Car(carId2);
            var myBoy = new Boy();
            myBoy.Controls(myParkingLot);
            myBoy.Controls(myParkingLot2);
        }
    }
}