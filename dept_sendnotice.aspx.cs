using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

      protected void post_Click(object sender, EventArgs e)
    {
        if (Year.Text == "Select Year")
        {
            

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", "Branch Must be selected"), true);
        }
        else
        {
            send();
        }
    }
    protected void send()
    {
        Label dept = (Label)Master.FindControl("dept");
        string s = "insert into notice (msg,sender,userid,target,expdate) values('" + msg.Text + "','Head of Dept','" + Session["user"] + "','" + dept.Text + Year.Text + "','" + exp.Text + "')";

        string m = "Notice Posted";
        using (SqlConnection sq = new SqlConnection(cs))
        {
            sq.Open();
            SqlCommand cmd = new SqlCommand(s, sq);
            cmd.ExecuteNonQuery();

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", m), true);
            sq.Close();
        }

    }

}
