using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class FacultyRegistration : System.Web.UI.Page
{
    string cm = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Register_Click(object sender, EventArgs e)
    {
        try {
            SqlConnection sq = new SqlConnection(cm);
            sq.Open();
            SqlCommand cmd = new SqlCommand("insert into ITGFaculty (prefix,Name,dob,Fname,Mname,aadhar,mob,mail,Dept,address)values('" + Branch.SelectedValue + "','" + name.Text + "','" + dob.Text + "','" + fname.Text + "','" + mname.Text + "','" + aadhar.Text + "','" + mob.Text + "','" + mail.Text + "','" + Branch.SelectedValue + "','"+address.Text+"')", sq);
            cmd.ExecuteNonQuery();
            SqlCommand fth = new SqlCommand("select TECH_Id from ITGFaculty where mail='" + mail.Text + "'", sq);
            SqlDataReader r = fth.ExecuteReader();
            r.Read();
            string sd = r["TECH_id"].ToString();
            r.Close();

            SqlCommand cmd1 = new SqlCommand("insert into auth (username,name,mail,password,utype,dept) values('" + sd + "','" + name.Text + "','" + mail.Text + "','" + password.Text + "','Faculty','" + Branch.SelectedValue + "')", sq);
            cmd1.ExecuteNonQuery();
            r.Dispose();
            sq.Close();
            string m = "Registration Request Taken By ITGopeshwar It may take some time to approve ! userid will be"+sd+"";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", m), true);


        }
        catch (Exception ex)
        { Response.Write(ex); }
    }
    
}
