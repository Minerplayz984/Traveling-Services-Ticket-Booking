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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Hotel Name: ");
            Console.ResetColor();
            newHotel.name = Console.ReadLine();
            Hotel ho = Hotel.hotels.Find(h => h.name == newHotel.name);
            if(ho != null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hotel with this name already exists. Registration Failed.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Hotel Location: ");
            Console.ResetColor();
            newHotel.location = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter Hotel Rating: ");
            Console.ResetColor();
            newHotel.rating = Convert.ToDouble(Console.ReadLine());
            newHotel.roomList = new List<Room>();
            hotelList.Add(newHotel);
            Hotel.hotels.Add(newHotel);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hotel Registered Successfully with ID: {0}",newHotel.hotelID);
            Console.ResetColor();
        }
        public void updateHotelDetails()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Hotel ID to update details: ");
            Console.ResetColor();
            string id = Console.ReadLine();
            Hotel ho = hotelList.Find(h => h.hotelID == id);
            if (ho == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hotel with this ID does not exist.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("=======================================\nWhat do you want to change?\n1 - Hotel Name\n2 - Location\n3 - Rating\n4 - Add Room\n5 - Update Existing Room\n6 - Remove Room\n=======================================\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choose: ");
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new Hotel Name: ");
                    Console.ResetColor();
                    string hotelName = Console.ReadLine();
                    if (Hotel.hotels.Any(h => h.name == hotelName && h.hotelID != ho.hotelID))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("A hotel with this name already exists !!");
                        Console.ResetColor();
                    }
                    else
                    {
                        ho.name = hotelName;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Hotel name updated successfully.");
                        Console.ResetColor();
                    }
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new Location: ");
                    Console.ResetColor();
                    ho.location = Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hotel location updated successfully.");
                    Console.ResetColor();
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter new Rating: ");
                    Console.ResetColor();
                    ho.rating = Convert.ToDouble(Console.ReadLine());
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Hotel rating updated successfully !");
                    Console.ResetColor();
                    break;
                case 4:
                    Hotel.addRoom(ho);
                    break;
                case 5:
                    Hotel.updateRoom(ho);
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter Room ID to remove: ");
                    Console.ResetColor();
                    string removeRoomID = Console.ReadLine();
                    Room roomToRemove = ho.roomList.Find(r => r.roomID == removeRoomID);
                    if (roomToRemove != null)
                    {
                        string removedID = roomToRemove.roomID;
                        ho.roomList.Remove(roomToRemove);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Room with ID: {0} removed successfully",removedID);
                        Console.Clear();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Room with this ID doesn't exist!!");
                        Console.ResetColor();
                    }
                    break;

                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose a number between 1 and 6 !!");
                    Console.ResetColor();
                    break;
            }
        }

        public void removeHotel()
        {
            Console.Clear() ;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter Hotel ID to remove: ");
            Console.ResetColor();
            string id = Console.ReadLine();
            Hotel ho = hotelList.Find(h => h.hotelID == id);
            if(ho == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hotel with this ID does not exist.");
                Console.ResetColor();
                return;
            }
            hotelList.Remove(ho);
            Hotel.hotels.Remove(ho);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hotel Removed Successfully.");
            Console.ResetColor();
        }
    }
}
