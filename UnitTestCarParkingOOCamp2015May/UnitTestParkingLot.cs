﻿using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestParkingLot
    {
        [Fact]
        public void Should_Park_Car_In_ParkingLot_With_Space_Successfully()
        {
            var aParkingLotWithPlace = new ParkingLot(size:20);

            var carIdInTicket = aParkingLotWithPlace.Park(new Car(carId:"1"));

            Assert.Equal("1", carIdInTicket);   
        }

        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(size:1);
            aFullParkingLot.Park(new Car(carId: "1"));

            var ticket = aFullParkingLot.Park(new Car(carId: "2"));

            Assert.Null(ticket);

        }

        [Fact]
        public void Should_Pick_Correct_Car_In_ParkingLot_When_There_Are_Multiple_Cars()
        {
            var aParkingLotWithSpace = new ParkingLot(size:20);
            var myCar = new Car(carId:"1");
            aParkingLotWithSpace.Park(myCar);
            aParkingLotWithSpace.Park(new Car(carId:"2"));

            Assert.Same(myCar, aParkingLotWithSpace.Pick("1"));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Pick_Car_That_Has_Been_Picked()
        {
            var myParkingLot = new ParkingLot(size:20);
            string carIdInTicket = myParkingLot.Park(new Car(carId:"1"));

            myParkingLot.Pick(carIdInTicket);

            Assert.Null(myParkingLot.Pick(carIdInTicket));
        }
    }
}