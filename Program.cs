using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.Remoting.Services;

namespace Traveling_Services_Ticket_Booking
{
    internal class Program
    {
       public static List<Person> persons = new List<Person>();
       public static void ShowLoginMenu(Person p)
        {
            if (p is Customer)
            {
                Customer customer = (Customer)p;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("=======================================\nCustomer's info:\nName: {0}\nE-mail: {1}\nPhone number: {2}\nUsername: {3}\nPassword: {4}\nCustomer ID: {5}\n=======================================\n", customer.name,customer.email,customer.phone,p.username,customer.password,customer.customerID);
                Console.Write("Actions:\n1-Search for a flight\n2-Book a flight\n3-Book a taxi\n4-Book a hotel room\n5-Check booking status\n6-Cancel taxi booking\n7-Cancel flight booking\n8-Cancel hotel room booking\n9-Generate a flying ticket\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose your action: ");
                Console.ResetColor();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        customer.searchFlights(p);
                        break;
                    case 2:
                        customer.bookFlight(p);
                        break;
                    case 3:
                        customer.bookTaxi(p);
                        break;
                    case 4:
                        customer.bookHotel(p);
                        break;
                    case 5:
                        customer.CheckBookingStatus(p);
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter taxi booking ID to cancel: ");
                        Console.ResetColor();
                        string taxiBookingID = Console.ReadLine();
                        TaxiBooking taxiBooking = TaxiBooking.taxiBookings.Find(tb => tb.bookingID == taxiBookingID && tb.customer == customer);
                        if (taxiBooking == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Booking ID not found or you are not authorized to cancel this booking");
                            Console.ResetColor();
                            return;
                        }
                        taxiBooking.cancelBooking(p);
                        break;
                        case 7:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter flight booking ID to cancel: ");
                        Console.ResetColor();
                        string flightBookingID = Console.ReadLine();
                        FlightBooking flightBooking = FlightBooking.flightBookings.Find(fb => fb.bookingID == flightBookingID && fb.customer == customer);
                        if (flightBooking == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Booking ID not found or you are not authorized to cancel this booking");
                            Console.ResetColor();
                            return;
                        }
                        flightBooking.cancelBooking(p);
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter hotel booking ID to cancel: ");
                        Console.ResetColor();
                        string hotelBookingID = Console.ReadLine();
                        HotelBooking hotelBooking = HotelBooking.hotelBookings.Find(hb => hb.bookingID == hotelBookingID && hb.customer == customer);
                        if (hotelBooking == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Booking ID not found or you are not authorized to cancel this booking");
                            Console.ResetColor();
                            return;
                        }
                        hotelBooking.cancelBooking(p);
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter flight booking ID to generate ticket: ");
                        Console.ResetColor();
                        string flightBookingID2 = Console.ReadLine();
                        FlightBooking flightBooking2 = FlightBooking.flightBookings.Find(fb => fb.bookingID == flightBookingID2 && fb.customer == customer);
                        if (flightBooking2 == null)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Booking ID not found or you are not authorized to generate ticket for this booking");
                            Console.ResetColor();
                            return;
                        }
                        flightBooking2.generateTicket();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choose a number between 1 and 9 !!");
                        Console.ResetColor();
                        break;
                }
            }
            if (p is HotelOwner)
            {
                HotelOwner hotelOwner = (HotelOwner)p;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("=======================================\nHotel owner's info:\nName: {0}\nE-mail: {1}\nPhone number: {2}\nUsername: {3}\nPassword: {4}\nHotel owner ID: {5}\n=======================================\n\n", hotelOwner.name, hotelOwner.email, hotelOwner.phone, hotelOwner.username, hotelOwner.password, hotelOwner.ownerID);
                Console.Write("{0}'s list of hotels:\n",hotelOwner.name);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (Hotel h in hotelOwner.hotelList)
                {
                    Console.WriteLine("=======================================\nHotel name: {0}\tHotel's location: {1}\tHotel's rating: {2}\tHotel's ID: {3}\tNumber of rooms: {4}", h.name,h.location,h.rating,h.hotelID,h.roomList.Count);
                }
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Actions:\n1-Register a hotel\n2-Update hotel details\n3-Remove a hotel\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose your action: ");
                Console.ResetColor();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        hotelOwner.registerHotel();
                        break;
                    case 2:
                        hotelOwner.updateHotelDetails();
                        break;
                    case 3:
                        hotelOwner.removeHotel();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choose a number between 1 and 3 !!");
                        Console.ResetColor();
                        break;
                }
            }
            if (p is TaxiDriver)
            {
                TaxiDriver taxiDriver = (TaxiDriver)p;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("=======================================\nTaxi driver's info:\nName: {0}\nE-mail: {1}\nPhone number: {2}\nUsername: {3}\nPassword: {4}\nDriver ID: {5}\nCar details: {6}\n=======================================\n\n", taxiDriver.name, taxiDriver.email, taxiDriver.phone, taxiDriver.username, taxiDriver.password, taxiDriver.driverID, taxiDriver.carDetails);
                Console.Write("{0}'s schedule list:\n",taxiDriver.name);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta;
                foreach (var t in taxiDriver.schedule)
                {
                    Console.WriteLine(t);
                }
                Console.WriteLine("=======================================");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Actions:\n1-Update availability\n2-Accept a booking\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose your action: ");
                Console.ResetColor();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        taxiDriver.updateAvailability();
                        break;
                    case 2:
                        taxiDriver.acceptBooking();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choose a number between 1 and 2 !!");
                        Console.ResetColor();
                        break;
                }
            }
            if (p is AirlineAdmin)
            {
                AirlineAdmin airlineAdmin = (AirlineAdmin)p;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("=======================================\nAirline admin's info:\nName: {0}\nE-mail: {1}\nPhone number: {2}\nUsername: {3}\nPassword: {4}\nAdmin ID: {5}\nAirline name: {6}\n=======================================\n", airlineAdmin.name, airlineAdmin.email, airlineAdmin.phone, airlineAdmin.username, airlineAdmin.password, airlineAdmin.adminID, airlineAdmin.airlineName);
                Console.Write("Actions:\n1-Add a flight\n2-Update a flight\n3-Cancel a flight\n4-Check Available seats\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose your action: ");
                Console.ResetColor();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        airlineAdmin.addFlight();
                        break;
                    case 2:
                        airlineAdmin.updateFlight();
                        break;
                    case 3:
                        airlineAdmin.cancelFlight();
                        break;
                    case 4:
                        Flight.checkAvailability();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choose a number between 1 and 4 !!");
                        Console.ResetColor();
                        break;
                }
            }
            if (p is SystemAdmin)
            {
                SystemAdmin systemAdmin = (SystemAdmin)p;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("=======================================\nSystem admin's info:\nName: {0}\nE-mail: {1}\nPhone number: {2}\nUsername: {3}\nPassword: {4}\n=======================================\n\n", systemAdmin.name, systemAdmin.email, systemAdmin.phone, systemAdmin.username, systemAdmin.password);
                Console.Write("Actions:\n1-Manage users\n2-Generate reports\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Choose your action: ");
                Console.ResetColor();
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        systemAdmin.manageUsers();
                        break;
                    case 2:
                        systemAdmin.generateReports();
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Choose a number between 1 and 2 !!");
                        Console.ResetColor();
                        break;
                }
            }
        }
        static void ShowRegisterMenu(string username , string password)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("=======================================\nRoles :\n1-Customer\n2-Hotel Owner\n3-Taxi Driver\n4-Airline Admin\n5-System Admin\n=======================================\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;    
            Console.Write("Choose your role: ");
            Console.ResetColor();
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Customer customer = new Customer();
                    customer.username = username;
                    customer.password = password;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter name: ");
                    Console.ResetColor();
                    customer.name= Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter email: ");
                    Console.ResetColor();
                    customer.email = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter phone: ");
                    Console.ResetColor();
                    customer.phone = Console.ReadLine();
                    int ID = new Random().Next(1001, 9999);
                    customer.customerID = ("CUST"+ ID);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registration successful! Your Customer ID is: " + customer.customerID);
                    Console.ResetColor();
                    persons.Add(customer);
                    break;
                case 2:
                    HotelOwner hotelOwner = new HotelOwner();
                    hotelOwner.username = username;
                    hotelOwner.password = password;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter name: ");
                    Console.ResetColor();
                    hotelOwner.name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter email: ");
                    Console.ResetColor();
                    hotelOwner.email = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter phone: ");
                    Console.ResetColor();
                    hotelOwner.phone = Console.ReadLine();
                    int ID2 = new Random().Next(1001, 9999);
                    hotelOwner.ownerID = ("OWN"+ ID2);
                    hotelOwner.hotelList = new List<Hotel>();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registration successful! Your Owner ID is: " + hotelOwner.ownerID);
                    Console.ResetColor();
                    persons.Add(hotelOwner);
                    break;
                case 3:
                    TaxiDriver taxiDriver = new TaxiDriver();
                    taxiDriver.username = username;
                    taxiDriver.password = password;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter name: ");
                    Console.ResetColor();
                    taxiDriver.name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter email: ");
                    Console.ResetColor();
                    taxiDriver.email = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter phone: ");
                    Console.ResetColor();
                    taxiDriver.phone = Console.ReadLine();
                    int ID3 = new Random().Next(1001, 9999);
                    taxiDriver.driverID = ("DRIV"+ ID3);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter car details: ");
                    Console.ResetColor();
                    taxiDriver.carDetails = Console.ReadLine();
                    taxiDriver.schedule = new List<string>();
                    Taxi taxi = new Taxi();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter available time: ");
                    Console.ResetColor();
                    taxi.availableTime = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter price per Km: ");
                    Console.ResetColor();
                    taxi.pricePerKm = double.Parse(Console.ReadLine());
                    taxi.taxiDriver = taxiDriver;
                    taxiDriver.taxi = taxi;
                    Taxi.Taxis.Add(taxi);
                    persons.Add(taxiDriver);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registration successful! Your Driver ID is: " + taxiDriver.driverID);
                    Console.ResetColor();
                    break;
                case 4:
                    AirlineAdmin airlineAdmin = new AirlineAdmin();
                    airlineAdmin.username = username;
                    airlineAdmin.password = password;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter name: ");
                    Console.ResetColor();
                    airlineAdmin.name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter email: ");
                    Console.ResetColor();
                    airlineAdmin.email = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter phone: ");
                    Console.ResetColor();
                    airlineAdmin.phone = Console.ReadLine();
                    int ID4 = new Random().Next(1001, 9999);
                    airlineAdmin.adminID = ("ADM"+ ID4);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter airline name: ");
                    Console.ResetColor();
                    airlineAdmin.airlineName = Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registration successful! Your Admin ID is: " + airlineAdmin.adminID);
                    Console.ResetColor();
                    persons.Add(airlineAdmin);
                    break;
                case 5:
                    SystemAdmin systemAdmin = new SystemAdmin();
                    systemAdmin.username = username;
                    systemAdmin.password = password;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter name: ");
                    Console.ResetColor();
                    systemAdmin.name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter email: ");
                    Console.ResetColor();
                    systemAdmin.email = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Enter phone: ");
                    Console.ResetColor();
                    systemAdmin.phone = Console.ReadLine();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registration successful! You are registered as System Admin.");
                    Console.ResetColor();
                    persons.Add(systemAdmin);
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Choose a number between 1 and 5 !!");
                    Console.ResetColor();
                    Register();
                    break;
            }
        }
        static public void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Person ps = persons.Find(p => p.username == username);
            if (ps == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("username or password are incorrect !!");
                Console.ResetColor();
            }
            else
            {
                if (ps.password == password)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Successfully logged in !");
                    Console.ResetColor();
                    ShowLoginMenu(ps);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("username or password are incorrect !!");
                    Console.ResetColor();
                }
            }
        }
        static public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.Write("Re-enter password: ");
            string rePassword = Console.ReadLine();
            if(password == rePassword)
            {
                Console.Clear();
                ShowRegisterMenu(username,password);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Passwords do not match. Registration failed.");
                Console.ResetColor();
            }
        }
        static public void Menu()
        {
            Console.WriteLine("=======================================\nTraveling Services Ticket Booking System\n=======================================");
            Console.WriteLine("1-Login\n2-Register\n3-Exit");
            Console.WriteLine("=======================================");
            Console.Write("Choose: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Login();
                    break;
                case 2:
                    Console.Clear();
                    Register();
                    break;
                case 3:
                    Environment.Exit(0);
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Choose a number between 1 and 3 !!");
                    break;
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
    }
}
