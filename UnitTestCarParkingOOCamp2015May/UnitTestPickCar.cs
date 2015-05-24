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
            ParkingLot myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            Car myCar = new Car(carId);

            myCar.Park(myParkingLot);

            Assert.AreEqual(myCar.Pick(myParkingLot).m_carId, carId);
            Assert.IsFalse(myParkingLot.Contains(carId));
        }

        [TestMethod]
        public void Should_Be_Fail_When_Car_Is_Not_In_ParkingLot()
        {
            uint parkingLotSize = 20;
            ParkingLot myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            Car myCar = new Car(carId);
            myCar.Park(myParkingLot);

            var carId2 = "2";
            Car myCar2 = new Car(carId2);

            Assert.IsFalse(myParkingLot.Contains(carId2));
            Assert.IsNull(myCar2.Pick(myParkingLot));
        }

        [TestMethod]
        public void Should_Not_Be_Affected_When_Other_Car_Is_Picked()
        {
            uint parkingLotSize = 20;
            ParkingLot myParkingLot = new ParkingLot(parkingLotSize);

            var carId = "1";
            Car myCar = new Car(carId);
            myCar.Park(myParkingLot);

            var carId2 = "2";
            Car myCar2 = new Car(carId2);
            myCar2.Park(myParkingLot);

            myCar.Pick(myParkingLot);
            Assert.AreEqual(myCar2.Pick(myParkingLot).m_carId, carId2);
        }
    }
}

