using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfService.ModelLayer;
using System.Data;
using System.Data.SqlClient;
public partial class Search : System.Web.UI.Page
{
    public HttpCookie theCookie;
    private SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Alexandru\Documents\Poca\WcfService\App_Data\Database.mdf;Integrated Security=True");
    private SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["userName"] != null)
        {
            theCookie = Request.Cookies.Get("userName");
            String value = theCookie.Value;
            if (!IsPostBack)
            {
                WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
                passion1.Items.Clear();
                passion2.Items.Clear();
                passion3.Items.Clear();

                passion1.Items.Add("None");
                passion2.Items.Add("None");
                passion3.Items.Add("None");
                foreach (string s in sr.GetAllPassions())
                {
                    passion1.Items.Add(s);
                    passion2.Items.Add(s);
                    passion3.Items.Add(s);
                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    public User[] results;
    protected void searchButton_Click(object sender, EventArgs e)
    {
        bool error = false;
        lblMsg.Text = "";

        if (!error)
        {
            HttpCookie theCookie = Request.Cookies.Get("userName");
            String value = theCookie.Value;
            WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
            results = sr.GetAllResults(passion1.SelectedIndex, passion2.SelectedIndex, passion3.SelectedIndex,value);
            foreach (User r in results) 
            {
                Panel panel = new Panel();
                panel.Width = 1000;
                panel.Height = 180;
                panel.BorderWidth = 10;
                panel.HorizontalAlign = HorizontalAlign.Left;
                //Username
                Label label = new Label();
                label.Width = 1000;
                label.Height = 10;
                label.Text = r.Username;
                panel.Controls.Add(label);    
                //Realname
                Label label2 = new Label();
                label2.Width = 1000;
                label2.Height = 10;
                label2.Text = r.Name;
                panel.Controls.Add(label2);
                //Email
                Label label3 = new Label();
                label3.Width = 1000;
                label3.Height = 10;
                label3.Text = r.Email;
                panel.Controls.Add(label3);
                //Name
                Label label4 = new Label();
                label4.Width = 1000;
                label4.Height = 10;
                label4.Text = r.Passion1String + " | " + r.Passion2String + " | " + r.Passion3String + " ;";
                panel.Controls.Add(label4);

                Button newButton = new Button();
                newButton.Click += (s, ex) => {AddConnection(r.Id);};
                newButton.ID = "" + r.Username;
                newButton.Width = 980;
                newButton.Height =30;
                newButton.Text = "Add connection.";
                panel.Controls.Add(newButton);
                //more info
                Button newButton2 = new Button();
                newButton2.Click += (s, ex) => { Response.Redirect("ProfileOfOthers.aspx"); ;};
                newButton2.ID = "" + r.Username;
                newButton2.Width = 980;
                newButton2.Height = 30;
                
                newButton2.Text = "Click me for more information about this person.";
                panel.Controls.Add(newButton2); 


                 Panel_Controls.Controls.Add(panel);
            }
        }
    }
   
    private void AddConnection(int Id)
    {
        //This it's not working!!! Fix it!
        WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
        User user = sr.GetUserByUsername(Request.Cookies["Username"].Value);
       
        string command = string.Format("Insert Into Connections (SenderId, ReceiverId, Acceptance) VALUES ('{0}','{1}', '{2}')",user.Id ,Id,0);
        cmd.CommandText = command;
        cmd.CommandType = CommandType.Text;
        cmd.Connection = sqlConnection1;

        sqlConnection1.Open();
        cmd.ExecuteNonQuery();
        sqlConnection1.Close();
    }


    protected void advSearchButton_Click(object sender, EventArgs e)
    {
        //label for distance
        Label tx1 = new Label();
        tx1.Text = "Distance";
        Advanced_Search.Controls.Add(tx1);
        //dropdown for distance
        DropDownList ddl1 = new DropDownList();
        Advanced_Search.Controls.Add(ddl1);
        //
    }

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        HttpCookie myCookie = Response.Cookies.Get("userName");
        myCookie.Expires = DateTime.Now.AddDays(-1d);
        Response.Redirect("Login.aspx");
    }

    protected void connections_Click(object sender, EventArgs e)
    {
        Response.Redirect("Connections.aspx");
    }

    protected void profile_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("Profile.aspx");
    }
}