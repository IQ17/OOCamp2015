using System.Collections.Generic;

namespace CarParkingOOCamp2015May
{
    public class SuperParkingBoy:ParkingBoyBase
    {
        public override ParkingLot SelectParkingLot(ParkingLot pLotWithHighestVacancyRate)
        {
            foreach (var pLot in ParkingLotsList)
            {
                if (pLot.VacancyRate() > pLotWithHighestVacancyRate.VacancyRate())
                {
                    pLotWithHighestVacancyRate = pLot;
                }
            }
            return pLotWithHighestVacancyRate;
        }

        public SuperParkingBoy(List<ParkingLot> parkingLotsList) : base(parkingLotsList)
        {
            ParkingLotsList = parkingLotsList;
        }
    }
}