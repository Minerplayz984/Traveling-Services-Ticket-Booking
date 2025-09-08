using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class FlightBooking : Booking
    {
        public static List<FlightBooking> flightBookings = new List<FlightBooking>();
        private Flight _flight { get; set; }
        public Flight flight
        {
            get
            {
                return _flight;
            }
            set
            {
                _flight = value;
            }
        }
        public void generateTicket()
        {
            if (this.status != "Confirmed")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot generate ticket, Booking not confirmed");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("\n==============================\n         FLIGHT TICKET        \n==============================\nBooking ID: {0}\nCustomer name: {1}\nAir line: {8}\nFlight ID: {2}\nFrom: {3}\nTo: {4}\nDeparture time: {5}\nArrival time: {9}\nStatus: {6}\nIssued on: {7}\n==============================\n",this.bookingID,this.customer.name,this.flight.flightID,this.flight.origin,this.flight.destination,this.flight.departureTime,this.status,this.date,this.flight.airline,this.flight.arrivalTime);
            Console.ResetColor();
        }
        public override void confirmBooking(Person customer)
        {
            if (!this.flight.reserveSeat())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Booking failed !, No seats available on flight with ID: {0}",this.flight.flightID);
                Console.ResetColor();
                return;
            }
            this.customer = (Customer)customer;
            this.status = "Confirmed";
            this.date = DateTime.Now;
            int ID = new Random().Next(1001, 9999);
            this.bookingID = ("FBK" + ID);
            FlightBooking.flightBookings.Add(this);
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight booking confirmed with booking ID: {0} on flight with ID: {1}",this.bookingID,this.flight.flightID);
            Console.ResetColor();
        }
        public override void cancelBooking(Person customer)
        {
            
            this.status = "Cancelled";
            if (this.flight != null)
            {
                this.flight.availableSeats += 1;
            }
            FlightBooking.flightBookings.Remove(this);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Flight booking with ID: {0} was successfully cancelled",this.bookingID);
            Console.ResetColor();
        }
    }
}
