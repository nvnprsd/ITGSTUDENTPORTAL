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

    protected void addbook_Click(object sender, EventArgs e)
    {
        if (Branch.Text == "Select Branch")
        {
            Response.Write("please Select Branch");
        }
        else
        {
            try
            {
                SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
                sq.Open();
                SqlCommand cmd = new SqlCommand("insert into " + Branch.SelectedValue + "books values('" + bid.Text + "','" + bname.Text + "','" + bauth.Text + "','" + copies.Text + "','" + copies.Text + "')", sq);
                cmd.ExecuteNonQuery();
                sq.Close();
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", "Book Added"), true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

            }
        }
    }

}