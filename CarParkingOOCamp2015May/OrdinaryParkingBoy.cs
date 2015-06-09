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
        
        public override ParkingLot SelectParkingLot(ParkingLot parkingLotWithSpace)
        {
            foreach (var pLot in ParkingLotsList)
            {
                if (pLot.AvailableSpace() > 0)
                {
                    parkingLotWithSpace = pLot;
                    break;
                }
            }
            return parkingLotWithSpace;
        }
    }
}