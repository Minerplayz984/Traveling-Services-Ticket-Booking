using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class AirlineAdmin : Person
    {
        private string _adminID;
        private string _airlineName;

        public string adminID
        {
            get
            {
                return _adminID;
            }
            set
            {
                _adminID = value;
            }
        }
        public string airlineName
        {
            get
            {
                return _airlineName;
            }
            set
            {
                _airlineName = value;
            }
        }
        public void addFlight()
        {
            Flight flight = new Flight();
            Console.Write("Enter an airline for the flight: ");
            flight.airline = Console.ReadLine();
            Console.Write("Enter an origin destination: ");
            flight.origin = Console.ReadLine();
            Console.Write("Enter a final destination: ");
            flight.destination = Console.ReadLine();
            Console.Write("Enter a departure time: ");
            flight.departureTime = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter an arrival time: ");
            DateTime b = DateTime.Parse(Console.ReadLine());
            if (b <= flight.departureTime)
            {
                Console.Clear();
                Console.WriteLine("Arrival time must be after departure time !!");
                return;
            }
            flight.arrivalTime = b;
            Console.Write("Enter a ticket price: ");
            flight.price = double.Parse(Console.ReadLine());
            Console.Write("Enter the number of available seats: ");
            int e = int.Parse(Console.ReadLine());
            if (e < 0)
            {
                Console.Clear();
                Console.WriteLine("Available seats cannot be negative !!");
                return;
            }
            flight.availableSeats = e;
            int ID = new Random().Next(1001,9999);
            flight.flightID = ("FLY"+ID);
            Flight.flights.Add(flight);
            Console.WriteLine("Flight with ID: {0} was successfully added",flight.flightID);
        }
        public void updateFlight()
        {
            Console.Write("Enter flight ID for the flight you want to change: ");
            string flightID = Console.ReadLine();
            Flight flight = Flight.flights.Find(f=>f.flightID == flightID);
            if (flight == null)
            {
                Console.Clear();
                Console.WriteLine("Flight with this ID might have been cancelled or doesn't exist!!");
                return;
            }
            Console.WriteLine("=======================================\nWhat do you wanna change?\n1-airline\n2-origin destination\n3-final destination\n4-departureTime\n5-arrivalTime\n6-price\n7-availableSeats\n=======================================");
            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter new airline: ");
                    flight.airline = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new origin destination: ");
                    flight.origin = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter new final destination: ");
                    flight.destination = Console.ReadLine();
                    break;
                case 4:
                    Console.Write("Enter new departure time: ");
                    flight.departureTime = DateTime.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.Write("Enter new arrival time: ");
                        DateTime b= DateTime.Parse(Console.ReadLine());
                    if(b <= flight.departureTime)
                    {
                        Console.Clear();
                        Console.WriteLine("Arrival time must be after departure time !!");
                        return;
                    }
                    flight.arrivalTime = b;
                    break;
                case 6:
                    Console.Write("Enter new ticket price: ");
                    flight.price = double.Parse(Console.ReadLine());
                    break;
                case 7:
                    Console.Write("Enter new number of available seats: ");
                    int e = int.Parse(Console.ReadLine());
                    if (e < 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Available seats cannot be negative !!");
                        return;
                    }
                    flight.availableSeats = e;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Choose a number between 1 and 7 !!");
                    return;
            }
        }
        public void cancelFlight()
        {
            Console.Write("Enter flight ID for the flight you want to cancel: ");
            string flightID = Console.ReadLine();
            Flight flight = Flight.flights.Find(f => f.flightID == flightID);
            if (flight == null)
            {
                Console.Clear();
                Console.WriteLine("No flight exists with flight ID !!");
                return;
            }
            foreach (var flightBooking in FlightBooking.flightBookings.Where(b => b.flight == flight).ToList())
            {
                flightBooking.status = "Cancelled (Flight removed)";
                flightBooking.flight = null;
            }
            Flight.flights.Remove(flight);
            Console.WriteLine("Flight with ID: {0} was successfully cancelled", flightID);
        }
    }
}
