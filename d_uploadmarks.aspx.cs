using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FileUpload1_DataBinding(object sender, EventArgs e)
    {
        

    }

    protected void fileuploadbtn_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (FileUpload1.PostedFile.ContentType == "file/.xls")
            {

                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/vendor/CSResult"+Year.SelectedValue+".xls"));
                Response.Write("Uploaded");
            }
            else
            {
                Response.Write("Expecting Excel File. ('__')");
            }
        }
    }
}