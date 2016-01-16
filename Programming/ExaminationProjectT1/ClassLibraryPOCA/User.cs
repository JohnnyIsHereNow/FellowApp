using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPOCA
{
    class User
    {
        public string firstName { set; get; }
        public string lastName { set; get; }
        public string email { set; get; }
        public string username { set; get; }
        public string password { set; get; }
        public DateTime birthdate { set; get; }
        public string imageURL { set; get; }
    }
}
