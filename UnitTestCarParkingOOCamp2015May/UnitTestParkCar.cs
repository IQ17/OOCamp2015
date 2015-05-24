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
            ParkingLot myParkingLot = new ParkingLot(parkingLotSize);

            string carId = "1";
            Car myCar = new Car(carId);

            myCar.Park(myParkingLot);
            Assert.IsTrue(myParkingLot.Contains(carId));
        }

        [TestMethod]
        public void Should_Be_Fail_When_Parking_The_Same_Car_Twice()
        {
            uint parkingLotSize = 20;
            ParkingLot myParkingLot = new ParkingLot(parkingLotSize);

            string carId = "1";
            Car myCar = new Car(carId);

            Assert.IsTrue(myCar.Park(myParkingLot));
            Assert.IsFalse(myCar.Park(myParkingLot));
        }


        [TestMethod]
        public void Should_Be_Fail_When_ParkingLot_Is_Full()
        {
            uint parkingLotSize = 1;
            ParkingLot myParkingLot = new ParkingLot(parkingLotSize);

            string carId = "1";
            Car myCar = new Car(carId);

            string carId2 = "2";
            Car myCar2 = new Car(carId2);

            Assert.IsTrue(myCar.Park(myParkingLot));
            Assert.IsFalse(myCar2.Park(myParkingLot));
        }

    }

    
}
