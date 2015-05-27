using System.Collections.Generic;

namespace CarParkingOOCamp2015May
{
    public class Boy
    {
        private List<ParkingLot> m_ParkingLots;

        public Boy()
        {
            m_ParkingLots = new List<ParkingLot>();
        }

        public string Park(Car myCar)
        {
            foreach ( var PLot in m_ParkingLots)
            {
                var ticket = PLot.Park(myCar);
                if (ticket != null)
                {
                    return ticket;
                }
            }
            return null;
        }

        public void Controls(ParkingLot aParkingLot)
        {
            m_ParkingLots.Add(aParkingLot);
        }

        public Car Pick(string ticket)
        {
            foreach (var PLot in m_ParkingLots)
            {
                var car = PLot.Pick(ticket);
                if (car != null)
                {
                    return car;
                }
            }
            return null;
        }
    }
}