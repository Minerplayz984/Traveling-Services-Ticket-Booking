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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter an airline for the flight: ");
            Console.ResetColor();
            flight.airline = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter an origin destination: ");
            Console.ResetColor();
            flight.origin = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a final destination: ");
            Console.ResetColor();
            flight.destination = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a departure time: ");
            Console.ResetColor();
            flight.departureTime = DateTime.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter an arrival time: ");
            Console.ResetColor();
            DateTime b = DateTime.Parse(Console.ReadLine());
            if (b <= flight.departureTime)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Arrival time must be after departure time !!");
                Console.ResetColor();
                return;
            }
            flight.arrivalTime = b;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a ticket price: ");
            Console.ResetColor();
            flight.price = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter the number of available seats: ");
            Console.ResetColor();
            int e = int.Parse(Console.ReadLine());
            if (e < 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Available seats cannot be negative !!");
                Console.ResetColor();
                return;
            }
            flight.availableSeats = e;
            int ID = new Random().Next(1001,9999);
            flight.flightID = ("FLY"+ID);
            Flight.flights.Add(flight);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight with ID: {0} was successfully added",flight.flightID);
            Console.ResetColor();
        }
        public void updateFlight()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter flight ID for the flight you want to change: ");
            Console.ResetColor();
            string flightID = Console.ReadLine();
            Flight flight = Flight.flights.Find(f=>f.flightID == flightID);
            if (flight == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Flight with this ID might have been cancelled or doesn't exist!!");
                Console.ResetColor();
                return;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=======================================\nWhat do you wanna change?\n1-airline\n2-origin destination\n3-final destination\n4-departureTime\n5-arrivalTime\n6-price\n7-availableSeats\n=======================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choose: ");
            Console.ResetColor();
            Console.Clear();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new airline: ");
                    Console.ResetColor();
                    flight.airline = Console.ReadLine();
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new origin destination: ");
                    Console.ResetColor();
                    flight.origin = Console.ReadLine();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new final destination: ");
                    Console.ResetColor();
                    flight.destination = Console.ReadLine();
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new departure time: ");
                    Console.ResetColor();
                    flight.departureTime = DateTime.Parse(Console.ReadLine());
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new arrival time: ");
                    Console.ResetColor();
                        DateTime b= DateTime.Parse(Console.ReadLine());
                    if(b <= flight.departureTime)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Arrival time must be after departure time !!");
                        Console.ResetColor();
                        return;
                    }
                    flight.arrivalTime = b;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new ticket price: ");
                    Console.ResetColor();
                    flight.price = double.Parse(Console.ReadLine());
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new number of available seats: ");
                    Console.ResetColor();
                    int e = int.Parse(Console.ReadLine());
                    if (e < 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Available seats cannot be negative !!");
                        Console.ResetColor();
                        return;
                    }
                    flight.availableSeats = e;
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose a number between 1 and 7 !!");
                    Console.ResetColor();
                    return;
            }
        }
        public void cancelFlight()
        {
            Console.Clear ();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter flight ID for the flight you want to cancel: ");
            Console.ResetColor();
            string flightID = Console.ReadLine();
            Flight flight = Flight.flights.Find(f => f.flightID == flightID);
            if (flight == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No flight exists with flight ID !!");
                Console.ResetColor();
                return;
            }
            foreach (var flightBooking in FlightBooking.flightBookings.Where(b => b.flight == flight).ToList())
            {
                flightBooking.status = "Cancelled (Flight removed)";
                flightBooking.flight = null;
            }
            Flight.flights.Remove(flight);
            Console.Clear() ;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight with ID: {0} was successfully cancelled", flightID);
            Console.ResetColor();
        }
    }
}
