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
        if (Branch.Text == "Select Branch" || Year.Text == "Select Year")
        {
            Response.Write("Branch and Year Must be selected");
        }
        else
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
                    Response.Write(m);
                    sq.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}