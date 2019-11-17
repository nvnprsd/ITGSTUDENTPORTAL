using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library : System.Web.UI.MasterPage
{
    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
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
                    SqlCommand cm = new SqlCommand("select name,username from auth where username ='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
                    sq.Open();
                    SqlDataReader d = cm.ExecuteReader();
                    d.Read();
                    name.Text = d["Name"].ToString();
                    username.Text = d["username"].ToString();
                    Session["user"] = d["username"].ToString();
                    d.Close();
                    sq.Close();
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

    }





    protected void logout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Server.Transfer("index.aspx");
    }
}
