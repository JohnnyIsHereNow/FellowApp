using PocaWebsite.UserServiceController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PocaWebsite
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void UploadButton_Click(object sender, EventArgs e)
        //{
        //    // It checks if the image that is desired to be uploaded fulfills the requirements of the server
        //    if (FileUploadControl.HasFile)
        //    {
        //        try
        //        {
        //            if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
        //            {
        //                if (FileUploadControl.PostedFile.ContentLength < 1024000)
        //                {
        //                    //string filename = Path.GetFileName(FileUploadControl.FileName);
        //                    //profileImage.ImageUrl = "Images/" + filename;
        //                    //FileUploadControl.SaveAs(Server.MapPath("~/Images/") + filename);
        //                    StatusLabel.Text = "Upload status: Picture is good!";
        //                }
        //                else
        //                    StatusLabel.Text = "Upload status: The file has to be less than 1 mb!";
        //            }
        //            else
        //                StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
        //        }
        //        catch (Exception ex)
        //        {
        //            StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        //        }
        //    }
        //}

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string day = Request.Form.Get("days");
            string month = Request.Form.Get("months");
            string year = Request.Form.Get("years");
            string bday = string.Format("{0}/{1}/{2}", day, month, year);
            DateTime bdate = DateTime.Parse(bday, new System.Globalization.CultureInfo("fr-FR", true));
            UserServiceController.IUserService newUsr = new UserServiceController.UserServiceClient();
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 1024000)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            profileImage.ImageUrl = "Images/" + filename;
                            FileUploadControl.SaveAs(Server.MapPath("~/Images/") + filename);
                            StatusLabel.Text = "Upload status: Picture is good!, Profile Created!";
                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 1 mb!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }

            try
            {
                InsertUser usr = new InsertUser(txtFirstName, txtLastName, txtEmail, txtUsername, txtPassword, bdate, profileImage.ImageUrl);
                if (newUsr.RecordUser(usr) != null)
                    Response.Write("GOOOD!!!");
            }
            catch (Exception e1)
            {
                Response.Write(e1.ToString());
            }

        }
    }
}