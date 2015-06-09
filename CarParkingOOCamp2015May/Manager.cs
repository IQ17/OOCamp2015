using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class Manager
    {
        private readonly List<ParkingLot> parkingLotsList;
        private readonly List<OrdinaryParkingBoy> ordinaryBoyList;
        private readonly List<SmartParkingBoy> smartBoyList;
        private readonly List<SuperParkingBoy> superBoyList;
        private readonly List<ParkingBoyBase> boyList;

        public Manager(List<ParkingLot> parkingLots)
        {
            parkingLotsList = parkingLots;
            ordinaryBoyList = new List<OrdinaryParkingBoy>();
            smartBoyList = new List<SmartParkingBoy>();
            superBoyList = new List<SuperParkingBoy>();
        }

        public Manager(List<ParkingLot> parkingLots, OrdinaryParkingBoy boy) : this(parkingLots)
        {
            this.ordinaryBoyList.Add(boy);
        }

        public Manager(List<ParkingLot> parkingLots, List<OrdinaryParkingBoy> ordinaryParkingBoys):this(parkingLots)
        {
            ordinaryBoyList = ordinaryParkingBoys;
        }

        public Manager(List<ParkingLot> parkingLots, SmartParkingBoy boy):this(parkingLots)
        {
            this.smartBoyList.Add(boy);
        }

        public Manager(List<ParkingLot> parkingLots, List<SmartParkingBoy> smartParkingBoys) : this(parkingLots)
        {
            smartBoyList = smartParkingBoys;
        }

        public Manager(List<ParkingLot> parkingLots, SuperParkingBoy boy)
            : this(parkingLots)
        {
            this.superBoyList.Add(boy);
        }

        public Manager(List<ParkingLot> parkingLots, List<SuperParkingBoy> superParkingBoys)
            : this(parkingLots)
        {
            superBoyList = superParkingBoys;
        }

        public Manager(List<ParkingLot> parkingLots, List<ParkingBoyBase> boys) : this(parkingLots)
        {
            boyList = boys;
        }

        public string Park(Car car)
        {
            string ticketTmp = null;

            if (boyList.Any())
            {
                foreach (var boy in boyList)
                {
                    ticketTmp = boy.Park(car);
                    if (ticketTmp != null)
                    {
                        return ticketTmp;
                    }
                }
            }

            if (parkingLotsList.Any())
            {
                var pLotWithMaxSpace = parkingLotsList[0];
                foreach (var pLot in parkingLotsList)
                {
                    if (pLot.AvailableSpace() > pLotWithMaxSpace.AvailableSpace())
                    {
                        pLotWithMaxSpace = pLot;
                    }
                }
                ticketTmp = pLotWithMaxSpace.Park(car);
                if (ticketTmp != null)
                {
                    return ticketTmp;
                }
            }

            if (ordinaryBoyList.Any())
            {
                foreach (var ordinaryBoy in ordinaryBoyList)
                {
                    ticketTmp = ordinaryBoy.Park(car);
                    if (ticketTmp != null)
                    {
                        return ticketTmp;
                    }
                }
            }
            
            if(smartBoyList.Any())
            {
                foreach (var smartBoy in smartBoyList)
                {
                    ticketTmp = smartBoy.Park(car);
                    if (ticketTmp != null)
                    {
                        return ticketTmp;
                    }
                }
            }
            
            if (superBoyList.Any())
            {
                foreach (var superBoy in superBoyList)
                {
                    ticketTmp = superBoy.Park(car);
                    if (ticketTmp != null)
                    {
                        return ticketTmp;
                    }
                }
            }
            return ticketTmp;
        }

        public Car Pick(string ticket)
        {
            Car carTmp = null;

            foreach (var boy in boyList)
            {
                carTmp = boy.Pick(ticket);
                if (carTmp != null)
                {
                    return carTmp;
                }
            }

            foreach (var ordinaryParkingBoy in ordinaryBoyList)
            {
                carTmp = ordinaryParkingBoy.Pick(ticket);
                if (carTmp != null)
                {
                    return carTmp;
                }
            }

            foreach (var smartParkingBoy in smartBoyList)
            {
                carTmp = smartParkingBoy.Pick(ticket);
                if (carTmp != null)
                {
                    return carTmp;
                }
            }

            foreach (var superParkingBoy in superBoyList)
            {
                carTmp = superParkingBoy.Pick(ticket);
                if (carTmp != null)
                {
                    return carTmp;
                }
            }

            foreach (var pLot in parkingLotsList)
            {
                carTmp = pLot.Pick(ticket);
                if (carTmp != null)
                {
                    return carTmp;
                }
            }
            return carTmp;
        }
    }
}