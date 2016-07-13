using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WcfService;
using WcfService.ModelLayer;

public partial class Booking : System.Web.UI.Page
{
    WcfServiceReference.Service1Client sr = new WcfServiceReference.Service1Client();
    User[] advisors; 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        advisors = sr.GetAllAdvisors();
        if (!IsPostBack)
        { 
        for (int i = 0; i <= 23; i++)
        {
            ddlHour.Items.Add("" + i);
        }
        
        foreach (User a in advisors)
        {
            a.Passion1String = sr.GetPassionById(a.Passion1);
            a.Passion2String = sr.GetPassionById(a.Passion2);
            a.Passion3String = sr.GetPassionById(a.Passion3);
            ddlAdvisors.Items.Add("User: " + a.Username +" Passions: " + a.Passion1String + ", " + a.Passion2String + ", " + a.Passion3String);
        }

        if (sr.isAdvisor(sr.GetUserByUsername(Request.Cookies["userName"].Value).Id))
        {
            ddlAdvisors0.Items.Add("User: " + sr.GetUserByUsername(Request.Cookies["userName"].Value).Username);
        }
        else
        {
            foreach (User a in advisors)
            {
                ddlAdvisors0.Items.Add("User: " + a.Username + " Passions: " + a.Passion1String + ", " + a.Passion2String + ", " + a.Passion3String);
            }
        }

        string[] dates = sr.GetAllAdvisorsDates(advisors[ddlAdvisors.SelectedIndex].Id);
        ddlDates.Items.Add("none");
            foreach (string d in dates)
            {
                ddlDates.Items.Add(d);
            }
            string[] dates0;
            int userId = sr.GetUserByUsername(Request.Cookies["userName"].Value).Id;
            if (sr.isAdvisor(userId))
            {
                dates0 = sr.GetAllAdvisorAvailableDates(userId);
            }
            else
            {
                dates0 = sr.GetAllBookedDates(advisors[ddlAdvisors0.SelectedIndex].Id, userId);
            }
            ddlDates0.Items.Clear();
            ddlDates0.Items.Add("none");
            foreach (string d in dates0)
            {
                ddlDates0.Items.Add(d);
            }

            //initialize ddmBookedDates
            string[] dates3;
            dates3 = sr.GetAllBookedDates(userId, userId);

            ddlBookedDates.Items.Clear();
            ddlBookedDates.Items.Add("none");
            foreach (string d in dates3)
            {
                ddlBookedDates.Items.Add(d);
            }


        }
        if (sr.isAdvisor(sr.GetUserByUsername(Request.Cookies["userName"].Value).Id))
        {
            ddlAdvisors.Visible = false;
            ddlDates.Visible = false;
            btnBook.Visible = false;
        }
        else
        {
            lblAddDate.Visible = false;
            calDate.Visible = false;
            ddlHour.Visible = false;
            btnAddBook.Visible = false;
            lbHour.Visible = false;
            lblBookedDates.Visible = false;
            ddlBookedDates.Visible = false;
        }
    }
    protected void calDate_DayRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
    {

        if (e.Day.Date <= DateTime.Now)
        {

            e.Cell.BackColor = System.Drawing.Color.Gray;

            e.Day.IsSelectable = false;

        }

    }
    protected void btnAddBook_Click(object sender, EventArgs e)
    {
        
       string username = Request.Cookies["userName"].Value;
       int id = sr.GetUserByUsername(username).Id;
       
       DateTime date = new DateTime(calDate.SelectedDate.Year,calDate.SelectedDate.Month,calDate.SelectedDate.Day);
       TimeSpan ts = new TimeSpan(ddlHour.SelectedIndex,0,0);
       date = date.Date + ts;
       string mydate = "" + date.Year + "-" + date.Month + "-" + date.Day + " " + date.Hour+":"+date.Minute+":"+date.Second;
       bool found = false;
       found = sr.bookingExist(id, date);
       if (!found)
       {
           sr.insertBooking(id, date);
           lblError.Text = "Available date inserted!";
       }
       else
       {
           lblError.Text = "This date and time are already inserted!";
       }

    }
    protected void ddlAdvisors_SelectedIndexChanged(object sender, EventArgs e)
    {
        string [] dates = sr.GetAllAdvisorsDates(advisors[ddlAdvisors.SelectedIndex].Id);
        ddlDates.Items.Clear();
        ddlDates.Items.Add("none");
        foreach(string d in dates)
        {
            ddlDates.Items.Add(d);
        }
    }
    protected void ddlDates_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = sr.GetUserByUsername(Request.Cookies["userName"].Value).Id;
        if(ddlDates.SelectedIndex!=0)
        if (!sr.checkDateIsAvailable(advisors[ddlAdvisors.SelectedIndex].Id, ddlDates.SelectedValue, id))
        {
            lblError.Text = "Someone is trying to book this date right now. Please try again in 2 minutes!";
            btnBook.Enabled = false;
        }
        else
        {
            lblError.Text = "";
            btnBook.Enabled = true;
        }
    }
    protected void btnBook_Click(object sender, EventArgs e)
    {
       int id = sr.GetUserByUsername(Request.Cookies["userName"].Value).Id;
       if (ddlDates.SelectedIndex != 0)
           if (sr.finishBook(advisors[ddlAdvisors.SelectedIndex].Id, ddlDates.SelectedValue, id))
           {
               lblError.Text = "Booking successful";
           }
           else
           {
               lblError.Text = "";
           }
       Response.Redirect("Booking.aspx");

    }

    protected void ddlAdvisors0_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] dates;
        int userId = sr.GetUserByUsername(Request.Cookies["userName"].Value).Id;
        if (sr.isAdvisor(userId))
        {
             dates = sr.GetAllAdvisorAvailableDates(userId);
        }
        else
        {
             dates = sr.GetAllBookedDates(advisors[ddlAdvisors0.SelectedIndex].Id, userId);
        }
        ddlDates0.Items.Clear();
        ddlDates0.Items.Add("none");
        foreach (string d in dates)
        {
            ddlDates0.Items.Add(d);
        }
    }
    protected void ddlDates0_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = sr.GetUserByUsername(Request.Cookies["userName"].Value).Id;
        if (ddlDates0.SelectedIndex == 0)
        {
            btnRemoveBook.Enabled = false;
        }
        else
        {
            btnRemoveBook.Enabled = true;
        }
    }
    protected void btnRemoveBook_Click(object sender, EventArgs e)
    {
        int id = sr.GetUserByUsername(Request.Cookies["userName"].Value).Id;
        if (sr.isAdvisor(id))
        {
            if (ddlDates0.SelectedIndex != 0)
                if (sr.deleteBook(advisors[ddlAdvisors0.SelectedIndex].Id, ddlDates0.SelectedValue, id))
                {
                    lblError.Text = "Booking date has been deleted!";
                }
                else
                {
                    lblError.Text = "";
                }
        }
        else
        {
            if (ddlDates0.SelectedIndex != 0)
                if (sr.removeBook(advisors[ddlAdvisors0.SelectedIndex].Id, ddlDates0.SelectedValue, id))
                {
                    lblError.Text = "Booking remove successful!";
                }
                else
                {
                    lblError.Text = "";
                }
        }
        Response.Redirect("Booking.aspx");
    }
    protected void ddlBookedDates_SelectedIndexChanged(object sender, EventArgs e)
    {
        string[] dates3;
        int userId = sr.GetUserByUsername(Request.Cookies["userName"].Value).Id;
        dates3 = sr.GetAllBookedDates(userId, userId);

        ddlBookedDates.Items.Clear();
        ddlBookedDates.Items.Add("none");
        foreach (string d in dates3)
        {
            ddlBookedDates.Items.Add(d);
        }
    }
}