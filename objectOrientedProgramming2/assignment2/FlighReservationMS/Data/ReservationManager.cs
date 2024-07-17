using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
#pragma warning disable SYSLIB0011


namespace FlighReservationMS.Data
{
    public class ReservationManager
    {

        // =====================================  INSTANCE FIELDS =====================================
        static private List<Reservation> _reservationList = new List<Reservation>();
        static private List<string> _reservationCodeList = new List<string>();

        // =======================================  PROPERTIES =======================================
        static public List<Reservation> ReservationList { get { return _reservationList; } set { _reservationList = value; } }
        static public List<string> ReservationCodeList { get { return _reservationCodeList; } set { _reservationCodeList = value; } }

        // =========================================  METHODS  ========================================
        public static async Task WriteReservationListToFile()
        {
            // SERIALIZATION
            var contents = JsonSerializer.Serialize(ReservationList);
            var path = Path.Combine(FileSystem.AppDataDirectory, "ReservationList.json");
            // to do: attempt to change to the output folder
            File.WriteAllText(path, contents);

            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            //{

            //}
            await App.Current.MainPage.DisplayAlert("Reservation Saved", $"List of reservations has been saved to {path}", "OK");

            LoadReservationListFromFile();
        }
        public static void LoadReservationListFromFile()
        {
            // DESERIALIZATION
            var path = Path.Combine(FileSystem.AppDataDirectory, "ReservationList.json");
            if (!File.Exists(path))
                return;
            var contents = File.ReadAllText(path);
            var savedItems = JsonSerializer.Deserialize<List<Reservation>>(contents);
            ReservationList.Clear();
            ReservationList.AddRange(savedItems);
        }
       
        public static Reservation? searchReservation(
            string flightCode,
            string airline,
            string name)
        {
            Reservation matchingReservation = null;

            for (int i = 0; i < ReservationList.Count; i++)
            {
                if (ReservationList[i].FlightCode == flightCode &&
                    ReservationList[i].Airline == airline &&
                    ReservationList[i].Name == name)
                {
                    matchingReservation = ReservationList[i];
                }
            }
            if (matchingReservation == null)
                AlertNoReservationFound();
            return matchingReservation;
        }
        public static async Task AlertNoReservationFound()
        {
            await App.Current.MainPage.DisplayAlert("No Reservation Found", $"There is no matching reservation record in the system.", "OK");
        }

        public static string GenerateReservationCode()
        {
            string newReservationCode;
            Random randomCode = new Random();
            do
            {
                // Generate 4 random digits
                int randomDigits = randomCode.Next(9999);

                // Generate a random character
                string alphabet = "ABCDEFGHIJKLMNOPQRSTYVWXYZ";
                int randomLetterIndex = randomCode.Next(alphabet.Length);
                char randomChar = alphabet[randomLetterIndex];

                string reservationCode = Char.ToString(randomChar) + randomDigits;
                newReservationCode = reservationCode;
                
                // In case the new random reservation code matches an existing one,
                // We will generate another one.
            } while (ReservationCodeList.Contains(newReservationCode));
            ReservationCodeList.Add(newReservationCode);

            return newReservationCode;
        }
    }
}