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

    protected void GridView1_Load(object sender, EventArgs e)
    {
        try { 
        using (SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString))
        {

            sq.Open();

            string q1 = "select Tech_id,name as [Name],dob as [DOB],fname as [Father Name],mname as [mother's Name] ,aadhar,address,mob as [Mobile],mail from ITGFaculty where status='Verified' and dept='"+Branch.SelectedValue+"'";
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
            Response.Write(ex);
        }
    }
}