using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    string subname; string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;

    protected int Getsem(int m, int  y)
    {   string lb = Session["user"].ToString();
       int j = 0;
        int i = Int32.Parse(lb.Substring(2, 4));
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
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }


    protected void upload_Click(object sender, EventArgs e)
    {
        if (DropDownList1.Text == "Select Subject")
        {
            Response.Write("Please Select Subject for Assignment");
        }
        else
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    string fileExtwnsion = Path.GetExtension(FileUpload1.FileName);

                    if (fileExtwnsion.ToLower() == ".doc" || fileExtwnsion.ToLower() == ".docx" || fileExtwnsion.ToLower() == ".pdf")
                    {
                        if (DropDownList1.SelectedIndex == 0 || FileUpload1.FileContent == null)
                        {
                            Response.Write("select any subject or valid file");
                        }
                        else
                        {
                            int m = Int32.Parse(DateTime.Now.Month.ToString());
                            int y = Int32.Parse(DateTime.Now.Year.ToString());
                            int i = Getsem(m, y);

                            HttpPostedFile uploadedFile = FileUpload1.PostedFile;

                            Label username = (Label)Master.FindControl("userid");
                            var folder = Server.MapPath("~/Assignments/" + username.Text.Substring(0, 6) + "/" + i + "Sem/" + DropDownList1.SelectedValue + "/");
                            string path = Convert.ToString(folder);
                            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);

                                uploadedFile.SaveAs(path + Session["user"] + DateTime.Today.ToShortDateString() + extension);
                            }
                            else { uploadedFile.SaveAs(path + Session["user"] + DateTime.Today.ToShortDateString() + extension); }

                            using (SqlConnection sq = new SqlConnection(cs))
                            {
                                string path1 = "Assignments\\" + username.Text.Substring(0, 6) + "\\" + i + "Sem\\" + DropDownList1.SelectedValue + "\\" + Session["user"] + DateTime.Today.ToShortDateString() + extension;

                                string l = Session["user"].ToString();
                                SqlCommand cm = new SqlCommand("insert into " + (Session["user"].ToString()).Substring(0, 2) + "submittedassignments values('" + Session["user"].ToString() + "','" + DropDownList1.SelectedValue + "','" + i + "','10-02-2019','" + path1 + "')", sq);
                                sq.Open();

                                cm.ExecuteNonQuery();
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
                Response.Write("unable to submit" + ex.ToString());
            }
        }
    }

   

    protected void FileUpload1_Load(object sender, EventArgs e)
    {
      
               try
                {

                    using (SqlConnection sq = new SqlConnection(cs))
            {
                int m = Int32.Parse(DateTime.Now.Month.ToString());
                int y = Int32.Parse(DateTime.Now.Year.ToString());
                int i = Getsem(m, y);
                string l = Session["user"].ToString();
                        SqlCommand cm = new SqlCommand("select sub_name,duedate from " + l.Substring(0, 2) + "giveassignments where duedate >= getdate() and sem='"+i+"'",sq);
                        sq.Open();
                        SqlDataReader d = cm.ExecuteReader();
                        while (d.Read())
                        {
                            ListItem item = new ListItem();
                            item.Value = d["sub_name"].ToString();
                            item.Text = d["sub_name"].ToString() + " Due on " + d["duedate"].ToString();

                            DropDownList1.Items.Add(item);
                        }

                        d.Close();
                        sq.Close();
                    }

                }
                catch (Exception)
                {
            Response.Write("Not submitted");
                }
            }
           
 }
    
