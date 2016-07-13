using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfService.ModelLayer;
using System.Data;
using System.Data.SqlClient;
using WcfService;

public partial class Connections : System.Web.UI.Page
{
    public HttpCookie theCookie;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["userName"] != null)
        {

                WcfServiceReference.Service1Client service = new WcfServiceReference.Service1Client();
                User currUser = service.GetUserByUsername(Request.Cookies["userName"].Value);
                //Finds where acceptance =0
                User[] results0 = service.GetAllConnections0(currUser);
                foreach (User r in results0)
                {
                    Panel panel = new Panel();
                    panel.Width = 600;
                    panel.Height = 180;
                    panel.BorderWidth = 10;
                    panel.HorizontalAlign = HorizontalAlign.Center;
                    //Username
                    Label label = new Label();
                    label.Width = 600;
                    label.Height = 10;
                    label.Text = r.Username;
                    panel.Controls.Add(label);
                    //Realname
                    Label label2 = new Label();
                    label2.Width = 600;
                    label2.Height = 10;
                    label2.Text = r.Name;
                    panel.Controls.Add(label2);
                    //Email
                    Label label3 = new Label();
                    label3.Width = 600;
                    label3.Height = 10;
                    label3.Text = r.Email;
                    panel.Controls.Add(label3);
                    //Name
                    Label label4 = new Label();
                    label4.Width = 600;
                    label4.Height = 10;
                    label4.Text = r.Passion1String + " | " + r.Passion2String + " | " + r.Passion3String + " ;";
                    panel.Controls.Add(label4);
                    //BirthDate
                    Label label5 = new Label();
                    label5.Width = 600;
                    label5.Height = 10;
                    label5.Text = r.Bday.ToString();
                    panel.Controls.Add(label4);

                    //more info
                    Button newButton2 = new Button();
                    newButton2.ID = "a" + r.Username;
                    newButton2.Width = 580;
                    newButton2.Height = 30;
                    newButton2.Text = "Click me for more information about this person.";
                    newButton2.Click += new EventHandler(aboutButton2_Click); 
                    //pass the username through lamda for recognize the profile in the database;
                    panel.Controls.Add(newButton2);

                    Button newButton3 = new Button();
                    newButton3.ID = "" + r.Username;
                    newButton3.Width = 580;
                    newButton3.Height = 30;
                    newButton3.Text = "Accept request!";
                    newButton3.Click += new EventHandler(aboutButton3_Click);
                    //pass a variable through lambda for the accept id!
                    panel.Controls.Add(newButton3);


                    Panel_Controls.Controls.Add(panel);
                    //Panel_Controls.Controls.Add(panel);

                }

            User[] resultsPending =  service.GetAllPendingConnections(currUser);
            foreach (User r in resultsPending)
            {
                Panel panel = new Panel();
                panel.Width = 600;
                panel.Height = 180;
                panel.BorderWidth = 10;
                panel.HorizontalAlign = HorizontalAlign.Center;
                //Username
                Label label = new Label();
                label.Width = 600;
                label.Height = 10;
                label.Text = r.Username;
                panel.Controls.Add(label);
                //Realname
                Label label2 = new Label();
                label2.Width = 600;
                label2.Height = 10;
                label2.Text = r.Name;
                panel.Controls.Add(label2);
                //Email
                Label label3 = new Label();
                label3.Width = 600;
                label3.Height = 10;
                label3.Text = r.Email;
                panel.Controls.Add(label3);
                //Name
                Label label4 = new Label();
                label4.Width = 600;
                label4.Height = 10;
                label4.Text = r.Passion1String + " | " + r.Passion2String + " | " + r.Passion3String + " ;";
                panel.Controls.Add(label4);
                //BirthDate
                Label label5 = new Label();
                label5.Width = 600;
                label5.Height = 10;
                label5.Text = r.Bday.ToString();
                panel.Controls.Add(label4);

                //more info
                Button newButton2 = new Button();
                newButton2.ID = "a" + r.Username;
                newButton2.Width = 580;
                newButton2.Height = 30;
                newButton2.Text = "Click me for more information about this person.";
                newButton2.Click += new EventHandler(aboutButton2_Click);
                //pass the username through lamda for recognize the profile in the database;
                panel.Controls.Add(newButton2);
            
                Button newButton3 = new Button();
                newButton3.ID = "" + r.Username;
                newButton3.Width = 580;
                newButton3.Height = 30;
                newButton3.Text = "Cancel connection request !";
                newButton3.Click += new EventHandler(pendingButton_Click);
                //pass a variable through lambda for the accept id!
                panel.Controls.Add(newButton3);


                Panel_Controls.Controls.Add(panel);
                //Panel_Controls.Controls.Add(panel);

            }

            //Find where acceptance=1
            User[] results1 = service.GetAllConnections1(currUser);
                foreach (User r in results1)
                {
                    Panel panel = new Panel();
                    panel.Width = 600;
                    panel.Height = 180;
                    panel.BorderWidth = 10;
                    panel.HorizontalAlign = HorizontalAlign.Center;
                    //Username
                    Label label = new Label();
                    label.Width = 600;
                    label.Height = 10;
                    label.Text = r.Username;
                    panel.Controls.Add(label);
                    //Realname
                    Label label2 = new Label();
                    label2.Width = 600;
                    label2.Height = 10;
                    label2.Text = r.Name;
                    panel.Controls.Add(label2);
                    //Email
                    Label label3 = new Label();
                    label3.Width = 600;
                    label3.Height = 10;
                    label3.Text = r.Email;
                    panel.Controls.Add(label3);
                    //Name
                    Label label4 = new Label();
                    label4.Width = 600;
                    label4.Height = 10;
                    label4.Text = r.Passion1String + " | " + r.Passion2String + " | " + r.Passion3String + " ;";
                    panel.Controls.Add(label4);
                    //BirthDate
                    Label label5 = new Label();
                    label5.Width = 600;
                    label5.Height = 10;
                    label5.Text = r.Bday.ToString();
                    panel.Controls.Add(label4);

                    //more info
                    Button newButton2 = new Button();
                    newButton2.ID = "b" + r.Username;
                    newButton2.Width = 580;
                    newButton2.Height = 30;

                    newButton2.Text = "Click me for more information about this person.";
                    newButton2.Click += new EventHandler(aboutButton2_Click);
                    //pass the username through lamda for recognize the profile in the database; 
                    panel.Controls.Add(newButton2);


                    Panel_Controls.Controls.Add(panel);
                    
                }
                
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void aboutButton3_Click(object sender, EventArgs e)
    {
        WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
        User user = sr.GetUserByUsername(Request.Cookies["Username"].Value);
        string r = ((Button)sender).ID;
        int t = sr.GetUserByUsername(r).Id;
        sr.CreateConnection(t, user.Id);
        Response.Redirect("Connections.aspx");
    }
    protected void aboutButton2_Click(object sender, EventArgs e)
    {
        string id = ((Button)sender).ID;
        id = id.Substring(1, ((Button)sender).ID.Length - 1);
        Session["id"] = id;
        Response.Redirect("ProfileOfOthers.aspx");
    }

    protected void pendingButton_Click(object sender, EventArgs e)
    {
        WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
        User user = sr.GetUserByUsername(Request.Cookies["Username"].Value);
        string r = ((Button)sender).ID;
        int t = sr.GetUserByUsername(r).Id;
        sr.RemoveConnection(t, user.Id);
        Response.Redirect("Connections.aspx");
    }
}