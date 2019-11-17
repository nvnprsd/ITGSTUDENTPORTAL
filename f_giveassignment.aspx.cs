using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
     protected int Getsem(int m, int  y)
    {   string lb = Session["user"].ToString();
       int j = 0;
        int i = Int32.Parse(Year.SelectedValue);
        if (m < 7 && (y - i) == 0)
        {
            j = 2;
        }
        if (m < 7 && (y - i) == 1)

        {
            j = 4;
        }
        if (m < 7 && (y - i) == 2)

        {
            j = 6;
        }
        if (m < 7 && (y - i) == 3)

        {
            j = 8;
        }
        if (m > 7 && (y - i) == 0)

        {
            j = 1;
        }
        if (m > 7 && (y - i) == 1)

        {
            j = 3;
        }
        if (m > 7 && (y - i) == 2)

        {
            j = 5;
        }
        if (m > 7 && (y - i) == 3)

        {
            j = 7;
        }
        return j;
    }
   
    protected void giveassignment_Click(object sender, EventArgs e)
    {
        if (Year.Text == "Select Year")
        {
            Response.Write("Please Select A Year for Assignment");
        }
        else
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;

                if (FileUpload1.HasFile)
                {
                    string fileExtwnsion = Path.GetExtension(FileUpload1.FileName);

                    if (fileExtwnsion.ToLower() == ".doc" || fileExtwnsion.ToLower() == ".docx" || fileExtwnsion.ToLower() == ".pdf")
                    {
                        Response.Write("file is ok");
                        if (Year.SelectedIndex == 0 || FileUpload1.FileContent == null)
                        {
                            Response.Write("select any subject or valid file");
                        }
                        else
                        {
                            int m = Int32.Parse(DateTime.Now.Month.ToString());
                            int y = Int32.Parse(DateTime.Now.Year.ToString());
                            int i = Getsem(m, y);

                            HttpPostedFile uploadedFile = FileUpload1.PostedFile;

                            Label username = new Label();
                            username.Text = Session["user"].ToString();
                            var folder = Server.MapPath("~/Assignments/" + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "/" + i + "Sem/" + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "/");
                            string path = Convert.ToString(folder);
                            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);

                                uploadedFile.SaveAs(path + "As" + Session["user"].ToString() + DateTime.Today.ToShortDateString() + extension);
                            }
                            else { uploadedFile.SaveAs(path + "As" + Session["user"].ToString() + DateTime.Today.ToShortDateString() + extension); }

                            using (SqlConnection sq = new SqlConnection(cs))
                            {
                                string path1 = "Assignments\\" + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "\\" + i + "Sem\\" + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "\\As" + Session["user"] + DateTime.Today.ToShortDateString() + extension;

                                SqlCommand cmd = new SqlCommand("insert into " + (Session["user"].ToString()).Substring(0, 2) + "giveassignments values('" + subname.Text.Replace(" ", "_") + "','" + Session["user"].ToString() + "'," + i + ",'" + duedate.Text + "','" + path1 + "')", sq);
                                sq.Open();

                                cmd.ExecuteNonQuery();
                                sq.Close();


                            }

                        }

                    }//file ext validation if block close
                    else
                    { Response.Write("Please Select a Valid File"); }


                }// file upload  if block closed
                else
                { Response.Write("Please Select File"); }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}