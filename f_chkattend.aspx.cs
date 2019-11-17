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
        if (Session["user"] == null)
        {
        }
        else
        {

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string s = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
            SqlConnection sq = new SqlConnection(s);
            sq.Open();
            try
            {
                SqlCommand c = new SqlCommand("create table " + Session["user"].ToString() + "att(std_id varchar(30) , name varchar(30),tc tinyint,tp tinyint,per float)", sq);
                c.ExecuteNonQuery();
            }
            catch
            {
                SqlCommand c = new SqlCommand("truncate table " + Session["user"].ToString() + "att", sq);
                c.ExecuteNonQuery();

            }
            foreach (ListItem item in CheckBoxList1.Items)
            {

                SqlCommand saa = new SqlCommand("insert into " + Session["user"].ToString() + "att (std_id,name,tp,tc)values('" + item.Value + "','" + item.Text + "', (select sum( case when(status1 = 'P' and Fname1 = '" + Session["user"].ToString() + "') then 1 else 0 end +case when(status2 = 'P' and Fname2 = '" + Session["user"].ToString() + "') then 1 else 0 end + case when(status3 = 'P' and Fname3 = '" + Session["user"].ToString() + "') then 1 else 0 end + case when(status4 = 'P' and Fname4= '" + Session["user"].ToString() + "') then 1 else 0 end + case when(status5 = 'P' and Fname5 = '" + Session["user"].ToString() + "') then 1 else 0 end + case when(status6 = 'P' and Fname6 = '" + Session["user"].ToString() + "') then 1 else 0 end)from " + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "att where Std_id = '" + item.Value + "')  , (select sum(case when(Fname1 = '" + Session["user"].ToString() + "') then 1 else 0 end +case when(Fname2 = '" + Session["user"].ToString() + "') then 1 else 0 end +case when(Fname3 = '" + Session["user"].ToString() + "') then 1 else 0 end +case when(Fname4 = '" + Session["user"].ToString() + "') then 1 else 0 end +case when(Fname5 = '" + Session["user"].ToString() + "') then 1 else 0 end +case when(Fname6 = '" + Session["user"].ToString() + "') then 1 else 0 end) from " + (Session["user"].ToString()).Substring(0, 2) + Year.SelectedValue + "att where Std_id = '" + item.Value + "'))", sq);
                saa.ExecuteNonQuery();
                SqlCommand se = new SqlCommand("update " + Session["user"].ToString() + "att set per = (select round((tp * 100.00)*(1.0/tc), 2) from " + Session["user"].ToString() + "att where std_id = '" + item.Value + "') where std_id = '" + item.Value + "'", sq);
                se.ExecuteNonQuery();
            }

            SqlDataAdapter ad = new SqlDataAdapter("select * from " + Session["user"].ToString() + "att", sq);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

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
                    item.Selected = true;
                    item.Text = rd["name"].ToString();
                    item.Value = rd["Std_id"].ToString();
                    CheckBoxList1.Items.Add(item);
                }
            }
            sq.Close();
        }

        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
}