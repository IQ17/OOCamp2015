using System.Collections.Generic;
using CarParkingOOCamp2015May;
using Xunit;

namespace UnitTestCarParkingOOCamp2015May
{
    public class UnitTestDirector
    {
        [Fact]
        public void Should_Have_Empty_Report_When_Manager_Has_No_ParkingLot_And_No_Boy()
        {
            Manager manager = new Manager(new List<ParkingLot>(), new List<ParkingBoyBase>());
            Director director = new Director(manager);
 
            Assert.Null(director.GetReportForm());
        }

        [Fact]
        public void Should_Have_Report_When_Manager_Has_One_ParkingLot_But_No_Boy()
        {
            Manager manager = new Manager(new List<ParkingLot>{new ParkingLot(size:1)}, new List<ParkingBoyBase>());
            Director director = new Director(manager);

            Assert.Equal("Manager 1 1\n  ParkingLot 1 1", director.GetReportForm());
        }

        [Fact]
        public void Should_Have_Report_When_Manager_Has_Two_ParkingLots_But_No_Boy()
        {
            Manager manager = new Manager(new List<ParkingLot>{new ParkingLot(size:1), new ParkingLot(size:1)}, 
                new List<ParkingBoyBase>());
            Director director = new Director(manager);

            Assert.Equal("Manager 2 2\n  ParkingLot 1 1\n  ParkingLot 1 1", director.GetReportForm());
        }

        [Fact]
        public void Should_Have_Report_When_Manager_Has_One_NoPakingLotBoy_But_No_ParkingLot()
        {
            Manager manager = new Manager(new List<ParkingLot>(), new List<ParkingBoyBase> { new OrdinaryParkingBoy(new List<ParkingLot>()) });
            Director director = new Director(manager);

            Assert.Equal("Manager 0 0\n  Boy 0 0", director.GetReportForm());            
        }

        [Fact]
        public void Should_Have_Report_When_Manager_Has_One_Boy_But_No_ParkingLot()
        {
            Manager manager = new Manager(new List<ParkingLot>(), new List<ParkingBoyBase>{new OrdinaryParkingBoy(new List<ParkingLot>{new ParkingLot(size:1)})});
            Director director = new Director(manager);

            Assert.Equal("Manager 1 1\n  Boy 1 1\n    ParkingLot 1 1", director.GetReportForm());
        }

        [Fact]
        public void Should_Have_Report_When_Manager_Has_Two_Boys_But_No_ParkingLot()
        {
            Manager manager = new Manager(new List<ParkingLot>(), new List<ParkingBoyBase>
            {
                new OrdinaryParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) }),
                new OrdinaryParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) })
            });
            Director director = new Director(manager);

            Assert.Equal("Manager 2 2\n  Boy 1 1\n    ParkingLot 1 1\n  Boy 1 1\n    ParkingLot 1 1", director.GetReportForm());
        }

        [Fact]
        public void Should_Have_Report_When_Manager_Has_One_ParkingLot_And_One_Boy()
        {
            Manager manager = new Manager(
                new List<ParkingLot>
                {
                    new ParkingLot(size:1)
                }, 
                new List<ParkingBoyBase>
                {
                    new OrdinaryParkingBoy(new List<ParkingLot> { new ParkingLot(size: 1) }),
                }
            );
            Director director = new Director(manager);

            Assert.Equal("Manager 2 2\n  ParkingLot 1 1\n  Boy 1 1\n    ParkingLot 1 1", director.GetReportForm());
        }

    }
}