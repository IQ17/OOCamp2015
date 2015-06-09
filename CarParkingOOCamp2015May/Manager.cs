using System.Collections.Generic;
using System.Linq;

namespace CarParkingOOCamp2015May
{
    public class Manager
    {
        private readonly List<ParkingLot> parkingLotsList;
        private readonly List<ParkingBoyBase> boyList;

        public Manager(List<ParkingLot> parkingLots)
        {
            parkingLotsList = parkingLots;
            boyList = new List<ParkingBoyBase>();
        }

        public Manager(List<ParkingLot> parkingLots, ParkingBoyBase boy) : this(parkingLots)
        {
            this.boyList.Add(boy);
        }

        public Manager(List<ParkingLot> parkingLots, List<ParkingBoyBase> boys) : this(parkingLots)
        {
            boyList = boys;
        }

        public string Park(Car car)
        {
            var ticketTmp = BoyParkAttempt(car);
            if (ticketTmp != null)
            {
                return ticketTmp;
            }

            ticketTmp = ParkingLotParkAttempt(car);
            if (ticketTmp != null)
            {
                return ticketTmp;
            }

            return null;
        }

        private string ParkingLotParkAttempt(Car car)
        {
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
                return pLotWithMaxSpace.Park(car);
            }
            return null;
        }

        private string BoyParkAttempt(Car car)
        {
            if (boyList.Any())
            {
                foreach (var boy in boyList)
                {
                    var ticketTmp = boy.Park(car);
                    if (ticketTmp != null)
                    {
                        return ticketTmp;
                    }
                }
            }
            return null;
        }

        public Car Pick(string ticket)
        {
            Car carTmp = BoyPickAttempt(ticket);
            if (carTmp != null)
            {
                return carTmp;
            }

            carTmp = ParkingLotPickAttempt(ticket);
            if (carTmp != null)
            {
                return carTmp;
            }

            return null;
        }

        private Car ParkingLotPickAttempt(string ticket)
        {
            foreach (var pLot in parkingLotsList)
            {
                var carTmp = pLot.Pick(ticket);
                if (carTmp != null)
                {
                    return carTmp;
                }
            }
            return null;
        }

        private Car BoyPickAttempt(string ticket)
        {
            foreach (var boy in boyList)
            {
                var carTmp = boy.Pick(ticket);
                if (carTmp != null)
                {
                    return carTmp;
                }
            }
            return null;
        }
    }
}