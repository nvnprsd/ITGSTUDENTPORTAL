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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;

    protected void post_Click(object sender, EventArgs e)
    {
        if (Branch.SelectedValue=="0"||Year.SelectedValue=="0")
        {
            Response.Write("Branch and Year Must be selected");
        }
        else
        {
            send();
        }
    }
    protected void send()
    {
        try
        {
            Label name = (Label)Master.FindControl("name");
            Label userid = (Label)Master.FindControl("username");

            string s = "insert into notice (msg,sender,userid,target,expdate) values('" + msg.Text + "','" + name.Text + "','" + userid.Text + "','" + Branch.SelectedValue + Year.SelectedValue + "','" + exp.Text + "')";
        string m = "Notice Posted";
            using (SqlConnection sq = new SqlConnection(cs))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand(s, sq);
                cmd.ExecuteNonQuery();

                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", m), true);
                sq.Close();
            }
            Server.Transfer("Admin.aspx");
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);
        }
    }
}