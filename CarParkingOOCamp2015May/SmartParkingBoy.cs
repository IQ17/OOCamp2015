using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class SmartParkingBoy
    {
        private readonly List<ParkingLot> parkingLotsList;

        public SmartParkingBoy(List<ParkingLot> parkingLotsList)
        {
            this.parkingLotsList = parkingLotsList;
        }

        public string Park(Car aCar)
        {
            if (parkingLotsList.Count == 0)
            {
                return null;
            }

            var pLotWithMaxSpace = parkingLotsList[0];
            foreach (var pLot in parkingLotsList) 
            {
                if (pLot.AvailableSpace() > pLotWithMaxSpace.AvailableSpace())
                {
                    pLotWithMaxSpace = pLot;
                }
            }

            return pLotWithMaxSpace.Park(aCar);
        }

        public Car Pick(string ticket)
        {
            return parkingLotsList.Select(pLot => pLot.Pick(ticket))
                .FirstOrDefault(car => car != null);
        }
    }
}