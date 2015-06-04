using System.Collections.Generic;
using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestOrdinaryParkingBoy
    {
        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_No_ParkingLot()
        {
            var ordinaryBoy = new OrdinaryParkingBoy(new List<ParkingLot>());

            Assert.Null(ordinaryBoy.Park(new Car("1")));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Pick_Car_When_No_ParkingLot()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            aParkingLotWithSpace.Park(new Car("1"));
            var ordinaryBoy = new OrdinaryParkingBoy(new List<ParkingLot>());

            Assert.Null(ordinaryBoy.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_Successfully_When_There_is_One_ParkingLot_With_Space()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            var ordinaryBoy = new OrdinaryParkingBoy(new List<ParkingLot> {aParkingLotWithSpace});
            var myCar = new Car("1");

            ordinaryBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick("1"));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(1);
            aFullParkingLot.Park(new Car("1"));
            var ordinaryBoy = new OrdinaryParkingBoy(new List<ParkingLot> {aFullParkingLot});

            Assert.Null(ordinaryBoy.Park(new Car("2")));
        }

        [Fact]
        public void Should_Park_Car_In_Second_ParkingLot_When_First_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(1);
            aFullParkingLot.Park(new Car("1"));
            var aParkingLotWithSpace = new ParkingLot(1);
            var ordinaryBoy =
                new OrdinaryParkingBoy(new List<ParkingLot> {aFullParkingLot, aParkingLotWithSpace});
            var myCar = new Car("2");

            ordinaryBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick("2"));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_ParkingLot_Successfully()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            var myCar = new Car("1");
            aParkingLotWithSpace.Park(myCar);
            var ordinaryBoy = new OrdinaryParkingBoy(new List<ParkingLot> {aParkingLotWithSpace});

            Assert.Same(myCar, ordinaryBoy.Pick("1"));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_The_Second_ParkingLot_Successfully()
        {
            var aFullParkingLot = new ParkingLot(1);
            aFullParkingLot.Park(new Car("1"));
            var aParkingLotWithSpace = new ParkingLot(1);
            var ordinaryBoy =
                new OrdinaryParkingBoy(new List<ParkingLot> {aFullParkingLot, aParkingLotWithSpace});
            var myCar = new Car("2");

            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, ordinaryBoy.Pick("2"));
        }

        [Fact]
        public void Should_Park_The_Car_In_The_First_ParkingLot_With_Space()
        {
            var firstParkingLotWithSpace = new ParkingLot(1);
            var secondParkingLotWithSpace = new ParkingLot(1);
            var ordinaryBoy =
                new OrdinaryParkingBoy(
                    new List<ParkingLot> {firstParkingLotWithSpace, secondParkingLotWithSpace});
            var myCar = new Car("1");

            ordinaryBoy.Park(myCar);

            Assert.Same(myCar, firstParkingLotWithSpace.Pick("1"));
        }
    }
}
