using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class OrdinaryParkingBoy : ParkingBoyBase
    {
        public OrdinaryParkingBoy(List<ParkingLot> parkingLotsList) : base(parkingLotsList)
        {
            ParkingLotsList = parkingLotsList;
        }

        public override string Park(Car aCar)
        {
            if (ParkingLotsList.Count != 0)
            {
                foreach (var pLot in ParkingLotsList)
                {
                    if (pLot.AvailableSpace() > 0)
                    {
                        return pLot.Park(aCar);
                    }
                }
            }
            return null;
        }
    }
}