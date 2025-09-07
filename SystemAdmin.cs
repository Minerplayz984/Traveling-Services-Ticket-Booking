using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal class SystemAdmin : Person
    {
        public void manageUsers()
        {
            Console.WriteLine("=======================================\nManage users:\n1-Delete a user\n2-Change a password\n3-List all users\n=======================================");
            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter username of the user you want to delete: ");
                    string username = Console.ReadLine();
                    Person person = Program.persons.Find(p => p.username == username);
                    if ((person == null)||(person is SystemAdmin) )
                    {
                        Console.Clear();
                        Console.WriteLine("User doesn't exist or maybe a system admin!!");
                        return;
                    }
                    Program.persons.Remove(person);
                    Console.WriteLine("User with username: {0} was successfully deleted", username);
                    break;
                    case 2:
                    Console.Write("Enter username of the user you want to change password: ");
                    string usern = Console.ReadLine();
                    Person per = Program.persons.Find(p => p.username == usern);
                    if (per == null)
                    {
                        Console.Clear();
                        Console.WriteLine("User doesn't exist!!");
                        return;
                    }
                    Console.Write("Enter new password: ");
                    per.password = Console.ReadLine();
                    Console.WriteLine("Password was successfully changed for user with username: {0}", usern);
                    break;
                    case 3:
                    Console.WriteLine("List of all users:");
                    foreach (Person p in Program.persons)
                    {
                        if(p is SystemAdmin) continue; 
                        if (p is Customer)
                        {
                            Customer customer = (Customer)p;
                            Console.WriteLine("=======================================\nCustomer {0} \nCustomer ID: {4}\nName: {0}\nEmail: {1}\nPhone: {2}\nUsername: {3}\n", customer.name, customer.email, customer.phone, customer.username,customer.customerID);
                        }
                        if (p is HotelOwner)
                        {
                            HotelOwner hotelOwner = (HotelOwner)p;
                            Console.WriteLine("=======================================\nHotel Owner {0} \nOwner ID: {4}\nName: {0}\nEmail: {1}\nPhone: {2}\nUsername: {3}\n", hotelOwner.name, hotelOwner.email, hotelOwner.phone, hotelOwner.username, hotelOwner.ownerID);
                        }
                        if (p is TaxiDriver)
                        {
                            TaxiDriver taxiDriver = (TaxiDriver)p;
                            Console.WriteLine("=======================================\nTaxi Driver {0} \nDriver ID: {4}\nName: {0}\nEmail: {1}\nPhone: {2}\nUsername: {3}\nCar details: {5}\n",taxiDriver.name,taxiDriver.email,taxiDriver.phone,taxiDriver.username,taxiDriver.driverID,taxiDriver.carDetails);
                        }
                        if (p is AirlineAdmin)
                        {
                            AirlineAdmin airlineAdmin = (AirlineAdmin)p;
                            Console.WriteLine("=======================================\nAirline Admin {0} \nAdmin ID: {4}\nName: {0}\nEmail: {1}\nPhone: {2}\nUsername: {3}\n", airlineAdmin.name, airlineAdmin.email, airlineAdmin.phone, airlineAdmin.username, airlineAdmin.adminID);
                        }
                    }
                    break;
            }
        }
        public void generateReports()                                                                                                                                                                                                                                                                                               
        {
            long customers = 0;
            long hotelOwners =0;
            long taxiDrivers = 0;
            long airlineAdmins = 0;
            foreach (var p in Program.persons)
            {
                if (p is Customer)
                {
                    customers++;
                }
                if (p is HotelOwner)
                {
                    hotelOwners++;
                }
                if (p is TaxiDriver)
                {
                    taxiDrivers++;
                }
                if (p is AirlineAdmin)
                {
                    airlineAdmins++;
                }
            }
            Console.WriteLine("=======================================\nSystem Report:\nTotal customers: {0}\nTotal hotel owners: {1}\nTotal hotels: {2}\nTotal taxi drivers: {3}\nTotal airline admins: {4}\nTotal flights: {5}\nHotel bookings: {6}\nTaxi bookings: {7}\nFlight bookings {8}\n=======================================",customers,hotelOwners,Hotel.hotels.Count,taxiDrivers,airlineAdmins,Flight.flights.Count,HotelBooking.hotelBookings.Count,TaxiBooking.taxiBookings.Count,FlightBooking.flightBookings.Count);
        }
    }
}
