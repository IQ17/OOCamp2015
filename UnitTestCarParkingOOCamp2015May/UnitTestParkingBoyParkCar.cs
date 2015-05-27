using System;
using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestParkingBoyParkCar
    {
        private readonly UnitTestParkingBoyPickCar unitTestParkingBoyPickCar = new UnitTestParkingBoyPickCar();

        [Fact]
        public void Should_Be_Success_When_I_Pick_The_Car_That_Boy_Park_In_One_ParkingLot()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);
            var myBoy = new Boy();
            myBoy.Controls(myParkingLot);

            string ticket = myBoy.Park(myCar);

            Assert.Same(myParkingLot.Pick(ticket), myCar);
        }

        [Fact]
        public void Should_Be_Fail_When_Boy_Park_Car_In_Full_ParkingLot()
        {
            uint parkingLotSize = 1;
            var myParkingLot = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);
            var carId2 = "2";
            var myCar2 = new Car(carId2);
            var myBoy = new Boy();
            myBoy.Controls(myParkingLot);

            string ticket = myParkingLot.Park(myCar);

            Assert.Null(myBoy.Park(myCar2)); 
            Assert.Same(myCar, myParkingLot.Pick(ticket));
        }

        [Fact]
        public void Should_Boy_Park_Car_In_Second_ParkingLot_When_First_ParkingLot_Is_Full()
        {

            uint parkingLotSize = 1;
            var myParkingLot1 = new ParkingLot(parkingLotSize);
            var myParkingLot2 = new ParkingLot(parkingLotSize);
            var carId = "1";
            var myCar = new Car(carId);
            var carId2 = "2";
            var myCar2 = new Car(carId2);
            var myBoy = new Boy();
            myBoy.Controls(myParkingLot1);
            myBoy.Controls(myParkingLot2);

            string ticket = myBoy.Park(myCar);
            string ticket2 = myBoy.Park(myCar2);

            Assert.Same(myCar, myParkingLot1.Pick(ticket));
            Assert.Null(myParkingLot1.Pick(ticket2));
            Assert.Same(myCar2, myParkingLot2.Pick(ticket2));
        }

    }
}
