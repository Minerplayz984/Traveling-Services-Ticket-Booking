using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal abstract class Booking
    {
        private string _bookingID { get; set; }
        private Customer _customer { get; set; }
        private DateTime _date { get; set; }
        private string _status { get; set; }

        public string bookingID
        {
            get
            {
                return _bookingID;
            }
            set
            {
                _bookingID = value;
            }
        }
        public Customer customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
            }
        }
        public DateTime date
        {
            get
            {
                 return _date;
            }
            set
            {
                 _date = value;
            }
        
        }
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public virtual void confirmBooking(Person p)
        {

        }
        public virtual void cancelBooking(Person customer)
        {

        }
    }
}
