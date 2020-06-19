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
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["user"]==null)
        {
            Server.Transfer("main.aspx");
        }
        
    }

    protected void Label2_Load(object sender, EventArgs e)
    {
        try
        {
            string amt = Session["user"].ToString();
            using (SqlConnection sq = new SqlConnection(cs))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand("select bookname,bookid from facultylibrary where Tech_id='" +amt + "' and status='issued' ", sq);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    books.Items.Clear();
                    while (r.Read())
                    {
                        ListItem ls = new ListItem();
                        ls.Selected = true;
                        ls.Text = r["bookname"].ToString();
                        ls.Value = r["bookid"].ToString();
                        books.Items.Add(ls);
                    }
                }
            }

        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }
}