using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfService.ModelLayer;

public partial class ProfileOfOthers : System.Web.UI.Page
{
    WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
    User user;
    User userme;
    User[] users1, users0;
    protected void Page_Load(object sender, EventArgs e)

        {  user = sr.GetUserByUsername((string)(Session["id"]));
           txtRealName.Text = user.Name;
           txtEmail.Text = user.Email;
           txtUsername.Text = user.Username;
           lbBirthDate.Text = "Birthdate: " + user.Bday.Day+ "/" + user.Bday.Month + "/" + user.Bday.Year;
           Passion1.Text = sr.GetPassionById(user.Passion1);
           Passion2.Text = sr.GetPassionById(user.Passion2);
           Passion3.Text = sr.GetPassionById(user.Passion3);
          if (CheckConnection()==1)
          {
              AddConnection.Text = "Remove Connection";
          }
          else if (CheckConnection()==-1)
          {
              AddConnection.Text = "Add Connection"; 
          }
          else 
          {
              AddConnection.Text = "Accept request";
          }
      //    Response.Write((string)(Session["id"]));
      //    txtUsername.Text = Request.Cookies["userName"].Value;
}

    protected void AddConnection_Click(object sender, EventArgs e)
    {
        int connection = CheckConnection();
        if (connection==1)
        {
            sr.RemoveConnection(userme.Id,user.Id);
        }
        else if (connection == 0)
        {
            sr.CreateConnection(user.Id,userme.Id);
        }
        else if (connection == -1)
        {
            sr.InsertUserConnection(userme.Id,user.Id);
        }
        Response.Redirect("ProfileOfOthers.aspx");
    }
    private int CheckConnection()
    {    
         userme = sr.GetUserByUsername(Request.Cookies["userName"].Value);
         users1 = sr.GetAllConnections1(userme);
         users0 = sr.GetAllConnections0(userme);
        bool found1 = false;
        bool found0 = false;
        int i = 0;

        while (!found1 && i < users1.Length)
        {

            if (users1[i].Username.Equals((string)Session["id"]))
            {
                found1 = true;
            }
            else
            {
                i++;
            }
        }

        i = 0;

        while (!found0 && i < users0.Length)
        {

            if (users0[i].Username.Equals((string)Session["id"]))
            {
                found0 = true;
            }
            else
            {
                i++;
            }
        }
        if (found1) { return 1; }
        else if (found0) {return 0;}
        else {return -1;}
    }
}