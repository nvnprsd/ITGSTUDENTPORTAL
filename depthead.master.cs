using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class depthead : System.Web.UI.MasterPage
{
    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
       try {
            if (Session["user"] == null)
        {
            Response.Redirect("index.aspx");
        }
        using (SqlConnection sq = new SqlConnection(cs))
        {
            SqlCommand cm = new SqlCommand("select name,username, dept from auth where username ='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
            sq.Open();
            SqlDataReader d = cm.ExecuteReader();
            d.Read();
            name.Text = d["Name"].ToString();
           Session["user"]= username.Text = d["username"].ToString();
            dept.Text = d["dept"].ToString();
            d.Close();
            sq.Close();
        }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    protected void postnotice_Click(object sender, EventArgs e)
    {
        Server.Transfer("dept_sendnotice.aspx");
    }

    protected void logout_Click(object sender, EventArgs e)
    {
        Session["user"] =null;
       
            Response.Redirect("index.aspx");
       
    }

    protected void NewUnverify_Click(object sender, EventArgs e)
    {
        Server.Transfer("dept_unverifiedstudent.aspx");
    }

    protected void chkmrks_Click(object sender, EventArgs e)
    {

    }

    protected void chkatten_Click(object sender, EventArgs e)
    {
        Server.Transfer("D_atten.aspx");
    }

    protected void uploadmrks_Click(object sender, EventArgs e)
    {
        Server.Transfer("d_uploadmarks.aspx");
    }
}
