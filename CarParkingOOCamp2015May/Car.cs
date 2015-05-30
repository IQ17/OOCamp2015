namespace CarParkingOOCamp2015May
{
    public class Car
    {
        public Car(string carId)
        {
            CarId = carId;
        }

        public string CarId { get; private set; }
    }
}