using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class Room
    {
        private string _roomID;
        private string _roomType;
        private double _price;
        private bool _isAvailable;
        public string roomID
        {
            get
            {
                return _roomID;
            }
            set
            {
                _roomID = value;
            }
        }
        public string roomType
        {
            get
            {
                return _roomType;
            }
            set
            {
                _roomType = value;
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
        public bool isAvailable
        {
            get
            {
                return _isAvailable;
            }
            set
            {
                _isAvailable = value;
            }
        }
        public void bookRoom()
        {
            isAvailable = false;
        }
        public void freeRoom()
        {
            isAvailable = true;
        }
    }
}
