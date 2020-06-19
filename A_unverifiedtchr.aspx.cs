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
       
    }


    protected void send(string cm, string ms)
    {
        using (SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString))
        {
            sq.Open();
            SqlCommand cmd = new SqlCommand(cm, sq);
            cmd.ExecuteNonQuery();
            Response.Write(ms);
            sq.Close();
        }

    }
    protected void Verify_Click(object sender, EventArgs e)
    {
        try
        {  foreach (ListItem name in CheckBoxList1.Items)
        {
            if (name.Selected)
            {
                string n = Convert.ToString(name);
                string a = "update auth set status ='Verified' where username='" + name + "'";
                string ab = "update itgfaculty set status ='Verified' where Tech_id='" + name + "'";
                send(ab, n.Substring(0, 6));
                send(a, "");
            }
            }
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);
        }
    }

    protected void Verify0_Click(object sender, EventArgs e)
    {
        try { 
        using (SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString))
        {

            sq.Open();

            string q = "select username from auth where status='Unverified' and utype='Faculty' ";
            string q1 = "select Tech_id,name as [Name],dob as [DOB],fname as [Father Name],mname as [mother's Name] ,aadhar,address,mob as [Mobile],mail from ITGFaculty where status='Unverified'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(q, sq);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                CheckBoxList1.DataSource = dt;
                CheckBoxList1.DataTextField = "username";
                CheckBoxList1.DataBind();
                dt = new DataTable();
                SqlDataAdapter d1 = new SqlDataAdapter(q1, sq);
                d1.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    da.Dispose();
                    dt.Clear();
                }
            }
            sq.Close();
        }
        CheckBoxList1.Visible = true;
        GridView1.Visible = true;
        Verify.Visible = true;
        Verify0.Visible = false;
        }
        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);
        }
    }

  
}