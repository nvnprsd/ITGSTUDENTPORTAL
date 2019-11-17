using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;

        if (Session["user"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            try
            {

                using (SqlConnection sq = new SqlConnection(cs))
                {
                    SqlCommand cm = new SqlCommand("select name,username,dept from auth where username ='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
                    sq.Open();
                    SqlDataReader d = cm.ExecuteReader();
                    d.Read();
                    name.Text = d["Name"].ToString();
                    dept.Text = d["dept"].ToString();
                    userid.Text = d["username"].ToString();
                    d.Close();
                    sq.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }

        }
        // Label1.Text = Application["CSE2017"].ToString();
    }


   
    protected void markattendence_Click(object sender, EventArgs e)
    {
        Response.Redirect("s_markatt.aspx");
    }

    protected void checkattendence_Click(object sender, EventArgs e)
    {

    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
       
            Response.Redirect("index.aspx");
       
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {

    }

    protected void submitattedance_Click(object sender, EventArgs e)
    {

    }

    protected void uploadphoto_Click(object sender, EventArgs e)
    {

    }

    protected void librarycheck_Click(object sender, EventArgs e)
    {
        Response.Redirect("s_librarycheck.aspx");
    }

    protected void submitassignment_Click(object sender, EventArgs e)
    {

    }
   

    protected void issue_Click(object sender, EventArgs e)
    {
        Server.Transfer("s_deptissue.aspx");
    }

    protected void internalmarks_Click(object sender, EventArgs e)
    {

    }
}
