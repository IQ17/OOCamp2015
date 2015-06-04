using System.Collections.Generic;
using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestSuperParkingBoy
    {
        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_No_ParkingLot()
        {
            var superBoy = new SuperParkingBoy(new List<ParkingLot>());

            Assert.Null(superBoy.Park(new Car("1")));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Pick_Car_When_No_ParkingLot()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            aParkingLotWithSpace.Park(new Car("1"));
            var superBoy = new SuperParkingBoy(new List<ParkingLot>());

            Assert.Null(superBoy.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_Successfully_When_There_is_One_ParkingLot_With_Space()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            var superBoy = new SuperParkingBoy(new List<ParkingLot> {aParkingLotWithSpace});
            var myCar = new Car("1");

            superBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick("1"));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(1);
            aFullParkingLot.Park(new Car("1"));
            var superBoy = new SuperParkingBoy(new List<ParkingLot> {aFullParkingLot});

            Assert.Null(superBoy.Park(new Car("2")));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_ParkingLot_Successfully()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            var superBoy = new SuperParkingBoy(new List<ParkingLot> {aParkingLotWithSpace});

            var myCar = new Car("1");
            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, superBoy.Pick("1"));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_The_Second_ParkingLot_Successfully()
        {
            var aFullParkingLot = new ParkingLot(1);
            aFullParkingLot.Park(new Car("1"));
            var aParkingLotWithSpace = new ParkingLot(1);
            var superBoy =
                new SuperParkingBoy(new List<ParkingLot> {aFullParkingLot, aParkingLotWithSpace});
            var myCar = new Car("2");

            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, superBoy.Pick("2"));
        }

        [Fact]
        public void Should_Park_The_Car_In_The_ParkingLot_With_Higher_Vacancy_Rate()
        {
            var aHalfVacantParkingLot = new ParkingLot(2);
            aHalfVacantParkingLot.Park(new Car("1"));
            var aVacantParkingLot = new ParkingLot(1);
            var superBoy =
                new SuperParkingBoy(new List<ParkingLot> {aHalfVacantParkingLot, aVacantParkingLot});
            var myCar = new Car("2");

            superBoy.Park(myCar);

            Assert.Same(myCar, aVacantParkingLot.Pick("2"));
        }

        [Fact]
        public void Should_Park_Car_In_Order_When_All_ParkingLots_Have_The_Same_Vacancy_Rate()
        {
            var aVacantParkingLot = new ParkingLot(1);
            var anotherVacantParkingLot = new ParkingLot(1);
            var superBoy =
                new SuperParkingBoy(
                    new List<ParkingLot> {aVacantParkingLot, anotherVacantParkingLot});
            var myCar = new Car("1");

            superBoy.Park(myCar);

            Assert.Same(myCar, aVacantParkingLot.Pick("1"));
        }
    }
}
