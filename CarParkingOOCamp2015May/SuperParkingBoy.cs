using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class SuperParkingBoy
    {
        private readonly List<ParkingLot> parkingLotsList;

        public SuperParkingBoy(List<ParkingLot> parkingLotsList)
        {
            this.parkingLotsList = parkingLotsList;
        }

        public string Park(Car aCar)
        {
            if (parkingLotsList.Count == 0)
            {
                return null;
            }

            var pLotWithHighestVacancyRate = parkingLotsList[0];
            foreach (var pLot in parkingLotsList) 
            {
                if (pLot.VacancyRate() > pLotWithHighestVacancyRate.VacancyRate())
                {
                    pLotWithHighestVacancyRate = pLot;
                }
            }

            return pLotWithHighestVacancyRate.Park(aCar);
        }

        public Car Pick(string ticket)
        {
            return parkingLotsList.Select(pLot => pLot.Pick(ticket))
                .FirstOrDefault(car => car != null);
        }
    }
}