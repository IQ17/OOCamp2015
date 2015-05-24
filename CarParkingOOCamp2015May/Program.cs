using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CarParkingOOCamp2015May
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Car
    {
        public string m_carId { get; private set; }

        public bool Park(ParkingLot myParkingLot)
        {
            return myParkingLot.AddCar(this);
        }

        public Car Pick(ParkingLot myParkingLot)
        {
            return myParkingLot.RemoveCar(this);
        }

        public Car(string carId)
        {
            this.m_carId = carId;
        }
    }

    public class ParkingLot
    {
        private readonly uint m_parkingLotSize;
        private readonly Dictionary<string, Car> m_carInParkingLot;
        public bool Contains(string carId)
        {
            return m_carInParkingLot.ContainsKey(carId);
        }

        public bool AddCar(Car myCar)
        {
            if ((m_carInParkingLot.Count >= m_parkingLotSize) || Contains(myCar.m_carId))
            {
                return false;
            }
            m_carInParkingLot.Add(myCar.m_carId, myCar);
            return true;
        }

        public Car RemoveCar(Car car)
        {
            if (Contains(car.m_carId))
            {
                var myCar = m_carInParkingLot[car.m_carId];
                m_carInParkingLot.Remove(car.m_carId);
                return myCar;
            }
            else
            {
                return null;
            }
        }

        public ParkingLot(uint parkingLotSize)
        {
            this.m_parkingLotSize = parkingLotSize;
            this.m_carInParkingLot = new Dictionary<string, Car>();
        }
    }

}
