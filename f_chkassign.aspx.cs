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
    string due = "";
    protected void DropDownList1_Load(object sender, EventArgs e)
    {
        try
        {

            using (SqlConnection sq = new SqlConnection(cs))
            {
                string l = Session["user"].ToString();
                SqlCommand cm = new SqlCommand("select sub_name,duedate from " + l.Substring(0, 2) + "giveassignments where duedate >= getdate()", sq);
                sq.Open();
                SqlDataReader d = cm.ExecuteReader();
                while (d.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = d["sub_name"].ToString();
                    item.Text = d["sub_name"].ToString() + " Due on " + d["duedate"].ToString();
                    due= d["duedate"].ToString();
                    DropDownList1.Items.Add(item);
                }

                d.Close();
                sq.Close();
            }

            if(DropDownList1.SelectedItem==null)
            {
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ","there is No Assignment given"),true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);


        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection sq = new SqlConnection(cs))
            {

                string dept = (Session["user"].ToString()).Substring(0, 2);
                SqlCommand cmd = new SqlCommand("select * from " + dept + "submittedassignments where sub_name='" + DropDownList1.SelectedValue + "' and duedate='"+due+"' ", sq);
                sq.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.HasRows)
                {
                }
                else
                {
                    while (rd.Read())
                    {
                        panel.Controls.Add(new LiteralControl("<h4><a runat\"=server\" href=" + rd["file_path"].ToString() + ">" + rd["Std_id"].ToString() + "  submitted on -" + rd["submitdate"].ToString() + "</a> </h4>"));

                    }
                }
                rd.Close();
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }
}