namespace CarParkingOOCamp2015May
{
    public class Director
    {
        public string GetReportForm()
        {
            return parkingLotManager.ReporForm();
        }

        private readonly Manager parkingLotManager;

        public Director(Manager manager)
        {
            parkingLotManager = manager;
        }
    }
}