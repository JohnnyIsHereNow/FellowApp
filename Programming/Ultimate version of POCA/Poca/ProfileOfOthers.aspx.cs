using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProfileOfOthers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
            //passion1.Items.Clear();
            //passion2.Items.Clear();
            //passion3.Items.Clear();

            foreach (string s in sr.GetAllPassions())
            {
            //    passion1.Items.Add(s);
            //    passion2.Items.Add(s);
            //    passion3.Items.Add(s);
            }
        }
        txtUsername.Text = Request.Cookies["userName"].Value;
    }

    protected void AddConnection_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}