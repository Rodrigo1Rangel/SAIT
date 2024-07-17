//namespace FlighReservationMS.Data
//{
//    public class Tests
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }

//        [Test]
//        public void Test_DigestFile()
//        {
//            List<Flight> FlightList = Flight.DigestFile();
//            //List<Flight> FlightList = List<Flight>(Flight.DigestFile());
//            string firstFlight = "TB-4017,Try a Bus Airways,ATL,FRA,Monday,18:30,174,1444.00";
//            string expectedFirstFlight = $"{FlightList[0][0]},{FlightList[0][1]},{FlightList[0][2]},{FlightList[0][3]},{FlightList[0][4]},{FlightList[0][5]},{FlightList[0][6]},{FlightList[0][7]}";
//            Assert.Pass(expectedFirstFlight,
//                Is.EqualTo(firstFlight));
//        }
//    }
//}