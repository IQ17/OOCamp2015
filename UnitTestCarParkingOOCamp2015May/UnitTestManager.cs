using System.Collections.Generic;
using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestManager
    {
        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_No_ParkingLot()
        {
            var manager = new Manager(new List<ParkingLot>());

            Assert.Null(manager.Park(new Car("1")));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Pick_Car_When_No_ParkingLot()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            aParkingLotWithSpace.Park(new Car("1"));
            var manager = new Manager(new List<ParkingLot>());

            Assert.Null(manager.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_Successfully_When_There_is_One_ParkingLot_With_Space()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            var manager = new Manager(new List<ParkingLot> {aParkingLotWithSpace});
            var myCar = new Car("1");

            manager.Park(myCar);

            Assert.Same(myCar, aParkingLotWithSpace.Pick("1"));
        }

        [Fact]
        public void Should_Not_Be_Able_To_Park_Car_When_ParkingLot_Is_Full()
        {
            var aFullParkingLot = new ParkingLot(1);
            aFullParkingLot.Park(new Car("1"));
            var manager = new Manager(new List<ParkingLot> {aFullParkingLot});

            Assert.Null(manager.Park(new Car("2")));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_ParkingLot_Successfully()
        {
            var aParkingLotWithSpace = new ParkingLot(20);
            var manager = new Manager(new List<ParkingLot> {aParkingLotWithSpace});

            var myCar = new Car("1");
            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, manager.Pick("1"));
        }

        [Fact]
        public void Should_Pick_The_Car_That_I_Parked_In_The_Second_ParkingLot_Successfully()
        {
            var aFullParkingLot = new ParkingLot(1);
            aFullParkingLot.Park(new Car("1"));
            var aParkingLotWithSpace = new ParkingLot(1);
            var manager =
                new Manager(new List<ParkingLot> {aFullParkingLot, aParkingLotWithSpace});
            var myCar = new Car("2");

            aParkingLotWithSpace.Park(myCar);

            Assert.Same(myCar, manager.Pick("2"));
        }

        [Fact]
        public void
            Should_Park_Car_In_The_OrdinaryBoys_ParkingLot_When_Manage_Have_One_OrdinaryBoy_But_No_ParkingLot
            ()
        {
            OrdinaryParkingBoy boy = new OrdinaryParkingBoy(
                new List<ParkingLot> {new ParkingLot(1)});
            Manager manager = new Manager(new List<ParkingLot>(), boy);
            Car car = new Car(carId: "1");

            manager.Park(car);

            Assert.Same(car, boy.Pick("1"));
        }

        [Fact]
        public void
            Should_Park_Car_In_The_OrdinaryBoys_ParkingLot_When_Manage_Have_Two_OrdinaryBoys_But_No_ParkingLot
            ()
        {
            OrdinaryParkingBoy boyWithoutParkingLot = new OrdinaryParkingBoy(new List<ParkingLot>());
            OrdinaryParkingBoy boyWithParkingLot =
                new OrdinaryParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(
                new List<ParkingLot>(),
                new List<OrdinaryParkingBoy> {boyWithParkingLot, boyWithoutParkingLot});
            Car car = new Car(carId: "1");

            manager.Park(car);

            Assert.Same(car, boyWithParkingLot.Pick(ticket: "1"));
        }

        [Fact]
        public void
            Should_Be_Able_To_Pick_Car_In_OrdinaryBoys_ParkingLot_When_Manager_Has_No_ParkingLot()
        {
            OrdinaryParkingBoy boyWithParkingLot =
                new OrdinaryParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(new List<ParkingLot>(), boyWithParkingLot);
            Car car = new Car(carId: "1");
            boyWithParkingLot.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void
            Should_Be_Able_To_Pick_Car_In_OrdinaryBoys_ParkingLot_When_Manager_Has_ParkingLot()
        {
            OrdinaryParkingBoy boyWithParkingLot =
                new OrdinaryParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(
                new List<ParkingLot> {new ParkingLot(size: 0)},
                boyWithParkingLot);
            Car car = new Car(carId: "1");
            boyWithParkingLot.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void Should_Be_Able_To_Park_and_Pick_Car_When_Manager_Has_ParkingLot_And_OrdinaryBoy(
            )
        {
            OrdinaryParkingBoy boyWithParkingBoy =
                new OrdinaryParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(
                new List<ParkingLot> {new ParkingLot(size: 1)},
                boyWithParkingBoy);
            Car car = new Car(carId: "1");
            manager.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void Should_Fail_To_Park_Car_When_Manager_And_OrdinaryBoys_ParkingLots_Are_All_Full()
        {
            OrdinaryParkingBoy boyWithoutParkingLot =
                new OrdinaryParkingBoy(new List<ParkingLot> {new ParkingLot(size: 0)});
            Manager manager = new Manager(
                new List<ParkingLot> {new ParkingLot(size: 0)},
                boyWithoutParkingLot);

            Assert.Null(manager.Park(new Car(carId: "1")));
        }

        public void Should_Park_Car_In_The_SmartBoys_ParkingLot_When_Manage_Only_Has_One_SmartBoy()
        {
            SmartParkingBoy boy = new SmartParkingBoy(new List<ParkingLot> {new ParkingLot(1)});
            Manager manager = new Manager(new List<ParkingLot>(), boy);
            Car car = new Car(carId: "1");

            manager.Park(car);

            Assert.Same(car, boy.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_In_The_SmartBoys_ParkingLot_When_Manage_Only_Has_Two_SmartBoys()
        {
            SmartParkingBoy boyWithoutParkingLot = new SmartParkingBoy(new List<ParkingLot>());
            SmartParkingBoy boyWithParkingLot =
                new SmartParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(
                new List<ParkingLot>(),
                new List<SmartParkingBoy> {boyWithParkingLot, boyWithoutParkingLot});
            Car car = new Car(carId: "1");

            manager.Park(car);

            Assert.Same(car, boyWithParkingLot.Pick(ticket: "1"));
        }

        [Fact]
        public void
            Should_Be_Able_To_Pick_Car_In_SmartBoys_ParkingLot_When_Manager_Has_No_ParkingLot_And_No_OrdinaryBoy
            ()
        {
            SmartParkingBoy boyWithParkingLot =
                new SmartParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(new List<ParkingLot>(), boyWithParkingLot);
            Car car = new Car(carId: "1");
            boyWithParkingLot.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void
            Should_Be_Able_To_Pick_Car_In_SmartBoys_ParkingLot_When_Manager_Has_ParkingLot_But_No_OrdinaryBoy
            ()
        {
            SmartParkingBoy boyWithParkingLot =
                new SmartParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(
                new List<ParkingLot> {new ParkingLot(size: 0)},
                boyWithParkingLot);
            Car car = new Car(carId: "1");
            boyWithParkingLot.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void
            Should_Be_Able_To_Park_and_Pick_Car_When_Manager_Has_ParkingLot_And_SmartParkingBoy_But_No_OrdinaryBoy
            ()
        {
            SmartParkingBoy boyWithParkingLot =
                new SmartParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(
                new List<ParkingLot> {new ParkingLot(size: 1)},
                boyWithParkingLot);
            Car car = new Car(carId: "1");
            manager.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void
            Should_Fail_To_Park_Car_When_Manager_And_SmartBoys_ParkingLots_Are_All_Full_And_No_OrdinaryBoy
            ()
        {
            SmartParkingBoy boyWithoutParkingLot =
                new SmartParkingBoy(new List<ParkingLot> {new ParkingLot(size: 0)});
            Manager manager = new Manager(
                new List<ParkingLot> {new ParkingLot(size: 0)},
                boyWithoutParkingLot);

            Assert.Null(manager.Park(new Car(carId: "1")));
        }

        [Fact]
        public void Should_Park_Car_In_The_SuperBoys_ParkingLot_When_Manage_Only_Has_One_SuperBoy()
        {
            SuperParkingBoy boy = new SuperParkingBoy(new List<ParkingLot> {new ParkingLot(1)});
            Manager manager = new Manager(new List<ParkingLot>(), boy);
            Car car = new Car(carId: "1");

            manager.Park(car);

            Assert.Same(car, boy.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_In_The_SuperBoys_ParkingLot_When_Manage_Only_Has_One_Full_ParkingLot_And_One_SuperBoy()
        {
            SuperParkingBoy boy = new SuperParkingBoy(new List<ParkingLot> {new ParkingLot(1)});
            Manager manager = new Manager(new List<ParkingLot> { new ParkingLot(size: 0) }, boy);
            Car car = new Car(carId: "1");

            manager.Park(car);

            Assert.Same(car, boy.Pick("1"));
        }

        [Fact]
        public void Should_Park_Car_In_The_SuperBoys_ParkingLot_When_Manage_Only_Has_Two_SuperBoys()
        {
            SuperParkingBoy boyWithoutParkingLot = new SuperParkingBoy(new List<ParkingLot>());
            SuperParkingBoy boyWithParkingLot =
                new SuperParkingBoy(new List<ParkingLot> {new ParkingLot(size: 1)});
            Manager manager = new Manager(
                new List<ParkingLot>(),
                new List<SuperParkingBoy> {boyWithParkingLot, boyWithoutParkingLot});
            Car car = new Car(carId: "1");

            manager.Park(car);

            Assert.Same(car, boyWithParkingLot.Pick(ticket: "1"));
        }

        [Fact]
        public void Should_Be_Able_To_Pick_Car_In_SuperBoys_ParkingLot_When_Manager_Has_No_ParkingLot_And_No_OrdinaryBoy_And_No_SmartBoy()
        {
            SuperParkingBoy boyWithParkingLot = new SuperParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) });
            Manager manager = new Manager(new List<ParkingLot>(), boyWithParkingLot);
            Car car = new Car(carId: "1");
            boyWithParkingLot.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void Should_Be_Able_To_Pick_Car_In_SuperBoys_ParkingLot_When_Manager_Has_ParkingLot_But_No_OrdinaryBoy_And_No_SmartBoy()
        {
            SuperParkingBoy boyWithParkingLot = new SuperParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) });
            Manager manager = new Manager(new List<ParkingLot> { new ParkingLot(size: 1) }, boyWithParkingLot);
            Car car = new Car(carId: "1");
            boyWithParkingLot.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void Should_Be_Able_To_Park_and_Pick_Car_When_Manager_Has_ParkingLot_And_SuperBoy_But_No_OrdinaryBoy_And_No_SmartBoy()
        {
            SuperParkingBoy boyWithParkingLot = new SuperParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) });
            Manager manager = new Manager(new List<ParkingLot> { new ParkingLot(size: 1) }, boyWithParkingLot);
            Car car = new Car(carId: "1");
            manager.Park(car);

            Assert.Same(car, manager.Pick(ticket: "1"));
        }

        [Fact]
        public void Should_Fail_To_Park_Car_When_Manager_And_SuperBoys_ParkingLots_Are_All_Full_And_No_OrdinaryBoy_And_No_SmartBoy()
        {
            SuperParkingBoy boyWithoutParkingLot = new SuperParkingBoy(new List<ParkingLot> { new ParkingLot(size: 0) });
            Manager manager = new Manager(new List<ParkingLot> { new ParkingLot(size: 0) }, boyWithoutParkingLot);

            Assert.Null(manager.Park(new Car(carId: "1")));
        }

        [Fact]
        public void Should_Be_Able_Manage_Three_Kinds_Of_Boys_Simultaneously()
        {
            OrdinaryParkingBoy ordinaryBoy = new OrdinaryParkingBoy(new List<ParkingLot>{new ParkingLot(size:1)});
            SmartParkingBoy smartBoy = new SmartParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) });
            SuperParkingBoy superBoy = new SuperParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) });
            Manager manager = new Manager(new List<ParkingLot>(), new List<ParkingBoyBase>
            {
                ordinaryBoy,
                smartBoy,
                superBoy
            });
            Car car = new Car(carId:"1");

            manager.Park(car);

            Assert.Same(car, manager.Pick(ticket:"1"));
        }
    }
}
