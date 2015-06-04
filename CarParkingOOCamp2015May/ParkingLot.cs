using System.Collections.Generic;

namespace CarParkingOOCamp2015May
{
    public class ParkingLot
    {
        private readonly uint parkingLotSize;
        private readonly Dictionary<string, Car> carsInParkingLot;

        public ParkingLot(uint size)
        {
            parkingLotSize = size;
            carsInParkingLot = new Dictionary<string, Car>();
        }

        private bool Contains(string ticket)
        {
            return carsInParkingLot.ContainsKey(ticket);
        }

        public string Park(Car myCar)
        {
            var ticketTmp = myCar.CarId;
            if ((carsInParkingLot.Count >= parkingLotSize) || Contains(ticketTmp))
            {
                return null;
            }
            carsInParkingLot.Add(ticketTmp, myCar);
            return ticketTmp;
        }

        public Car Pick(string ticket)
        {
            if (!Contains(ticket))
            {
                return null;
            }
            var myCar = carsInParkingLot[ticket];
            carsInParkingLot.Remove(ticket);
            return myCar;
        }

        internal long AvailableSpace()
        {
            return parkingLotSize - carsInParkingLot.Count;
        }

        internal long VacancyRate()
        {
            return AvailableSpace() / parkingLotSize;
        }
    }
}