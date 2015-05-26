namespace CarParkingOOCamp2015May
{
    public class Car
    {
        public Car(string mCarId)
        {
            m_carId = mCarId;
        }

        public string m_carId { get; private set; }
    }
}