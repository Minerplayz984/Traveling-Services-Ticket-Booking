using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class Hotel
    {
        public static List<Hotel> hotels = new List<Hotel>();
        private string _hotelID { get; set; }
        private string _name { get; set;}
        private string _location { get; set; }
        private double _rating { get; set; }
        private List<Room> _roomList { get; set; }
        public string hotelID
        {
            get
            {
                return _hotelID;
            }
            set
            {
                _hotelID = value;
            }
        }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
        public double rating
        {
            get
            {
                return _rating;
            }
            set
            {
                _rating = value;
            }
        }
        public List<Room> roomList
        {
            get
            {
                return _roomList;
            }
            set
            {
                _roomList = value;
            }
        }

        public static void addRoom(Hotel ho)
        {
            Room newRoom = new Room();
            int ID = new Random().Next(1001, 9999);
            newRoom.roomID = ("ROM" + ID);
            Console.Write("Enter Room Type: ");
            newRoom.roomType = Console.ReadLine();
            Console.Write("Enter Price: ");
            newRoom.price = Convert.ToDouble(Console.ReadLine());
            newRoom.isAvailable = true;
            ho.roomList.Add(newRoom);
            Console.WriteLine("Room with ID: {0} added successfully.", newRoom.roomID);
        }
        public static void updateRoom(Hotel ho)
        {
            Console.Write("Enter Room ID to update: ");
            string updateRoomID = Console.ReadLine();
            Room roomToUpdate = ho.roomList.Find(r => r.roomID == updateRoomID);
            if (roomToUpdate == null)
            {
                Console.WriteLine("Room with this ID doesn't exist!!");
                return;
            }
            Console.Write("=======================================\nWhat do you want to change?\n1-Room Type\n2-Price\n3-Availability\n=======================================\nChoose: ");
            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    Console.Write("Enter new Room Type: ");
                    roomToUpdate.roomType = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new Price: ");
                    roomToUpdate.price = Convert.ToDouble(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Enter Availability (true/false): ");
                    roomToUpdate.isAvailable = Convert.ToBoolean(Console.ReadLine());
                    break;
            }
            Console.WriteLine("Room with ID: {0} updated successfully.", roomToUpdate.roomID);
        }
        public static void getAvailableRooms(Hotel ht)
        {
            Console.WriteLine("Rooms:");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var room in ht.roomList)
            {
                if (room.isAvailable == false)
                {
                    continue;
                }
                Console.WriteLine("=======================================\nRoom ID: {0}\nRoom type: {1}\nPrice: {2}\nisAvailable: {3}\n", room.roomID, room.roomType, room.price, room.isAvailable);
            }
        }
    }
}
