using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_Services_Ticket_Booking
{
    internal abstract class Person
    {
        private string _name { get; set; }
        private string _email { get; set; }
        private string _phone { get; set; }
        private string _username { get; set; }
        private string _password { get; set; }

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
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
        public string username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public virtual void login()
        {

        }
        public virtual void logout()
        {

        }
    }
}
