using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

    protected void Branch0_TextChanged(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString))
            {

                sq.Open();

                string q1 = "select * from " + Branch0.SelectedValue + "books";
                DataTable dt = new DataTable();

                dt.Clear();
                SqlDataAdapter d1 = new SqlDataAdapter(q1, sq);
                d1.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    dt.Clear();

                }
                sq.Close();
            }


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }
}