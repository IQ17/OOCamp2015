using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class SeniorParkingBoy
    {
        private readonly List<ParkingLot> parkingLotsList;

        public SeniorParkingBoy()
        {
            parkingLotsList = new List<ParkingLot>();
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

        public void Manage(ParkingLot aParkingLot)
        {
            parkingLotsList.Add(aParkingLot);
        }

        public Car Pick(string ticket)
        {
            return parkingLotsList.Select(pLot => pLot.Pick(ticket))
                .FirstOrDefault(car => car != null);
        }
    }
}