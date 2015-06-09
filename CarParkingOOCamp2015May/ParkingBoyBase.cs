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

        protected bool HasParkingLots()
        {
            return (ParkingLotsList.Count != 0);
        }

        public string Park(Car aCar)
        {
            if (HasParkingLots())
            {
                var selectedPLot = SelectParkingLot(ParkingLotsList[0]);
                return selectedPLot.Park(aCar);
            }

            return null;
        }

        public abstract ParkingLot SelectParkingLot(ParkingLot initialPLot);
    }
}