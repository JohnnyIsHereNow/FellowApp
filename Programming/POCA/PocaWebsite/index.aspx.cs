using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PocaWebsite
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceReference1.RandomNumbersClient rc = new ServiceReference1.RandomNumbersClient();
            string s = rc.GetNumber();
            txtUsername.Text = s;
        }
    }
}