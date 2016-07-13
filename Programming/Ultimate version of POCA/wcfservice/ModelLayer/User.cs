using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.ModelLayer
{
    public class User
    {
        private int id;
        private string username;
        private string password;
        private string email;
        private string name;
        private int passion1;
        private int passion2;
        private int passion3;
        private string passion1String;
        private string passion2String;
        private string passion3String;
        private DateTime bday;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Passion1
        {
            get
            {
                return passion1;
            }

            set
            {
                passion1 = value;
            }
        }

        public int Passion2
        {
            get
            {
                return passion2;
            }

            set
            {
                passion2 = value;
            }
        }

        public int Passion3
        {
            get
            {
                return passion3;
            }

            set
            {
                passion3 = value;
            }
        }

        public string Passion1String
        {
            get
            {
                return passion1String;
            }

            set
            {
                passion1String = value;
            }
        }

        public string Passion2String
        {
            get
            {
                return passion2String;
            }

            set
            {
                passion2String = value;
            }
        }

        public string Passion3String
        {
            get
            {
                return passion3String;
            }

            set
            {
                passion3String = value;
            }
        }
        public DateTime Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
    }
}