using CarParkingOOCamp2015May;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarParkingOOCamp2015May
{
    [TestClass]
    public class UnitTestParkCar
    {
        [TestMethod]
        public void Should_Be_Success_When_ParkingLot_Has_Place()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);

            myParkingLot.Park(myCar);
            Assert.IsTrue(myParkingLot.Contains(carId));
        }

        [TestMethod]
        public void Should_Be_Fail_When_Parking_The_Same_Car_Twice()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);

            Assert.IsTrue(myParkingLot.Park(myCar));
            Assert.IsFalse(myParkingLot.Park(myCar));
        }

        [TestMethod]
        public void Should_Be_Fail_When_ParkingLot_Is_Full()
        {
            uint parkingLotSize = 1;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);

            var carId2 = "2";
            var myCar2 = new Car(carId2);

            Assert.IsTrue(myParkingLot.Park(myCar));
            Assert.IsFalse(myParkingLot.Park(myCar2));
        }
    }
}