using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{

    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void TakeClass_Click(object sender, EventArgs e)
    {
        if (Year.Text == "Select Year" || (DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("08:20") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("04:30")))
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ","Please Select Year or Invalid time for Class"),true);
        }
        else
        {
            //try
            //{
                using (SqlConnection sq = new SqlConnection(cs))
                {
                    sq.Open();

                    bool a = false;
                    Label username = (Label)Master.FindControl("username");
                    SqlCommand d = new SqlCommand("select name ,username from auth where location='" + username.Text.Substring(0, 2) + Year.SelectedValue + "'", sq);
                    SqlDataReader rd = d.ExecuteReader();
                    string fac = "";
                    if (rd.HasRows)
                    {
                        rd.Read();
                        a = true;
                        fac = rd["name"].ToString();
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", "there is " + rd["name"].ToString() + " " + rd["username"].ToString() + " in your selected class press button again to forcefully enter in class"), true) ;

                    }
                    rd.Close();

                    if (a == true && forcefully.Visible == false)
                    {
                        forcefully.Visible = true;
                    }
                    else if (forcefully.Checked != false)
                    {


                        SqlCommand cmd = new SqlCommand("drop table " + username.Text.Substring(0, 2) + Year.SelectedValue + "tmp;", sq);
                        SqlCommand c = new SqlCommand("update  auth set location='NULL', cstatus='Free' where username='" + fac + "'", sq);
                        cmd.ExecuteNonQuery();
                        c.ExecuteNonQuery();
                        SqlCommand cd = new SqlCommand("update auth set Cstatus='busy', location='" + username.Text.Substring(0, 2) + Year.SelectedValue + "' where username='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
                        SqlCommand temp = new SqlCommand("  create table " + username.Text.Substring(0, 2) + Year.SelectedValue + "tmp (date date default convert(date, getdate()),std_id varchar(50),name varchar(50),fname varchar(40),status varchar(40))", sq);
                        temp.ExecuteNonQuery();
                        cd.ExecuteNonQuery();
                        Server.Transfer("f_checkatt.aspx");

                    }



                    else if (a == false)
                    {

                        SqlCommand cmd = new SqlCommand("update auth set Cstatus='busy', location='" + username.Text.Substring(0, 2) + Year.SelectedValue + "' where username='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
                        SqlCommand temp = new SqlCommand("  create table " + username.Text.Substring(0, 2) + Year.SelectedValue + "tmp (date date default convert(date, getdate()),std_id varchar(50),name varchar(50),fname varchar(40),status varchar(40))", sq);
                        temp.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                        sq.Close();
                        Server.Transfer("f_checkatt.aspx");

                    }

                }

           // }
            //catch (Exception ex)
            {
            //    Response.Write("");
            }
        }
    }
}




      
