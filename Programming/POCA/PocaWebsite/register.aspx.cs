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
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadControl.PostedFile.ContentLength < 1024000)
                        {
                            string filename = Path.GetFileName(FileUploadControl.FileName);
                            FileUploadControl.SaveAs(Server.MapPath("~/Images/") + filename);
                            StatusLabel.Text = "Upload status: File uploaded!";
                            profileImage.ImageUrl= "Images/"+filename;
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
        }

    }
}