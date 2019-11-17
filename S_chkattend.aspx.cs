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
        if (!IsPostBack)
        {
            try
            { SqlConnection sq = new SqlConnection(s);
                sq.Open();
                SqlCommand cq = new SqlCommand("Select username,name from auth where utype='faculty' and dept='CS' and status='Verified'", sq);
                SqlDataReader rd = cq.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    ListItem i = new ListItem();
                    i.Text = rd["name"].ToString();
                    i.Value = rd["username"].ToString();
                    CheckBoxList1.Items.Add(i);
                }
                rd.Close();
                sq.Close();
            } 
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
    }


    protected void get_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sq = new SqlConnection(s);
            sq.Open();

            try
            {
                SqlCommand c = new SqlCommand("create table " + Session["user"].ToString() + "att(Tech_id varchar(30) , name varchar(30),tc tinyint,tp tinyint,per float)", sq);
                c.ExecuteNonQuery();
            }
            catch
            {
                SqlCommand c = new SqlCommand("truncate table " + Session["user"].ToString() + "att", sq);
                c.ExecuteNonQuery();

            }
            foreach (ListItem item in CheckBoxList1.Items)
            {
                if (item.Selected)
                {
                    SqlCommand saa = new SqlCommand("insert into " + Session["user"].ToString() + "att (Tech_id,name,tp,tc)values('" + item.Value + "','" + item.Text + "', (select sum( case when(status1 = 'P' and Fname1 = '" + item.Value + "') then 1 else 0 end +case when(status2 = 'P' and Fname2 = '" + item.Value + "') then 1 else 0 end + case when(status3 = 'P' and Fname3 = '" + item.Value + "') then 1 else 0 end + case when(status4 = 'P' and Fname4= '" + item.Value + "') then 1 else 0 end  + case when(status5 = 'P' and Fname5 = '" + item.Value + "') then 1 else 0 end + case when(status6 = 'P' and Fname6 = '" + item.Value + "') then 1 else 0 end)from CS2018Att where Std_id = '" + Session["user"].ToString() + "'), (select sum( case when(Fname1 = '" + item.Value + "') then 1 else 0 end +case when( Fname2 = '" + item.Value + "') then 1 else 0 end+ case when( Fname3 = '" + item.Value + "') then 1 else 0 end + case when( Fname4= '" + item.Value + "') then 1 else 0 end + case when (Fname5 = '" + item.Value + "') then 1 else 0 end + case when(Fname6 = '" + item.Value + "') then 1 else 0 end)from CS2018Att where Std_id = '" + Session["user"].ToString() + "') )", sq);
                    saa.ExecuteNonQuery();
                    SqlCommand se = new SqlCommand("update " + Session["user"].ToString() + "att set per = (select round((tp * 100.00)*(1.0/tc), 2) from " + Session["user"].ToString() + "att where Tech_id = '" + item.Value + "') where Tech_id = '" + item.Value + "'", sq);
                    se.ExecuteNonQuery();
                }
            }

            SqlDataAdapter ad = new SqlDataAdapter("select * from " + Session["user"].ToString() + "att ", sq);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            SqlCommand sa = new SqlCommand("drop table " + Session["user"].ToString() + "att", sq);
            // sa.ExecuteNonQuery();
            sq.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
}