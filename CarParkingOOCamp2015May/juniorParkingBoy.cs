using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class JuniorParkingBoy
    {
        private readonly List<ParkingLot> parkingLotsList;

        public JuniorParkingBoy()
        {
            parkingLotsList = new List<ParkingLot>();
        }

        public string Park(Car aCar)
        {
            return
                parkingLotsList.Select(pLot => pLot.Park(aCar))
                    .FirstOrDefault(ticket => ticket != null);
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