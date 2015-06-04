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
            return
                ParkingLotsList.Select(pLot => pLot.Park(aCar))
                    .FirstOrDefault(ticket => ticket != null);
        }
    }
}