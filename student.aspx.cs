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
    protected int Getsem(int m, int y)
    {
        string lb = Session["user"].ToString();
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
     try
        {

            using (SqlConnection sq = new SqlConnection(cs))
            {


                SqlCommand cmd = new SqlCommand("select * from notice where  (target like '" + (Session["user"].ToString()).Substring(0, 2) + "%all' or target like 'all%' or target like '" + (Session["user"].ToString()).Substring(0, 2) + "%') and expdate>=convert(varchar(11),getdate() )", sq);
                sq.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    
                    while (rd.Read())
                    {
                        Dashboard.Controls.Add(new LiteralControl(rd["msg"].ToString() + " posted by -" + rd["sender"].ToString() + " (" + rd["userid"].ToString() + ") on " + rd["date"].ToString()));
                        Dashboard.Controls.Add(new LiteralControl("</br></br>"));
                    }

                }
                rd.Close();

                int m = Int32.Parse(DateTime.Now.Month.ToString());
                int y = Int32.Parse(DateTime.Now.Year.ToString());
                int i = Getsem(m, y);
                //for assignments list
                SqlCommand c = new SqlCommand("select * from "+ (Session["user"].ToString()).Substring(0, 2) + "giveassignments where  sem='"+i+"'", sq);
               
                SqlDataReader d = c.ExecuteReader();
                if (d.HasRows)
                {
                    while (d.Read())
                    {
                        Dashboard.Controls.Add(new LiteralControl("<p> <a runat\"server\" style=\"color: blue; font-size:medium\"  href="+ d["as_path"].ToString() + ">Assignment issued of " + d["sub_name"] + " posted by -" + d["tchr_id"].ToString() + "due on " + (d["duedate"].ToString()).Substring(0,10) + "</a></p>"));
                          }

                }
                rd.Close();
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }
}