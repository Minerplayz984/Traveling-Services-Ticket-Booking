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
            Console.WriteLine("Enter pickup location: ");
            this.pickupLocation = Console.ReadLine();
            Console.WriteLine("Enter drop location: ");
            this.dropLocation = Console.ReadLine();
            Console.WriteLine("Enter pickup time (HH:MM): ");
            this.pickupTime = Console.ReadLine();
            if (this.taxi.taxiDriver.schedule.Contains(this.pickupTime))
            {
                Console.WriteLine("Sorry, this driver is already booked at that time !!");
                this.status = "Rejected (Driver unavailable)";
                return;
            }
            this.taxi.taxiDriver.schedule.Add(this.pickupTime);
            this.status = "Confirmed";
            TaxiBooking.taxiBookings.Add(this);
            Console.WriteLine("Taxi booking confirmed with ID: {0}",this.bookingID);
        }
        public override void cancelBooking(Person customer)
        {
            this.status = "Cancelled";
            this.taxi.taxiDriver.schedule.Remove(this.pickupTime);
            TaxiBooking.taxiBookings.Remove(this);
            Console.WriteLine("Taxi booking with ID: {0} was successfully cancelled",this.bookingID);
        }
    }
}
