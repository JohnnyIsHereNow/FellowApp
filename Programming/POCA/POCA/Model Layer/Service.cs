using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCA.Model_Layer
{
    class Service
    {
        private string name;
        private string description;
        private float price;
        private bool isAvailable;
        //Properties name
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
        //Properties description
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        //Properties price
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }
        //Properties name
        public bool IsAvailable
        {
            get
            {
                return isAvailable;
            }
            set
            {
                isAvailable = value;
            }
        }
    }
}
