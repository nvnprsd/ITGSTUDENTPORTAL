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
    string s = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        { string query = "create table " + Session["user"].ToString() + "att(std_id varchar(30) , name varchar(30)";

        foreach (ListItem tchr in facultylist.Items)
        {
            if(tchr.Selected)
            {
                query += ","+tchr.Value+"tc tinyint,"+tchr.Value+"tp tinyint,"+tchr.Value+"Percentage float";
            }
        }
        
        SqlConnection sq = new SqlConnection(s);
        sq.Open();
        SqlCommand c = new SqlCommand(query+")", sq);
        c.ExecuteNonQuery();// table created for attendance calculation by HOD depending on each faculty
        foreach (ListItem std in CheckBoxList1.Items)
        {
            SqlCommand saa = new SqlCommand("insert into " + Session["user"].ToString() + "att (std_id,name)values('" + std.Value + "','" + std.Text + "')", sq);
            saa.ExecuteNonQuery();
        }
        foreach (ListItem tchr in facultylist.Items)
        {
            if (tchr.Selected)
            {
                foreach (ListItem std in CheckBoxList1.Items)
                {
                    SqlCommand saa = new SqlCommand("update " + Session["user"].ToString() + "att set " + tchr.Value + "tp = (select sum( case when(status1 = 'P' and Fname1 = '" + tchr.Value + "') then 1 else 0 end +case when(status2 = 'P' and Fname2 = '" + tchr.Value + "') then 1 else 0 end + case when(status3 = 'P' and Fname3 = '" + tchr.Value + "') then 1 else 0 end + case when(status4 = 'P' and Fname4 = '" + tchr.Value + "') then 1 else 0 end + case when(status5 = 'P' and Fname5 = '" + tchr.Value + "') then 1 else 0 end + case when(status6 = 'P' and Fname6 = '" + tchr.Value + "') then 1 else 0 end)from " + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "att where Std_id = '" + std.Value + "')," + tchr.Value + "tc=(select sum(case when(Fname1 = '" + tchr.Value + "') then 1 else 0 end +case when(Fname2 = '" + tchr.Value + "') then 1 else 0 end +case when(Fname3 = '" + tchr.Value + "') then 1 else 0 end +case when(Fname4 = '" + tchr.Value + "') then 1 else 0 end +case when(Fname5 = '" + tchr.Value + "') then 1 else 0 end +case when(Fname6 = '" + tchr.Value + "') then 1 else 0 end) from " + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "att where Std_id = '" + std.Value + "') where std_id='"+std.Value+"'", sq);
                    saa.ExecuteNonQuery();
                    SqlCommand se = new SqlCommand("update " + Session["user"].ToString() + "att set  " + tchr.Value + "Percentage = (select round((" + tchr.Value + "tp * 100.00)*(1.0/" + tchr.Value + "tc), 2) from " + Session["user"].ToString() + "att where std_id = '" + std.Value + "') where std_id = '" + std.Value + "'", sq);
                    se.ExecuteNonQuery();
                }
            }
        }

        SqlDataAdapter ad = new SqlDataAdapter("select * from " + Session["user"].ToString() + "att", sq);
        DataSet ds = new DataSet();
        ad.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        SqlCommand sr = new SqlCommand("drop table " + Session["user"].ToString() + "att", sq);
        sr.ExecuteNonQuery();

        sq.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    protected void Year_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string s = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
        SqlConnection sq = new SqlConnection(s);
        sq.Open();
        SqlCommand cmd = new SqlCommand("select std_id,name from " + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "", sq);
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {

            if (rd.HasRows)
            {
                ListItem item = new ListItem();
                item.Text = rd["name"].ToString();
                item.Value = rd["Std_id"].ToString();
                CheckBoxList1.Items.Add(item);
            }
        }
        rd.Close();
        cmd = new SqlCommand("select username,name from auth where utype='faculty' and  dept='"+(Session["user"].ToString()).Substring(0,2)+"' and status='Verified' ", sq);// for retriving the faculty list
         rd = cmd.ExecuteReader();
        while (rd.Read())
        {

            if (rd.HasRows)
            {
                ListItem item = new ListItem();
                item.Text = rd["name"].ToString();
                item.Value = rd["username"].ToString();
                facultylist.Items.Add(item);
            }
        }
        rd.Close();
        sq.Close();
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "Key", string.Format("alert('{0}'); ", ex), true);

        }
    }

}