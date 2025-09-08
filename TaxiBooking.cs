using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class TaxiBooking : Booking
    {
        public static List<TaxiBooking> taxiBookings = new List<TaxiBooking>();
        private Taxi _taxi;
        private string _pickupLocation;
        private string _dropLocation;
        private string _pickupTime;

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
        public string pickupLocation
        {
            get
            {
                return _pickupLocation;
            }
            set
            {
                _pickupLocation = value;
            }
        }
        public string dropLocation
        {
            get
            {
                return _dropLocation;
            }
            set
            {
                _dropLocation = value;
            }
        }
        public string pickupTime
        {
            get
            {
                return _pickupTime;
            }
            set
            {
                _pickupTime = value;
            }
        }
        public override void confirmBooking(Person customer)
        {
            int ID = new Random().Next(1001, 9999);
            this.bookingID = ("TBK" + ID);
            this.customer = (Customer)customer;
            
            this.date = DateTime.Now;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter pickup location: ");
            Console.ResetColor();
            this.pickupLocation = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter drop location: ");
            Console.ResetColor();
            this.dropLocation = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter pickup time (HH:MM): ");
            Console.ResetColor();
            this.pickupTime = Console.ReadLine();
            if (this.taxi.taxiDriver.schedule.Contains(this.pickupTime))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, this driver is already booked at that time !!");
                Console.ResetColor();
                this.status = "Rejected (Driver unavailable)";
                return;
            }
            this.taxi.taxiDriver.schedule.Add(this.pickupTime);
            this.status = "Confirmed";
            TaxiBooking.taxiBookings.Add(this);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Taxi booking confirmed with ID: {0}",this.bookingID);
            Console.ResetColor();
        }
        public override void cancelBooking(Person customer)
        {
            this.status = "Cancelled";
            this.taxi.taxiDriver.schedule.Remove(this.pickupTime);
            TaxiBooking.taxiBookings.Remove(this);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Taxi booking with ID: {0} was successfully cancelled",this.bookingID);
            Console.ResetColor();
        }
    }
}
