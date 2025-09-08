using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class TaxiDriver : Person 
    {
        private string _driverID { get; set; }
        private string _carDetails { get; set; }
        private List<string> _schedule { get; set; }
        private Taxi _taxi { get; set; }

        public string driverID
        {
            get
            {
                return _driverID;
            }
            set
            {
                _driverID = value;
            }
        }
        public string carDetails
        {
            get
            {
                return _carDetails;
            }
            set
            {
                _carDetails = value;
            }
        }
        public List<string> schedule
        {
            get
            {
                return _schedule;
            }
            set
            {
                _schedule = value;
            }
        }
        public Taxi taxi
        {
            get
            {
                return _taxi;
            }
            set
            {
                _taxi = value;
            }
        }
        public void updateAvailability()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter your updated available time: ");
            Console.ResetColor();
            taxi.availableTime= Console.ReadLine();
        }
        public void acceptBooking()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter booking ID to accept: ");
            Console.ResetColor();
            string bookingID = Console.ReadLine();
            TaxiBooking taxiBooking = TaxiBooking.taxiBookings.Find(t => t.bookingID == bookingID);
            if(taxiBooking == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Booking ID not found.");
                Console.ResetColor();
                return;
            }
            if (taxiBooking.taxi.taxiDriver != this)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You are not authorized to accept this booking !!");
                Console.ResetColor();
                return;
            }
            taxiBooking.status = "Accepted";
            Console.Clear() ;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Booking {0} accepted",taxiBooking.bookingID);
            Console.ResetColor();
        }
    }
}
