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
    protected void find_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sq = new SqlConnection(cs);
            sq.Open();
            string q1 = "";
            if (student.Checked)
            {
                q1 = "select Std_id as id from cs" + Year.SelectedValue + "Library where bookid='" + serial.Text + "'";
            }
            else if (faculty.Checked)
            {
                q1 = "select Tech_id as id from facultyLibrary where bookid='" + serial.Text + "'";
            }
            SqlCommand cmd = new SqlCommand(q1, sq);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.HasRows)
            {
                findbooks.Items.Clear();
                while (r.Read())
                {
                    ListItem ls = new ListItem();
                    ls.Selected = true;
                    ls.Text = r["id"].ToString();
                    ls.Value = r["id"].ToString();
                    findbooks.Items.Add(ls);
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


    protected void faculty_CheckedChanged(object sender, EventArgs e)
    {
        if(faculty.Checked==true)
        {
            Year.Visible = false;
        }
    }

    protected void student_CheckedChanged(object sender, EventArgs e)
    {
        if (student.Checked == true)
        {
            Year.Visible = true;
        }
    }
}