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

    }

    protected void post_Click(object sender, EventArgs e)
    {
        if (Year.Text == "Select Year")
        {
            Response.Write("Branch be selected");
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
          //  Response.Write(userid.Text);
            string s = "insert into notice (msg,sender,userid,target,expdate) values('" + msg.Text + "','" + name.Text + "','" + userid.Text + "','" + userid.Text.Substring(0, 2) + Year.SelectedValue + "','" + exp.Text + "')";
            string m = "Notice Posted";

            using (SqlConnection sq = new SqlConnection(cs))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand(s, sq);
                cmd.ExecuteNonQuery();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", m), true);

                sq.Close();
                Server.Transfer("faculty.aspx");
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }
}