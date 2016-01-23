using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profile : System.Web.UI.Page
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
                lblMsg.Text = "a"+ passion1.SelectedIndex + " " + passion2.SelectedIndex + " " + passion3.SelectedIndex;
                error = true;
            }
            if (passion2.SelectedIndex.Equals(passion3.SelectedIndex))
            {
                lblMsg.Text = "b"+ passion1.SelectedIndex + " " + passion2.SelectedIndex + " " + passion3.SelectedIndex;
                error = true;
            }
            if (passion1.SelectedIndex.Equals(passion3.SelectedIndex))
            {
                lblMsg.Text ="c"+ passion1.SelectedIndex + " " + passion2.SelectedIndex + " " + passion3.SelectedIndex;
                //lblMsg.Text = "Similar passions selected 1 and 3.";
                error = true;
            }

            if (error == false)
            {
                string day = Request.Form.Get("days"); 
                string month = Request.Form.Get("months"); 
                string year = Request.Form.Get("years"); 
                string bday = string.Format("{0}/{1}/{2}", day, month, year);
                DateTime birthdate = DateTime.Parse(bday, new System.Globalization.CultureInfo("fr-FR", true));
                sr.UpdateUser(txtUsername.Text, txtPassword.Text, txtEmail.Text, txtRealName.Text, passion1.SelectedIndex+1, passion2.SelectedIndex+1, passion3.SelectedIndex+1, birthdate);
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
        Response.Redirect("Login.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}