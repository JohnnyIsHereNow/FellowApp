using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
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
    }

    protected void RegisterButton_Click(object sender, EventArgs e)
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



            if (error == false && !sr.EmailExists(txtEmail.Text) && !sr.UsernameExists(txtUsername.Text))
            {
                string day = Request.Form.Get("days"); 
                string month = Request.Form.Get("months"); 
                string year = Request.Form.Get("years"); 
                string bday = string.Format("{0}/{1}/{2}", day, month, year);
                int isAdvisor = 0;
                if (isAdvisorChk.Checked) { isAdvisor = 1; }
                DateTime birthdate = DateTime.Parse(bday, new System.Globalization.CultureInfo("fr-FR", true));
                sr.RegisterUser(txtUsername.Text, txtPassword.Text, txtEmail.Text, txtRealName.Text, passion1.SelectedIndex+1, passion2.SelectedIndex+1, passion3.SelectedIndex+1, birthdate, isAdvisor);
                if (isAdvisor == 1) 
                {
                    lblMsg.Text = "Advisor registered";
                }
                else 
                {
                lblMsg.Text = "User registered";
                }
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtRePassword.Text = "";
                txtRealName.Text = "";
                txtEmail.Text = "";               
            }            
            else if (sr.EmailExists(txtEmail.Text) || sr.UsernameExists(txtUsername.Text))
            {
                lblMsg.Text = "Email or username already registered!";
            }
            else
            {
                lblMsg.Text = "Make sure all the fields are completed.";
            }

        
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}