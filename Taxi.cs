using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class Taxi
    {
        public static List<Taxi> Taxis = new List<Taxi>();
        private string _availableTime;
        private double _pricePerKm;
        private TaxiDriver _taxiDriver;

        public string availableTime
        {
            get
            {
                return _availableTime;
            }
            set
            {
                _availableTime = value;
            }
        }
        public double pricePerKm
        {
            get
            {
                return _pricePerKm;
            }
            set
            {
                _pricePerKm = value;
            }
        }
        public TaxiDriver taxiDriver
        {
            get
            {
                return _taxiDriver;
            }
            set
            {
                _taxiDriver = value;
            }
        }
        public void bookTaxi()
        {
            //in customer.cs
        }
    }
}
