using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class OrdinaryParkingBoy
    {
        private readonly List<ParkingLot> parkingLotsList;

        public OrdinaryParkingBoy(List<ParkingLot> parkingLotsList)
        {
            this.parkingLotsList = parkingLotsList;
        }

        public string Park(Car aCar)
        {
            return
                parkingLotsList.Select(pLot => pLot.Park(aCar))
                    .FirstOrDefault(ticket => ticket != null);
        }

        public Car Pick(string ticket)
        {
            return parkingLotsList.Select(pLot => pLot.Pick(ticket))
                .FirstOrDefault(car => car != null);
        }
    }
}