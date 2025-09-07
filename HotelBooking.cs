using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class HotelBooking : Booking
    {
        public static List<HotelBooking> hotelBookings = new List<HotelBooking>();
        private Room _room { get; set; }
        private Hotel _hotel { get; set; }
        private DateTime _checkInDate { get; set; }
        private DateTime _checkOutDate { get; set; }
        public Room room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
            }
        }
        public DateTime checkInDate
        {
            get
            {
                return _checkInDate;
            }
            set
            {
                _checkInDate = value;
            }
        }
        public DateTime checkOutDate
        {
            get
            {
                return _checkOutDate;
            }
            set
            {
                _checkOutDate = value;
            }
        }
        public Hotel hotel
        {
            get
            {
                return _hotel;
            }
            set
            {
                _hotel = value;
            }
        }
        public override void confirmBooking(Person p)
        {
            this.customer = (Customer)p;
            this.room.bookRoom();
            this.status = "Confirmed";
            this.date = DateTime.Now;
            Console.WriteLine("Enter check-in date (yyyy-mm-dd): ");
            this.checkInDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter check-out date (yyyy-mm-dd): ");
            this.checkOutDate = DateTime.Parse(Console.ReadLine());
            int ID = new Random().Next(1001, 9999);
            this.bookingID = ("HBK" + ID);
            HotelBooking.hotelBookings.Add(this);
            Console.WriteLine("Hotel booking confirmed with ID: {0}", this.bookingID);
        }
        public override void cancelBooking(Person customer)
        {
            HotelBooking.hotelBookings.Remove(this);
            this.status = "Cancelled";
            this.room.freeRoom();
            Console.WriteLine("Hotel booking with ID: {0} was successfully cancelled", this.bookingID);
        }

    }
}
