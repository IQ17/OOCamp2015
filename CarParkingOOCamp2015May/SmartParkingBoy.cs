using System.Collections.Generic;

namespace CarParkingOOCamp2015May
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public override ParkingLot SelectParkingLot(ParkingLot pLotWithMaxSpace)
        {
            foreach (var pLot in ParkingLotsList)
            {
                if (pLot.AvailableSpace() > pLotWithMaxSpace.AvailableSpace())
                {
                    pLotWithMaxSpace = pLot;
                }
            }
            return pLotWithMaxSpace;
        }

        public SmartParkingBoy(List<ParkingLot> parkingLotsList) : base(parkingLotsList)
        {
            ParkingLotsList = parkingLotsList;
        }
    }
}