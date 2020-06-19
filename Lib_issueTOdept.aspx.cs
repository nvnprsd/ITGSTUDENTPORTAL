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

    protected void report_Click(object sender, EventArgs e)
    {
        Label name = (Label)Master.FindControl("name");
        Label userid = (Label)Master.FindControl("username");
        string s = "insert into issues values('" + msg0.Text + "','" + name.Text + "','" + userid.Text + "','"+Branch.SelectedValue+"depthead',getdate())";
        string m = "Issue/ Suggestion sent";

        send(s, m);


    }
    protected void send(string cm, string ms)
    {
        try
        {

            using (SqlConnection sq = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(cm, sq);
                sq.Open();
                cmd.ExecuteNonQuery();
                sq.Close();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ms), true);

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);
            
        }
    }

}