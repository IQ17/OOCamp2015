using System.Collections.Generic;

namespace CarParkingOOCamp2015May
{
    public class SuperParkingBoy:ParkingBoyBase
    {
        public override string Park(Car aCar)
        {
            if (ParkingLotsList.Count == 0)
            {
                return null;
            }

            var pLotWithHighestVacancyRate = ParkingLotsList[0];
            foreach (var pLot in ParkingLotsList) 
            {
                if (pLot.VacancyRate() > pLotWithHighestVacancyRate.VacancyRate())
                {
                    pLotWithHighestVacancyRate = pLot;
                }
            }

            return pLotWithHighestVacancyRate.Park(aCar);
        }

        public SuperParkingBoy(List<ParkingLot> parkingLotsList) : base(parkingLotsList)
        {
            ParkingLotsList = parkingLotsList;
        }
    }
}