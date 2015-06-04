using System.Collections.Generic;
using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestSmartParkingBoy
    {
        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_No_ParkingLot()
        {
            var smartBoy = new SmartParkingBoy(new List<ParkingLot>());

            Assert.Null(smartBoy.Park(new Car(carId: "1")));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Pick_Car_When_No_ParkingLot()
        {
            var aParkingLotWithSpace = new ParkingLot(size:20);
            aParkingLotWithSpace.Park(new Car(carId: "1"));
            var smartBoy = new SmartParkingBoy(new List<ParkingLot>());

            Assert.Null(smartBoy.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_Successfully_When_There_is_One_ParkingLot_With_Space()
        {
            var aParkingLotWithSpace = new ParkingLot(size: 20);
            var smartBoy = new SmartParkingBoy(new List<ParkingLot> {aParkingLotWithSpace});
            var myCar = new Car(carId: "1");

            smartBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick("1"));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(size: 1);
            aFullParkingLot.Park(new Car(carId: "1"));
            var smartBoy = new SmartParkingBoy(new List<ParkingLot>{aFullParkingLot});

            Assert.Null(smartBoy.Park(new Car(carId: "2")));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_ParkingLot_Successfully()
        {
            var aParkingLotWithSpace = new ParkingLot(size: 20);
            var smartBoy = new SmartParkingBoy(new List<ParkingLot>{aParkingLotWithSpace});

            var myCar = new Car(carId: "1");
            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, smartBoy.Pick(ticket:"1"));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_The_Second_ParkingLot_Successfully()
        {
            var aFullParkingLot = new ParkingLot(size: 1);
            aFullParkingLot.Park(new Car(carId: "1"));
            var aParkingLotWithSpace = new ParkingLot(size: 1);
            var smartBoy = new SmartParkingBoy(new List<ParkingLot>{aFullParkingLot,aParkingLotWithSpace});
            var myCar = new Car(carId: "2");

            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, smartBoy.Pick(ticket:"2"));
        }

        [Fact]
        public void Should_Park_The_Car_In_The_ParkingLot_With_More_Spaces()
        {
            var aParkingLotWithLessSpace = new ParkingLot(size: 1);
            var aParkingLotWithMoreSpace = new ParkingLot(size: 2);
            var smartBoy = new SmartParkingBoy(new List<ParkingLot>{aParkingLotWithLessSpace,aParkingLotWithMoreSpace});
            var myCar = new Car(carId: "1");

            smartBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithMoreSpace.Pick(ticket: "1"));
        }

        [Fact]
        public void Should_Park_Car_In_Order_When_All_ParkingLots_Have_The_Same_Available_Space()
        {
            var aParkingLotWithOneSpace = new ParkingLot(size: 1);
            var anotherParkingLotWithOneSpace = new ParkingLot(size: 1);
            var smartBoy = new SmartParkingBoy(new List<ParkingLot>{aParkingLotWithOneSpace,anotherParkingLotWithOneSpace});
            var myCar = new Car(carId: "1");

            smartBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithOneSpace.Pick(ticket:"1"));
        }
    }

}
