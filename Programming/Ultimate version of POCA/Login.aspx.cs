using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["userName"] != null)
        {
            Response.Redirect("Search.aspx");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!(txtUsername.Text.Equals("") || txtPassword.Equals("")))
        {
            WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
            if(sr.LoginUser(txtUsername.Text, txtPassword.Text))
            {
                Response.Cookies["userName"].Value = txtUsername.Text;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);

                HttpCookie aCookie = new HttpCookie("lastVisit");
                aCookie.Value = DateTime.Now.ToString();
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);
                //Response.Write(txtUsername.Text);
                Response.Redirect("Search.aspx");
                lblMsg.Text = "Logged in.";
            }
            else
            {
                lblMsg.Text = "Wrong username and/or password. Please try again.";
            }
        }
        else
        {
            lblMsg.Text = "Fields cannot be empty.";
        }
    }
}