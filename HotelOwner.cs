using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class HotelOwner : Person
    {
        private string _ownerID { get; set; }
        private List<Hotel> _hotelList { get; set; }

        public string ownerID
        {
            get
            {
                return _ownerID;
            }
            set
            {
                _ownerID = value;
            }
        }
        public List<Hotel> hotelList
        {
            get
            {
                return _hotelList;
            }
            set
            {
                _hotelList = value;
            }
        }
        public void registerHotel()
        {
            Hotel newHotel = new Hotel();
            int ID = new Random().Next(1001, 9999);
            newHotel.hotelID = ("HOT"+ID);
            Console.WriteLine("Enter Hotel Name: ");
            newHotel.name = Console.ReadLine();
            Hotel ho = Hotel.hotels.Find(h => h.name == newHotel.name);
            if(ho != null)
            {
                Console.Clear();
                Console.WriteLine("Hotel with this name already exists. Registration Failed.");
                return;
            }
            Console.WriteLine("Enter Hotel Location: ");
            newHotel.location = Console.ReadLine();
            Console.WriteLine("Enter Hotel Rating: ");
            newHotel.rating = Convert.ToDouble(Console.ReadLine());
            newHotel.roomList = new List<Room>();
            hotelList.Add(newHotel);
            Hotel.hotels.Add(newHotel);
            Console.WriteLine("Hotel Registered Successfully with ID: {0}",newHotel.hotelID);
        }
        public void updateHotelDetails()
        {
            Console.Write("Enter Hotel ID to update details: ");
            string id = Console.ReadLine();
            Hotel ho = hotelList.Find(h => h.hotelID == id);
            if (ho == null)
            {
                Console.Clear();
                Console.WriteLine("Hotel with this ID does not exist.");
                return;
            }
            Console.Write("=======================================\nWhat do you want to change?\n1 - Hotel Name\n2 - Location\n3 - Rating\n4 - Add Room\n5 - Update Existing Room\n6 - Remove Room\n=======================================\nChoose: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter new Hotel Name: ");
                    string hotelName = Console.ReadLine();
                    if (Hotel.hotels.Any(h => h.name == hotelName && h.hotelID != ho.hotelID))
                    {
                        Console.WriteLine("A hotel with this name already exists !!");
                    }
                    else
                    {
                        ho.name = hotelName;
                        Console.WriteLine("Hotel name updated successfully.");
                    }
                    break;
                case 2:
                    Console.Write("Enter new Location: ");
                    ho.location = Console.ReadLine();
                    Console.WriteLine("Hotel location updated successfully.");
                    break;
                case 3:
                    Console.Write("Enter new Rating: ");
                    ho.rating = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Hotel rating updated successfully.");
                    break;
                case 4:
                    Hotel.addRoom(ho);
                    break;
                case 5:
                    Hotel.updateRoom(ho);
                    break;
                case 6:
                    Console.Write("Enter Room ID to remove: ");
                    string removeRoomID = Console.ReadLine();
                    Room roomToRemove = ho.roomList.Find(r => r.roomID == removeRoomID);
                    if (roomToRemove != null)
                    {
                        string removedID = roomToRemove.roomID;
                        ho.roomList.Remove(roomToRemove);
                        Console.WriteLine("Room with ID: {0} removed successfully",removedID);
                    }
                    else
                    {
                        Console.WriteLine("Room with this ID doesn't exist!!");
                    }
                    break;

                default:
                    Console.WriteLine("Choose a number between 1 and 6 !!");
                    break;
            }
        }

        public void removeHotel()
        {
            Console.Write("Enter Hotel ID to remove: ");
            string id = Console.ReadLine();
            Hotel ho = hotelList.Find(h => h.hotelID == id);
            if(ho == null)
            {
                Console.Clear();
                Console.WriteLine("Hotel with this ID does not exist.");
                return;
            }
            hotelList.Remove(ho);
            Hotel.hotels.Remove(ho);
            Console.WriteLine("Hotel Removed Successfully.");
        }
    }
}
