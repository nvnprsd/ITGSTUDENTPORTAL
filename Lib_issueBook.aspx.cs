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
    string cm = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    int a = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Search_Click(object sender, EventArgs e)
    {
        P_status.Visible = true;
      issuedbooks.Items.Clear();
        try
        {
            name.Text = getdetail("select name from auth where username='" + id.Text + "' ");
            string utype = getdetail("select utype from auth where username='" + id.Text + "' ");
            string qu = "";
            if (student.Checked)
            {
                qu = "select* from " + Std_id.Text.Substring(0, 6) + "Library where Std_id = '" + id.Text + "' and status = 'Issued'";
            }
            else if (faculty.Checked)
            {
                qu = "select* from facultyLibrary where Tech_id = '" + id.Text + "' and status = 'Issued'";

            }
            SqlConnection sq = new SqlConnection(cm);
            sq.Open();
            SqlCommand cmd = new SqlCommand(qu, sq);
            SqlDataReader r;

            r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                issuedbooks.Items.Clear();
                while (r.Read())
                {
                    a++;
                   // Response.Write(a);
                    ListItem ls = new ListItem();
                    ls.Text = r["bookname"].ToString();
                    ls.Value = r["bookid"].ToString();
                    issuedbooks.Items.Add(ls);
                }
            }

            r.Close();
            sq.Close();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }


    protected void Assign_Click(object sender, EventArgs e)
    {

        if (a >= 8)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ","Maximum bookes are issued i.e 8"),true);
        }
        else
        {
            a++;
            try
            {
                string q1 = "";
                string k = getdetail("select bookname from " + Std_id.Text.Substring(0, 2) + "books where bookid='" + BookSerial.Text + "'");
                if (student.Checked)
                {
                    q1 = "insert into " + Std_id.Text.Substring(0, 6) + "Library values('" + id.Text + "','" + BookSerial.Text + "','Issued','" + k + "')";


                }
                else if (faculty.Checked)
                {
                    q1 = "insert into facultyLibrary values('" + id.Text + "','" + BookSerial.Text + "','Issued','" + k + "')";

                }
                SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
                sq.Open();
                SqlCommand cmd = new SqlCommand(q1, sq);
                SqlCommand cd = new SqlCommand("update " + Std_id.Text.Substring(0, 2) + "books set Rem_Copies=Rem_Copies-1 where bookid='" + BookSerial.Text + "'", sq);
                cd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ","Books Serial number Doesn't exist or No copies of book is available" + ex),true);

            }

        }
    }
  
    string getdetail(string aq)
    {
       
        SqlConnection sq = new SqlConnection(cm);
        sq.Open();
        SqlCommand fth = new SqlCommand(aq, sq);
        SqlDataReader r = fth.ExecuteReader();
        r.Read();
        string aaq = r[0].ToString();
        Std_id.Text = id.Text;
        sq.Close();
        r.Close();
        return aaq;
    }

    protected void return_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sq = new SqlConnection(ConfigurationManager.ConnectionStrings["DBC"].ConnectionString);
            sq.Open();
            foreach (ListItem it in issuedbooks.Items)
            {
                if (it.Selected)
                {
                    string q1 = "";
                    if (student.Checked)
                    {
                        q1 = "DELETE FROM " + Std_id.Text.Substring(0, 6) + "Library where bookid='" + it.Value + "'";
                    }
                    else if (faculty.Checked)
                    {
                        q1 = "DELETE FROM facultyLibrary where bookid='" + it.Value + "'";


                    }

                    SqlCommand cmd = new SqlCommand(q1, sq);
                    SqlCommand cd = new SqlCommand("update " + Std_id.Text.Substring(0, 2) + "books set Rem_Copies=Rem_Copies+1 where bookid='" + it.Value + "'", sq);
                    cd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();


                }
            }
            sq.Close();
            Server.Transfer("Library.aspx");


        }
        catch (Exception ex)
        {
            // Response.Write("4"+ex);
        }
    }

}