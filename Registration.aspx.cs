using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Registration : System.Web.UI.Page
{
    string d;
    string cm = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
       
     Year.Text = DateTime.Now.Year.ToString();
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Year.SelectedValue == "Select Branch" || Branch.SelectedValue == "Select Branch")
            {
                Response.Write("Typeand Branch Must be choosen");
            }
            else
            {

                if (Page.IsValid)
                {
                    SqlConnection sq = new SqlConnection(cm);
                    sq.Open();
                    d = Branch.SelectedValue + DateTime.Now.Year.ToString();
                    SqlCommand cmd = new SqlCommand("insert into " + Branch.SelectedValue + Year.SelectedValue + " (Name,dob,Fname,Mname,aadhar,address,mob,mail,Interper,passedclg,passedyer)values('" + name.Text + "','" + dob.Text + "','" + fname.Text + "','" + mname.Text + "','" + aadhar.Text + "','" + address.Text + "','" + mob.Text + "','" + mail.Text + "','" + interper.Text + "','" + passedclg.Text + "','" + passedyer.Text + "')", sq);
                    cmd.ExecuteNonQuery();
                    SqlCommand fth = new SqlCommand("select Std_Id from " + Branch.SelectedValue + Year.SelectedValue + " where mail='" + mail.Text + "'", sq);
                    SqlDataReader r = fth.ExecuteReader();
                    r.Read();
                    string sd = r["Std_id"].ToString();
                    r.Close();

                    SqlCommand cmd1 = new SqlCommand("insert into auth (username,name,mail,password,utype,dept) values('" + sd + "','" + name.Text + "','" + mail.Text + "','" + password.Text + "','Student','" + Branch.SelectedValue + "')", sq);
                    cmd1.ExecuteNonQuery();
                    r.Dispose();
                    sq.Close();
                    string m = "Registration Request Taken By ITGopeshwar your application under Process your username will be " + sd + "";
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", m), true);

                }
                else
                {
                    Response.Write("Please Enable JavaScript And Validate the Form");
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
  }
   
}