using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestJuniorParkingBoy
    {
        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_No_ParkingLot()
        {
            var jrBoy = new JuniorParkingBoy();

            Assert.Null(jrBoy.Park(new Car(carId: "1")));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Pick_Car_When_No_ParkingLot()
        {
            var aParkingLotWithSpace = new ParkingLot(size: 20);
            var jrBoy = new JuniorParkingBoy();
            aParkingLotWithSpace.Park(new Car(carId: "1"));

            Assert.Null(jrBoy.Pick(ticket:"1"));
        }

        [Fact]
        public void Should_Park_Car_Successfully_When_There_is_One_ParkingLot_With_Space()
        {
            var aParkingLotWithSpace = new ParkingLot(size:20);            
            var jrBoy = new JuniorParkingBoy();
            jrBoy.Manage(aParkingLotWithSpace);
            var myCar = new Car(carId:"1");

            jrBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick("1"));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(size:1);
            aFullParkingLot.Park(new Car(carId:"1"));
            var jrBoy = new JuniorParkingBoy();
            jrBoy.Manage(aFullParkingLot);

            Assert.Null(jrBoy.Park(new Car(carId:"2"))); 
        }

        [Fact]
        public void Should_Park_Car_In_Second_ParkingLot_When_First_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(size:1);
            aFullParkingLot.Park(new Car(carId:"1"));
            var aParkingLotWithSpace = new ParkingLot(size:1);
            var jrBoy = new JuniorParkingBoy();
            jrBoy.Manage(aFullParkingLot);
            jrBoy.Manage(aParkingLotWithSpace);
            var myCar = new Car(carId:"2");

            jrBoy.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick(ticket:"2"));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_ParkingLot_Successfully()
        {
            var aParkingLotWithSpace = new ParkingLot(size:20);
            var jrBoy = new JuniorParkingBoy();
            jrBoy.Manage(aParkingLotWithSpace);
            var myCar = new Car(carId:"1");
            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, jrBoy.Pick(ticket:"1"));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_The_Second_ParkingLot_Successfully()
        {
            var aFullParkingLot = new ParkingLot(size:1);
            aFullParkingLot.Park(new Car(carId:"1"));
            var aParkingLotWithSpace = new ParkingLot(size:1);
            var jrBoy = new JuniorParkingBoy();
            jrBoy.Manage(aFullParkingLot);
            jrBoy.Manage(aParkingLotWithSpace);
            var myCar = new Car(carId:"2");

            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, jrBoy.Pick(ticket:"2"));
        }

        [Fact]
        public void Should_Park_The_Car_In_The_First_ParkingLot_With_Space()
        {
            var firstParkingLotWithSpace = new ParkingLot(size: 1);
            var secondParkingLotWithSpace = new ParkingLot(size: 1);
            var jrBoy = new JuniorParkingBoy();
            jrBoy.Manage(firstParkingLotWithSpace);
            jrBoy.Manage(secondParkingLotWithSpace);
            var myCar = new Car(carId: "1");

            jrBoy.Park(myCar);

            Assert.Same(myCar, firstParkingLotWithSpace.Pick(ticket:"1"));
        }
    }
}
