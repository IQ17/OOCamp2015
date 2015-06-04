using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    abstract public class ParkingBoyBase
    {
        protected List<ParkingLot> ParkingLotsList;

        protected ParkingBoyBase(List<ParkingLot> parkingLotsList)
        {
            this.ParkingLotsList = parkingLotsList;
        }

        public Car Pick(string ticket)
        {
            return ParkingLotsList.Select(pLot => pLot.Pick(ticket))
                .FirstOrDefault(car => car != null);
        }

        public abstract string Park(Car aCar);
    }
}