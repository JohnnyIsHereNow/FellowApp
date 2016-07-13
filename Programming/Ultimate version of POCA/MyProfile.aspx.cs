using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfService.ModelLayer;
public partial class MyProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
        WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
            passion1.Items.Clear();
            passion2.Items.Clear();
            passion3.Items.Clear();
            foreach (string s in sr.GetAllPassions())
        {
            passion1.Items.Add(s);
            passion2.Items.Add(s);
            passion3.Items.Add(s);
        }
            for(int i = 1; i <= 31; i++)
            {
                daysDb.Items.Add(""+i);
            }
            for (int i = 1; i <= 12; i++)
            {
                monthDb.Items.Add(""+i);
            }
            for (int i = 1901; i <= 2016; i++)
            {
                yearDb.Items.Add(""+i);
            }
            
            string username = Request.Cookies["userName"].Value;
            User user = sr.GetUserByUsername(username);
            txtRealName.Text = user.Name;
            txtEmail.Text = user.Email;
            txtUsername.Text = user.Username;
            
            daysDb.SelectedIndex = user.Bday.Day-1;
            
            monthDb.SelectedIndex = user.Bday.Month-1;
            
            yearDb.SelectedIndex = user.Bday.Year-1901;
            

            passion1.SelectedIndex = user.Passion1-1;
            passion2.SelectedIndex = user.Passion2-1;
            passion3.SelectedIndex = user.Passion3-1;
        }
        txtUsername.Text = Request.Cookies["userName"].Value;
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        bool error = false;
        lblMsg.Text = "";
        WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();

        if (passion1.SelectedIndex.Equals(passion2.SelectedIndex))
        {
            lblMsg.Text = "a" + passion1.SelectedIndex + " " + passion2.SelectedIndex + " " + passion3.SelectedIndex;
            error = true;
        }
        if (passion2.SelectedIndex.Equals(passion3.SelectedIndex))
        {
            lblMsg.Text = "b" + passion1.SelectedIndex + " " + passion2.SelectedIndex + " " + passion3.SelectedIndex;
            error = true;
        }
        if (passion1.SelectedIndex.Equals(passion3.SelectedIndex))
        {
            lblMsg.Text = "c" + passion1.SelectedIndex + " " + passion2.SelectedIndex + " " + passion3.SelectedIndex;
            //lblMsg.Text = "Similar passions selected 1 and 3.";
            error = true;
        }

        if (error == false)
        {
            int day=1, month=1, year=1992;
            
            day = Int32.Parse(daysDb.SelectedValue);
            month = Int32.Parse(monthDb.SelectedValue);
            year = Int32.Parse(yearDb.SelectedValue);
            //string bday = string.Format("{0}/{1}/{2}", day, month,year);
            //DateTime birthdate = DateTime.Parse(bday, new System.Globalization.CultureInfo("fr-FR", true));
            DateTime birthdate = new DateTime(year, month, day);
            

            sr.UpdateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text, txtRealName.Text, passion1.SelectedIndex+1 , passion2.SelectedIndex+1 , passion3.SelectedIndex+1 , birthdate);
            lblMsg.Text = "Updated!";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtRePassword.Text = "";
            txtRealName.Text = "";
            txtEmail.Text = "";
        }

        else
        {
            lblMsg.Text = "Make sure all the fields are completed.";
        }
        //sr.RegisterUser(txtUsername.Text, txtUsername.Text, "Email",2, 5, 6);


    }

    protected void AddConnection_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Login.aspx");
    }
}