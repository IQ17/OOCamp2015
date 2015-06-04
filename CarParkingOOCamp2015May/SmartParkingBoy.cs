using System.Collections.Generic;

namespace CarParkingOOCamp2015May
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public override string Park(Car aCar)
        {
            if (ParkingLotsList.Count == 0)
            {
                return null;
            }

            var pLotWithMaxSpace = ParkingLotsList[0];
            foreach (var pLot in ParkingLotsList)
            {
                if (pLot.AvailableSpace() > pLotWithMaxSpace.AvailableSpace())
                {
                    pLotWithMaxSpace = pLot;
                }
            }

            return pLotWithMaxSpace.Park(aCar);
        }

        public SmartParkingBoy(List<ParkingLot> parkingLotsList) : base(parkingLotsList)
        {
            ParkingLotsList = parkingLotsList;
        }
    }
}