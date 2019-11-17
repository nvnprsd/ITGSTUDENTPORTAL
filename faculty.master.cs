using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class faculty : System.Web.UI.MasterPage
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
                    SqlCommand cm = new SqlCommand("select name,username, dept from auth where username ='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
                    sq.Open();
                    SqlDataReader d = cm.ExecuteReader();
                    d.Read();
                    name.Text = d["Name"].ToString();
                    username.Text = d["username"].ToString();
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

        
    }

    protected void takelecture_Click(object sender, EventArgs e)
    {
        
        Server.Transfer("f_takeclass.aspx");
    }

    protected void uploadinternalmrks_Click(object sender, EventArgs e)
    {
        Server.Transfer("f_uploadInternal.aspx");

    }

    protected void giveassignment_Click(object sender, EventArgs e)
    {
       Response.Redirect("f_giveassignment.aspx");
    }

    protected void checkassignment_Click(object sender, EventArgs e)
    {
     Server.Transfer("f_chkassign.aspx");
    }

    protected void sendnotice_Click(object sender, EventArgs e)
    {
        Server.Transfer("f_sendnotice.aspx");
    }

    protected void reportissue_Click(object sender, EventArgs e)
    {
        Server.Transfer("f_adminissue.aspx");
    }
    protected void libstatus_click(object sender, EventArgs e)
    {
        Server.Transfer("f_libchk.aspx");
    }



    protected void logout_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Response.Redirect("index.aspx");
    }

    

    protected void uploadpic_Click(object sender, EventArgs e)
    {

    }
}
