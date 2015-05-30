using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestSeniorParkingBoy
    {
        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_No_ParkingLot()
        {
            var srBoy = new SeniorParkingBoy();

            Assert.Null(srBoy.Park(new Car(carId: "1")));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Pick_Car_When_No_ParkingLot()
        {
            var aParkingLotWithSpace = new ParkingLot(size:20);
            var srBoy = new SeniorParkingBoy();
            aParkingLotWithSpace.Park(new Car(carId: "1"));

            Assert.Null(srBoy.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_Successfully_When_There_is_One_ParkingLot_With_Space()
        {
            var aParkingLotWithSpace = new ParkingLot(size: 20);
            var srBoy = new SeniorParkingBoy();
            srBoy.Manage(aParkingLotWithSpace);
            var myCar = new Car(carId: "1");

            srBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick("1"));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(size: 1);
            aFullParkingLot.Park(new Car(carId: "1"));
            var srBoy = new SeniorParkingBoy();
            srBoy.Manage(aFullParkingLot);

            Assert.Null(srBoy.Park(new Car(carId: "2")));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_ParkingLot_Successfully()
        {
            var aParkingLotWithSpace = new ParkingLot(size: 20);
            var srBoy = new SeniorParkingBoy();
            srBoy.Manage(aParkingLotWithSpace);

            var myCar = new Car(carId: "1");
            string carIdInTicket = aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, srBoy.Pick(carIdInTicket));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_The_Second_ParkingLot_Successfully()
        {
            var aFullParkingLot = new ParkingLot(size: 1);
            aFullParkingLot.Park(new Car(carId: "1"));
            var aParkingLotWithSpace = new ParkingLot(size: 1);
            var srBoy = new SeniorParkingBoy();
            srBoy.Manage(aFullParkingLot);
            srBoy.Manage(aParkingLotWithSpace);
            var myCar = new Car(carId: "2");

            string carIdInTicket = aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, srBoy.Pick(carIdInTicket));
        }

        [Fact]
        public void Should_Park_The_Car_In_The_ParkingLot_With_More_Spaces()
        {
            var aParkingLotWithLessSpace = new ParkingLot(size: 1);
            var aParkingLotWithMoreSpace = new ParkingLot(size: 2);
            var srBoy = new SeniorParkingBoy();
            srBoy.Manage(aParkingLotWithLessSpace);
            srBoy.Manage(aParkingLotWithMoreSpace);
            var myCar = new Car(carId: "1");

            string carIdInTicket = srBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithMoreSpace.Pick(ticket: carIdInTicket));
        }
    }

}
