using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    protected bool gwt()
    {

        SqlConnection sq = new SqlConnection(cs);
        SqlCommand cm = new SqlCommand("select location from auth where username ='" + Session["user"].ToString() + "' or mail='" + Session["user"].ToString() + "'", sq);
        sq.Open();
        SqlDataReader d = cm.ExecuteReader();
        if (d.HasRows)
        {
            d.Read();
            string a = d["location"].ToString();
            if (a != "NULL")
            {
                return false;
            }
            else
            { return true; }
        }
        return true;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user"]==null)
        {
            Server.Transfer("main.aspx");
        }
        try{
            if (gwt() == false)
            {
                Response.Redirect("f_checkatt.aspx");
            }
            else
            {

                using (SqlConnection sq = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand("select * from notice where ( target='all' or target like '" + (Session["user"].ToString()).Substring(0,2) + "%' ) and expdate>=convert(varchar(11),getdate() )", sq);
                    sq.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (!rd.HasRows)
                    {
                    }
                    else
                    {
                        while (rd.Read())
                        {
                            Dashboard.Controls.Add(new LiteralControl(" <p style =\"color:white; font-size:medium;\" >" + rd["msg"].ToString() + " posted by -" + rd["sender"].ToString() + " (" + rd["userid"].ToString() + ") on " + rd["date"].ToString()+"</p>"));
                            }

                    }
                    rd.Close();
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }

}