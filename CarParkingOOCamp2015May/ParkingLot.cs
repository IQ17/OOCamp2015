using System.Collections.Generic;

namespace CarParkingOOCamp2015May
{
    public class ParkingLot
    {
        private readonly uint m_parkingLotSize;
        private readonly Dictionary<string, Car> m_carInParkingLot;

        public ParkingLot(uint mParkingLotSize)
        {
            m_parkingLotSize = mParkingLotSize;
            m_carInParkingLot = new Dictionary<string, Car>();
        }

        private bool Contains(string carId)
        {
            return m_carInParkingLot.ContainsKey(carId);
        }

        public bool Park(Car myCar)
        {
            if ((m_carInParkingLot.Count >= m_parkingLotSize) || Contains(myCar.m_carId))
            {
                return false;
            }
            m_carInParkingLot.Add(myCar.m_carId, myCar);
            return true;
        }

        public Car Pick(string carId)
        {
            if (!Contains(carId))
            {
                return null;
            }
            var myCar = m_carInParkingLot[carId];
            m_carInParkingLot.Remove(carId);
            return myCar;
        }
    }
}