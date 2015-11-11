using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace POCA.Model_Layer
{
    class User
    {
        private string firstName, lastName, email, username, password;
        private DateTime birthDate;
        private List<int> passionId;
        private List<int> serviceId;

        //methods
        public int GetPassionId(int id)
        {
            for (int i = 0; i < passionId.Count; i++)
            {
                if(passionId[i]== id)
                {
                    return passionId.ElementAt(i);
                }
            }
            return -1;
        }

        public void AddPassionId(int id)
        {
            passionId.Add(id);
        }

        public void RemovePassionId(int id)
        {
          passionId.Remove(id);
        }

        //methods
        public int GetServiceId(int id)
        {
            for (int i = 0; i < serviceId.Count; i++)
            {
                if (serviceId[i] == id)
                {
                    return serviceId.ElementAt(i);
                }
            }
            return -1;
        }

        public void AddServiceId(int id)
        {
            serviceId.Add(id);
        }

        public void RemoveServiceId(int id)
        {
            serviceId.Remove(id);
        }
        //properties
        public List<int> PassionId
        {
            get
            {
                return passionId;
            }
            set
            {
                passionId = value;
            }
        }
        //properties
        public List<int> ServiceId
        {
            get
            {
                return serviceId;
            }
            set
            {
                serviceId = value;
            }
        }

        //Properties
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        //Properties
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        //Properties
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
        //Properties
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
        //Properties
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
        } //Properties
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }


    }
}
