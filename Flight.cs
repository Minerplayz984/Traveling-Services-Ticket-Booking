using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class Flight
    {
        public static List<Flight> flights = new List<Flight>();
        private string _flightID { get; set; }
        private string _airline { get; set; }
        private string _origin { get; set; }
        private string _destination { get; set; }
        private DateTime _departureTime { get; set; }
        private DateTime _arrivalTime { get; set; }
        private double _price { get; set; }
        private int _availableSeats { get; set; }

        public string flightID
        {
            get
            {
                return _flightID;
            }
            set
            {
                _flightID = value;
            }
        }
        public string airline
        {
            get
            {
                return _airline;
            }
            set
            {
                _airline = value;
            }
        }
        public string origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
            }
        }
        public string destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
            }
        }
        public DateTime departureTime
        {
            get
            {
                return _departureTime;
            }
            set
            {
                _departureTime = value;
            }
        }
        public DateTime arrivalTime
        {
            get
            {
                return _arrivalTime;
            }
            set
            {
                _arrivalTime = value;
            }
        }
        public double price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public int availableSeats
        {
            get
            {
                return _availableSeats;
            }
            set
            {
                _availableSeats = value;
            }
        }

        public static void checkAvailability()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter flight ID: ");
            Console.Clear();
            string id = Console.ReadLine();
            Flight flight = flights.Find(f => f.flightID == id);
            if (flight == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Flight with this ID might have been cancelled or doesn't exist!!");
                Console.ResetColor();
                return;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Available seats for flight ID {0}: {1}", flight.flightID, flight.availableSeats);
            Console.ResetColor();
        }
        public bool reserveSeat()
        {
            if (this.availableSeats > 0)
            {
                this.availableSeats--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
