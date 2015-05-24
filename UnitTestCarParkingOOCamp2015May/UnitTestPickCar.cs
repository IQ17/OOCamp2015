using CarParkingOOCamp2015May;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCarParkingOOCamp2015May
{
    [TestClass]
    public class UnitTestPickCar
    {
        [TestMethod]
        public void Should_Be_Success_When_Car_Is_In_ParkingLot()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);

            myParkingLot.Park(myCar);

            Assert.AreEqual(myParkingLot.Pick(carId).m_carId, carId);
            Assert.IsFalse(myParkingLot.Contains(carId));
        }

        [TestMethod]
        public void Should_Be_Fail_When_Car_Is_Not_In_ParkingLot()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);
            myParkingLot.Park(myCar);

            var carId2 = "2";
            var myCar2 = new Car(carId2);

            Assert.IsFalse(myParkingLot.Contains(carId2));
            Assert.IsNull(myParkingLot.Pick(myCar2.m_carId));
        }

        [TestMethod]
        public void Should_Not_Be_Affected_When_Other_Car_Is_Picked()
        {
            uint parkingLotSize = 20;
            var myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            var myCar = new Car(carId);
            myParkingLot.Park(myCar);

            var carId2 = "2";
            var myCar2 = new Car(carId2);
            myParkingLot.Park(myCar2);

            myParkingLot.Pick(carId);
            Assert.IsTrue(myParkingLot.Contains(myCar2.m_carId));
        }
    }
}

