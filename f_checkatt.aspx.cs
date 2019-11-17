using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    string cs = ConfigurationManager.ConnectionStrings["DBC"].ConnectionString;
    Label username;

    public string pclass;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("01:40") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("02:20"))
        {
            abrt();
            Server.Transfer("main.aspx");
        }
        if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("09:20") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("09:59"))
        {
            at.Text = "1";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("10:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("10:59"))
        {
            at.Text = "2";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("11:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("12:59"))
        {
            at.Text = "3";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("12:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("012:59"))
        {
            at.Text = "4";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("02:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("02:59"))
        {
            at.Text = "5";
        }
        else if (DateTime.Parse(DateTime.Now.ToString("hh:mm")) >= DateTime.Parse("03:23") && DateTime.Parse(DateTime.Now.ToString("hh:mm")) <= DateTime.Parse("03:59"))
        {
            at.Text = "6";
        }
    }


    protected void getatt()
    {
        

            try
            {
                using (SqlConnection sq = new SqlConnection(cs))
                {

                    string a = "select std_id,name from " + pclass + "tmp ";

                    sq.Open();
                    SqlCommand cmd = new SqlCommand(a, sq);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {

                        pr.Items.Clear();
                        while (rd.Read())
                        {
                            ListItem item = new ListItem();
                            item.Selected = true;
                            item.Text = rd["name"].ToString();
                            item.Value = rd["Std_id"].ToString();
                            pr.Items.Add(item);


                        }
                    }

                    rd.Close();
                    cmd = new SqlCommand("select distinct username, name from auth where username like '" + pclass + "%' and utype = 'Student' and status = 'Verified' except select distinct std_id,name from " + pclass + "tmp", sq);
                    rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                      
                        while (rd.Read())
                        {
                            ListItem item = new ListItem();
                            item.Text = rd["name"].ToString();
                            item.Value = rd["username"].ToString();
                        bool aa = false;
                      
                        foreach (ListItem it in ab.Items)
                        {
                            if (it.Value == item.Value)
                            {
                                aa = true;
                            }

                        }
                        if (aa == false)
                        {


                            ab.Items.Add(item);
                        }
                        }
                    }
                    rd.Close();
                    sq.Close();


                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
      
    }

    

    protected void checkatt_Click(object sender, EventArgs e)
    {

        try
        {
            int a = Convert.ToInt32(at.Text);
            SqlConnection sq = new SqlConnection(cs);
            sq.Open();
            foreach (ListItem item in ab.Items)
            {
                string tu = "";
                SqlCommand c = new SqlCommand("select * from " + pclass + "att where std_id = '" + item.Value + "'", sq);
                SqlDataReader rd = c.ExecuteReader();
                if (rd.HasRows)
                {
                    if (item.Selected == true)
                    {
                        //  Response.Write(item.Text + " /......is select");
                        tu = "update  " + pclass + "att set fname" + a + "='" + username.Text + "',status" + a + "='P' where std_id='" + item.Value + "'";
                    }
            else
            {
               // Response.Write(item.Text + " ......isnot");
                tu = "update  " + pclass + "att set fname" + a + "='" + username.Text + "',status" + a + "='A' where std_id='" + item.Value + "'";
            }

        }
                else
                {
                    if (item.Selected == true)
                    {
                        tu = "insert into " + pclass + "att (Std_id,fname" + a + ",status" + a + ")values('" + item.Value + "','" + username.Text + "','P')";
                    }
                    else
                    {
                        tu = "insert into " + pclass + "att (Std_id,fname" + a + ",status" + a + ")values('" + item.Value + "','" + username.Text + "','A')";

                    }

                }
                rd.Close();
                SqlCommand cmd = new SqlCommand(tu, sq);
                cmd.ExecuteNonQuery();


            }

            sq.Close();
            gtt();
           Response.Redirect("faculty.aspx");

        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

protected void pr_Load(object sender, EventArgs e)
    {
       username = (Label)Master.FindControl("username");

        try
        { using (SqlConnection sq = new SqlConnection(cs))
            {
                sq.Open();
                SqlCommand c = new SqlCommand("Select location from auth where username='" + username.Text + "'", sq);
                SqlDataReader rd = c.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    pclass = rd["location"].ToString();
                    Cstatus.Text = "You are in " + pclass;
                    rd.Close();
                    getatt();
                }
            }
            if (pclass == "NULL")
            {
                Server.Transfer("faculty.aspx");
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex);
        }

    }

    protected void abrt()
    {
        try
        { using (SqlConnection sq = new SqlConnection(cs))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand("update " + pclass + "att set fname" + at.Text.ToString() + "=NULL where date=convert(date, getdate())", sq);
                SqlCommand cm = new SqlCommand("update  auth set location='NULL', cstatus='Free' where username='" + username.Text + "'", sq);
                cmd.ExecuteNonQuery();
                cm.ExecuteNonQuery();
                sq.Close();
                 }
            gtt();
        }
        catch(Exception ex)
        { Response.Write(ex);
        }
    }
    protected void abort_Click(object sender, EventArgs e)
    {
        abrt();
        Server.Transfer("faculty.aspx");

    }
   void  gtt()
    {
        try
        {
            using (SqlConnection sq = new SqlConnection(cs))
            {
                sq.Open();
                SqlCommand cmd = new SqlCommand("drop table " + pclass + "tmp;", sq);
                SqlCommand cm = new SqlCommand("update  auth set location='NULL', cstatus='Free' where username='" + username.Text + "'", sq);
                cmd.ExecuteNonQuery();
                cm.ExecuteNonQuery();
                sq.Close();
                //Server.Transfer("f_takeclass.aspx");
            }
        }

        catch (Exception)
        { }

    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        pr.Items.Clear();
        ab.Items.Clear();
       getatt();
    }
}

