using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibraryPOCA;
using System.IO;
using WebsiteT1.UserServiceReference;


namespace WebsiteT1
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            string day = Request.Form.Get("days");
            string month = Request.Form.Get("months");
            string year = Request.Form.Get("years");
            string bday = string.Format("{0}/{1}/{2}", day, month, year);
            DateTime birthdate = DateTime.Parse(bday, new System.Globalization.CultureInfo("fr-FR", true));
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
            var CTR = new BusinessClass();
            string imageURL = profileImage.ImageUrl;
            try
            {
                // change here with service conneciton
                //CTR.InsertNewUser(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtUsername.Text, txtPassword.Text, birthdate, imageURL);
                var service = new UserServiceClient();
                var newUser = new NewUser();
                newUser.fn = txtFirstName.Text;
                newUser.ln = txtLastName.Text;
                newUser.email = txtEmail.Text;
                newUser.usr = txtUsername.Text;
                newUser.pass = txtPassword.Text;
                newUser.bdate = birthdate;
                newUser.imgURL = imageURL;
                if (service.InsertNewUser(newUser))
                    StatusLabel.Text = "Upload Succesfully!";
                else StatusLabel.Text = "FAILEEEEEDDD!";
            }
            catch (Exception E)
            {
                StatusLabel.Text = E.ToString();
            }
            
        }
    }
}