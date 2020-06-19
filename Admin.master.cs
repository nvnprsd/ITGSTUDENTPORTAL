using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.MasterPage
{
    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Server.Transfer("index.aspx");
        }
        else
        {


            try
            {

                using (SqlConnection sq = new SqlConnection(cs))
                {
                    SqlCommand cm = new SqlCommand("select name,username, dept from auth where username ='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
                    sq.Open();
                    SqlDataReader d = cm.ExecuteReader();
                    d.Read();
                    name.Text = d["Name"].ToString();
                    username.Text = d["username"].ToString();
                    d.Close();
                    sq.Close();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

            }
            logout.Text ="Sign Out";
        }
    }

    protected void startrereg_Click(object sender, EventArgs e)
    {
    }
    protected void unverifiedF_Click(object sender, EventArgs e) 
    {
        Server.Transfer("A_unverifiedtchr.aspx");
    }
    protected void view_std_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_studentslist.aspx");
    }
    protected void view_tech_Click(object sender, EventArgs e)
    {
        Server.Transfer("A_facultyList.aspx");
    }
    protected void logout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Server.Transfer("index.aspx");
    }
}
