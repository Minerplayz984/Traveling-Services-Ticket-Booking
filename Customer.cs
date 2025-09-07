using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class Customer : Person
    {
        private string _customerID { get; set; }

        public string customerID
        {
            get
            {
                return _customerID;
            }
            set
            {
                _customerID = value;
            }
        }
        public void searchFlights(Person p)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var flight in Flight.flights)
            {
                Console.WriteLine("=======================================\nFlight ID: {0}\n\nAirline: {1}\nOrigin: {2}\nDestination: {3}\nDeparture time: {4}\nArrival time: {5}\nPrice: {6}\nAvailable seats: {7}",flight.flightID,flight.airline,flight.origin,flight.destination,flight.departureTime,flight.arrivalTime,flight.price,flight.availableSeats);
            }
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press any key to return back to customer menu . . .");
            Console.ResetColor();
            Console.ReadKey();
            Program.ShowLoginMenu(p);
            return;
        }
        public void bookFlight(Person p)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a flight ID to book: ");
            Console.ResetColor();
            string flightID = Console.ReadLine();
            Flight fs = Flight.flights.Find(f => f.flightID == flightID);
            if (fs == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Flight might have been cancelled or doesn't exist!!");
                Console.ResetColor();
                Program.ShowLoginMenu(p);
                return;
            }
            if (fs.availableSeats<=0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no seats in this flight");
                Console.ResetColor();
                Program.ShowLoginMenu(p);
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=======================================\nFlight ID: {0}\n\nAirline: {1}\nOrigin: {2}\nDestination: {3}\nDeparture time: {4}\nArrival time: {5}\nPrice: {6}\nAvailable seats: {7}\n=======================================\n", fs.flightID, fs.airline, fs.origin, fs.destination, fs.departureTime, fs.arrivalTime, fs.price, fs.availableSeats);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Are you sure you want to book this flight ? (y / n): ");
                Console.ResetColor();
                string key = Console.ReadLine();
                if (key == "y")
                {
                    Console.Clear();
                    FlightBooking flightBooking = new FlightBooking();
                    flightBooking.flight = fs;
                    flightBooking.confirmBooking(p);
                }
                else if(key == "n")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Returning back to login menu . . .");
                    Console.ResetColor();
                    Program.ShowLoginMenu(p);
                    return;
                }
            }
        }
        public void bookTaxi(Person p)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a taxi driver ID to book: ");
            Console.ResetColor();
            string taxiID = Console.ReadLine();
            Taxi tx = Taxi.Taxis.Find(t => t.taxiDriver.driverID == taxiID);
            if (tx == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Taxi ride exists with this Taxi ID !!");
                Console.ResetColor();
                Program.ShowLoginMenu(p);
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=======================================\nTaxi ride ID: {0}\nDriver: {1}\nAvailable time: {2}\nPrice per Km: {3}\n=======================================\n", tx.taxiDriver.driverID, tx.taxiDriver.name, tx.availableTime, tx.pricePerKm);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Are you sure you want to book this taxi? (y/n): ");
                Console.ResetColor();
                string key = Console.ReadLine();
                if (key == "y")
                {
                    Console.Clear();
                    TaxiBooking taxiBooking = new TaxiBooking();
                    taxiBooking.taxi = tx;
                    taxiBooking.confirmBooking(p);
                }
                else if (key == "n")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Returning back to login menu . . .");
                    Console.ResetColor();
                    Program.ShowLoginMenu(p);
                    return;
                }
            }
        }
        public void bookHotel(Person p)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a hotel ID to book: ");
            Console.ResetColor();
            string hotelID = Console.ReadLine();
            Hotel ht = Hotel.hotels.Find(h => h.hotelID == hotelID);
            if (ht == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Hotel exists with this hotel ID !!");
                Console.ResetColor();
                Program.ShowLoginMenu(p);
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=======================================\nHotel ID: {0}\nHotel name: {1}\nLocation: {2}\nRating: {3}\n=======================================\n", ht.hotelID, ht.name, ht.location, ht.rating);
                Hotel.getAvailableRooms(ht);
                Console.WriteLine("=======================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Do you want to book a room from the above? (y / n): ");
                Console.ResetColor();
                string key = Console.ReadLine();
                if (key == "y")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter a room ID to book: ");
                    Console.ResetColor();
                    string roomID = Console.ReadLine();
                    Room rm = ht.roomList.Find(r => r.roomID == roomID);
                    if (rm == null)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No room exists with this room ID !!");
                        Console.ResetColor();
                        return;
                    }
                    else if (rm.isAvailable == false)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This room is not available for booking !!");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        HotelBooking hotelBooking = new HotelBooking();
                        hotelBooking.room = rm;
                        hotelBooking.hotel = ht;
                        hotelBooking.confirmBooking(p);
                    }
                }
                else if(key == "n")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Returning back to login menu . . .");
                    Console.ResetColor();
                    Program.ShowLoginMenu(p);
                }
            }
        }
        public void CheckBookingStatus(Person p)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("1-Flight booking\n2-Taxi ride booking\n3-Hotel room booking\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choose: ");
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Your flight booking ID:");
                    Console.ResetColor();
                    string fbID = Console.ReadLine();
                    FlightBooking fb = FlightBooking.flightBookings.Find(f => f.bookingID == fbID && f.customer.username == p.username);
                    if (fb == null)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No flight booking exists with this booking ID !!");
                        Console.ResetColor();
                        return;
                    }
                    else if (fb.status == "Cancelled (Flight removed)")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("This booking was cancelled because the flight was removed by the airline !!");
                        Console.ResetColor();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("=======================================\nFlight Booking ID: {0}\nCustomer: {1}\nFlight ID: {2}\nAirline: {3}\nOrigin: {4}\nDestination: {5}\nDeparture time: {6}\nArrival time: {7}\nPrice: {8}\nBooking Status: {9}\n=======================================", fb.bookingID, fb.customer.name, fb.flight.flightID, fb.flight.airline, fb.flight.origin, fb.flight.destination, fb.flight.departureTime, fb.flight.arrivalTime, fb.flight.price, fb.status);
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.Write("Your taxi booking ID:");
                    string tbID = Console.ReadLine();
                    TaxiBooking tb = TaxiBooking.taxiBookings.Find(t => t.bookingID == tbID && t.customer.username == p.username);
                    if (tb == null)
                    {
                        Console.Clear();
                        Console.WriteLine("No taxi booking exists with this booking ID !!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("=======================================\nTaxi Booking ID: {0}\nCustomer: {1}\nDriver ID: {2}\nDriver Name: {3}\nAvailable time: {4}\nPrice per Km: {5}\nBooking Status: {6}\n=======================================", tb.bookingID, tb.customer.name, tb.taxi.taxiDriver.driverID, tb.taxi.taxiDriver.name, tb.taxi.availableTime, tb.taxi.pricePerKm, tb.status);
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.Write("Your hotel booking ID:");
                    string hbID = Console.ReadLine();
                    HotelBooking hb = HotelBooking.hotelBookings.Find(h => h.bookingID == hbID && h.customer.username == p.username);
                    if (hb == null)
                    {
                        Console.Clear();
                        Console.WriteLine("No hotel booking exists with this booking ID !!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("=======================================\nHotel Booking ID: {0}\nCustomer: {1}\nHotel ID: {2}\nHotel name: {3}\nRoom ID: {4}\nRoom type: {5}\nPrice: {6}\nBooking Status: {7}\n=======================================", hb.bookingID, hb.customer.name, hb.hotel.hotelID, hb.hotel.name, hb.room.roomID, hb.room.roomType, hb.room.price, hb.status);
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Choose a number between 1 and 3 !!");
                    Program.ShowLoginMenu(p);
                    break;
            }
        }
    }
}
