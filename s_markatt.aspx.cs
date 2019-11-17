using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
             
    }
    
    protected void markatt_Click(object sender, EventArgs e)
    {
       
        string a = "0";
        if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("09:20") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("09:59"))
        {
            a = "1";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("10:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("10:59"))
        {
            a = "2";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("11:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("12:59"))
        {
            a = "3";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("12:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("012:59"))
        {
            a = "4";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("02:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("02:59"))
        {
            a = "5";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("03:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("03:59"))
        {
            a = "6";
        }

        if (mark.Checked == true)
        {
            if (tchrname.Text == "No one")
            {

            }
            else
            {
                try
                {

                     Label name = (Label)Master.FindControl("name");
                    Label userid = (Label)Master.FindControl("userid");
                    Label dept = userid;
                    using (SqlConnection sq = new SqlConnection(cs))
                    {
                        bool st = false;
                        sq.Open();
                        SqlCommand cm = new SqlCommand("select * from " + dept.Text.Substring(0,6) + "att where date=CONVERT(date,getdate())", sq);
                        SqlDataReader rd = cm.ExecuteReader();
                        if (rd.HasRows)
                        {
                            st = true;
                        }
                        rd.Close();
                        if (st == true)
                        {

                            SqlCommand c = new SqlCommand("update  " + dept.Text.Substring(0, 6) + "att set fname" + a + "='" + tchrname.Text + "',status" + a + "='P' where std_id='" + userid.Text + "'", sq);
                            c.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmm = new SqlCommand("insert into " + dept.Text.Substring(0, 6) + "att (Std_id,fname" + a + ",status" + a + ")values('" + userid.Text + "','" + tchrname.Text + "','P')", sq);
                            cmm.ExecuteNonQuery();

                        }
                        SqlCommand cmd = new SqlCommand("insert into " + dept.Text.Substring(0, 6) + "tmp (std_id,name,fname,status) values('" + userid.Text + "','" + name.Text + "','" + tchrname.Text + "','P')", sq);

                        cmd.ExecuteNonQuery();
                        sq.Close();
                        markatt.Text = "attendance marked";
                        markatt.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }
        }
        else
        {
            mark.Text = "please mark it.";
        }
    }

    protected void Panel1_Load(object sender, EventArgs e)
    {
        try
        {
            Label dept = (Label)Master.FindControl("userid");
            using (SqlConnection sq = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select username,name from auth where location ='" + dept.Text.Substring(0,6) + "'", sq);
                sq.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    lecturename.Text = rd["name"].ToString();
                    tchrname.Text = rd["username"].ToString();
                    rd.Close();
                }

                else
                {
                }
                sq.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    protected void markatt_Load(object sender, EventArgs e)
    {
        if (tchrname.Text == "No one")
        {
            string ms = "Currently No Faculty Is in Your Class";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ms), true);
            Server.Transfer("student.aspx");

        }
    }
}