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

    protected void Year_TextChanged(object sender, EventArgs e)
    {
        using (SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString))
        {

            sq.Open();
           
            string q = "select username from auth where status='Unverified' and utype='Student' and dept ='" + (Session["user"].ToString()).Substring(0, 2) + "'";
            string q1 = "select Std_id,name as [Name],dob as [DOB],fname as [Father Name],mname as [mother's Name] ,aadhar,address,mob as [Mobile],mail,interper as[12th %],passedclg as [Passed School],passedyer as [Year of passing] from " + (Session["user"].ToString()).Substring(0,2)+ Year.SelectedValue + " where status='Unverified'";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(q, sq);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                CheckBoxList2.DataSource = dt;
                CheckBoxList2.DataTextField = "username";
                CheckBoxList2.DataBind();
                dt.Clear();
                SqlDataAdapter d1 = new SqlDataAdapter(q1, sq);
                dt = new DataTable();
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
    protected void verify_Click(object sender, EventArgs e)
    {
        foreach (ListItem name in CheckBoxList2.Items)
        {
            if (name.Selected)
            {
                string n = Convert.ToString(name);
                string a = "update auth set status ='Verified' where username='" + name + "'";
                string ab = "update " + n.Substring(0, 6) + " set status ='Verified' where Std_id='" + name + "'";
                send(ab, n.Substring(0, 6));
                send(a, "");
            }
        }
    }
}