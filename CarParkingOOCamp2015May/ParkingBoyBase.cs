using System;
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

        public long TotalAvailableSpace()
        {
            long totalAvailableSpace = 0;
            foreach (var PLot in ParkingLotsList)
            {
                totalAvailableSpace += PLot.AvailableSpace();
            }
            return totalAvailableSpace;
        }

        public long TotalSpace()
        {
            long totalSpace = 0;
            foreach (var PLot in ParkingLotsList)
            {
                totalSpace += PLot.ParkingLotSize;
            }
            return totalSpace;
        }

        public string ReportForm()
        {
            var reportForm = String.Format("\n  Boy {0} {1}", TotalAvailableSpace(), TotalSpace());

            foreach (var PLot in ParkingLotsList)
            {
                reportForm += String.Format(
                    "\n    ParkingLot {0} {1}",
                    PLot.AvailableSpace(),
                    PLot.ParkingLotSize);
            }

            return reportForm;
        }
    }
}