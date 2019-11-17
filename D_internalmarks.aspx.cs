
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
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
   

protected void get_result_Click(object sender, EventArgs e)
    {
        string path = Server.MapPath("~/" + Session["user"].ToString() +"/Result/");
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
        GETpdf(path);
        //string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "E:\\data1.xls" + ";Extended Properties='Excel 8.0;HDR=Yes;';";        //OleDbConnection conn = new OleDbConnection(con);        //conn.Open();        //OleDbCommand cmd = new OleDbCommand("insert into [Sheet1$] (name) values('hahhaha')", conn);        //OleDbDataReader rd = cmd.ExecuteReader();               //while (rd.Read())        //{        //    string s = rd["GSTIN"].ToString();        //}
    }
    private void GETpdf(string path)
    {
       try
        {
            string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + "E:\\data22.xls" + ";Extended Properties='Excel 8.0;HDR=Yes;';";
            OleDbConnection conn = new OleDbConnection(con);
            conn.Open();
            string abc = students.SelectedValue;
            OleDbCommand cmd = new OleDbCommand("Select * from [Sheet1$] where std_id='"+students.SelectedValue+"'", conn);
            OleDbDataReader rd = cmd.ExecuteReader();
            rd.Read();
                Document dt = new Document(PageSize.A4.Rotate(), 10, 10, 20, 10);
                PdfWriter wr = PdfWriter.GetInstance(dt, new FileStream(path + DateTime.Now.Year + "studentresult.pdf", FileMode.Create));
                dt.Open();//create a 'dt' size 'wr' named pdf file and open it.
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);//define a font for file.
                iTextSharp.text.Font subhead = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);//modifying the font styling
                iTextSharp.text.Font head = new iTextSharp.text.Font(bfTimes, 18, iTextSharp.text.Font.UNDERLINE, BaseColor.BLACK);
                iTextSharp.text.Font bsubhead = new iTextSharp.text.Font(bfTimes, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                Paragraph p1 = new Paragraph("Uttrakhand Technical University" + Environment.NewLine, head);
                p1.Alignment = Element.ALIGN_CENTER;
                p1.SpacingAfter = 10;

                Paragraph p2 = new Paragraph("Provisonal Marksheet" + Environment.NewLine + "B.TECH Year Specified (Session))" + Environment.NewLine + "Dept of Secfied Branch", subhead);
                p2.Alignment = Element.ALIGN_CENTER;
            
               Paragraph p3 = new Paragraph("Name of Candidate  "+ rd["Student_name"].ToString().Replace("_"," ")+"                                                                                                                                                                                                     Enroll & Roll No."+ rd["Roll_No"].ToString().Replace("_", " ") + Environment.NewLine + "Father's Name "+ rd["Father_Name"].ToString().Replace("_", " ") + Environment.NewLine + "Name of Institute INSTITUTE OF TECHNOLOGY GOPESHWAR", subhead);

                PdfPTable part = new PdfPTable(2);//#begining    table partition starts
                part.WidthPercentage = 95;
                float[] w = { 50f, 50f };
                part.AddCell(new Phrase("i th Semester", subhead));
                part.SetWidths(w);
                part.SpacingBefore = 10;
                part.SpacingAfter = part.CalculateHeights();

                PdfPTable part2 = new PdfPTable(6);//#structure    table partition starts
                part2.WidthPercentage = 95;
                float[] w2 = { 40f, 30f, 30f, 40f, 30f, 30f };
                part2.AddCell(new Phrase("Subject Name", subhead));
                part2.AddCell(new Phrase("Maximum Marks", subhead));
                part2.AddCell(new Phrase("Marks Obtained", subhead));
                part2.AddCell(new Phrase("Subject Name", subhead));
                part2.AddCell(new Phrase("Maximum Marks", subhead));
                part2.AddCell(new Phrase("Marks Obtained", subhead));
                part2.SetWidths(w2);

                PdfPTable part3 = new PdfPTable(14);//#Defination    table partition starts
                part3.WidthPercentage = 95;
                float[] w3 = { 40f, 10f, 10f, 10f, 10f, 10f, 10f, 40f, 10f, 10f, 10f, 10f, 10f, 10f };
                part3.AddCell(new Phrase("                       Theory", bsubhead));
                part3.AddCell(new Phrase("   Exam", bsubhead));
                part3.AddCell(new Phrase("   Sess.", bsubhead));
                part3.AddCell(new Phrase("   Total", bsubhead));
                part3.AddCell(new Phrase("   Exam", bsubhead));
                part3.AddCell(new Phrase("   Sess", bsubhead));
                part3.AddCell(new Phrase("   Total", bsubhead));
            
                part3.AddCell(new Phrase("                       Theory", bsubhead));
                part3.AddCell(new Phrase("   Exam", bsubhead));
                part3.AddCell(new Phrase("   Sess.", bsubhead));
                part3.AddCell(new Phrase("   Total", bsubhead));
                part3.AddCell(new Phrase("   Exam", bsubhead));
                part3.AddCell(new Phrase("   Sess.", bsubhead));
                part3.AddCell(new Phrase("   Total", bsubhead));
                part3.SetWidths(w3);


                PdfPTable subs = new PdfPTable(14);//#Subjects    table partition starts
                subs.WidthPercentage = 95;
                subs.AddCell(new Phrase("i th sem subject 1", subhead));
                subs.AddCell(new Phrase(rd["MMsub1"].ToString(), subhead));
                subs.AddCell(new Phrase(rd["SMsub1"].ToString(), subhead));
                subs.AddCell(new Phrase(rd["TMsub1"].ToString(), subhead));
                subs.AddCell(new Phrase(rd["OBsub1"].ToString(), subhead));
                subs.AddCell(new Phrase(rd["SOsub1"].ToString(), subhead));
                subs.AddCell(new Phrase(rd["TOsub1"].ToString(), subhead));
               subs.SetWidths(w3);

                PdfPTable sub2 = new PdfPTable(14);//#Subjects    table partition starts
                sub2.WidthPercentage = 95;
                sub2.AddCell(new Phrase("i th sem subject 1", subhead));
                sub2.AddCell(new Phrase(rd["MMsub2"].ToString(), subhead));
                sub2.AddCell(new Phrase(rd["SMsub2"].ToString(), subhead));
                sub2.AddCell(new Phrase(rd["TMsub2"].ToString(), subhead));
                sub2.AddCell(new Phrase(rd["OBsub2"].ToString(), subhead));
                sub2.AddCell(new Phrase(rd["SOsub2"].ToString(), subhead));
                sub2.AddCell(new Phrase(rd["TOsub2"].ToString(), subhead));
                sub2.SetWidths(w3);


                PdfPTable sub3 = new PdfPTable(14);//#Subjects    table partition starts
                sub3.WidthPercentage = 95;
                sub3.AddCell(new Phrase("i th sem subject 1", subhead));
                sub3.AddCell(new Phrase(rd["MMsub3"].ToString(), subhead));
                sub3.AddCell(new Phrase(rd["SMsub3"].ToString(), subhead));
                sub3.AddCell(new Phrase(rd["TMsub3"].ToString(), subhead));
                sub3.AddCell(new Phrase(rd["OBsub3"].ToString(), subhead));
                sub3.AddCell(new Phrase(rd["SOsub3"].ToString(), subhead));
                sub3.AddCell(new Phrase(rd["TOsub3"].ToString(), subhead));

                sub3.SetWidths(w3);

                PdfPTable sub4 = new PdfPTable(14);//#Subjects    table partition starts
                sub4.WidthPercentage = 95;
                sub4.AddCell(new Phrase("i th sem subject 1", subhead));
                sub4.AddCell(new Phrase(rd["MMsub4"].ToString(), subhead));
                sub4.AddCell(new Phrase(rd["SMsub4"].ToString(), subhead));
                sub4.AddCell(new Phrase(rd["TMsub4"].ToString(), subhead));
                sub4.AddCell(new Phrase(rd["OBsub4"].ToString(), subhead));
                sub4.AddCell(new Phrase(rd["SOsub4"].ToString(), subhead));
                sub4.AddCell(new Phrase(rd["TOsub4"].ToString(), subhead));



                sub4.SetWidths(w3);

                PdfPTable sub5 = new PdfPTable(14);//#Subjects    table partition starts
                sub5.WidthPercentage = 95;
                sub5.AddCell(new Phrase("i th sem subject 1", subhead));
                sub5.AddCell(new Phrase(rd["MMsub5"].ToString(), subhead));
                sub5.AddCell(new Phrase(rd["SMsub5"].ToString(), subhead));
                sub5.AddCell(new Phrase(rd["TMsub5"].ToString(), subhead));
                sub5.AddCell(new Phrase(rd["OBsub5"].ToString(), subhead));
                sub5.AddCell(new Phrase(rd["SOsub5"].ToString(), subhead));
                sub5.AddCell(new Phrase(rd["TOsub5"].ToString(), subhead));

                sub5.SetWidths(w3);

                PdfPTable sub6= new PdfPTable(14);//#Subjects    table partition starts
                sub6.WidthPercentage = 95;
                sub6.AddCell(new Phrase("i th sem subject 1", subhead));
                sub6.AddCell(new Phrase(rd["MMsub6"].ToString(), subhead));
                sub6.AddCell(new Phrase(rd["SMsub6"].ToString(), subhead));
                sub6.AddCell(new Phrase(rd["TMsub6"].ToString(), subhead));
                sub6.AddCell(new Phrase(rd["OBsub6"].ToString(), subhead));
                sub6.AddCell(new Phrase(rd["SOsub6"].ToString(), subhead));
                sub6.AddCell(new Phrase(rd["TOsub6"].ToString(), subhead));



                sub6.SetWidths(w3);

                PdfPTable part4 = new PdfPTable(14);//#PRACS    table partition starts
                part4.WidthPercentage = 95;
                part4.AddCell(new Phrase("                       PRACTICAL", bsubhead));
                part4.AddCell(new Phrase("   EXT", bsubhead));
                part4.AddCell(new Phrase("   INTR", bsubhead));
                part4.AddCell(new Phrase("   Total", bsubhead));
                part4.AddCell(new Phrase("   EXT", bsubhead));
                part4.AddCell(new Phrase("   INTR", bsubhead));
                part4.AddCell(new Phrase("   Total", bsubhead));
                part4.AddCell(new Phrase("                       PRACTICAL", bsubhead));
                part4.AddCell(new Phrase("   EXT", bsubhead));
                part4.AddCell(new Phrase("   INTR", bsubhead));
                part4.AddCell(new Phrase("   Total", bsubhead));
                part4.AddCell(new Phrase("   EXT", bsubhead));
                part4.AddCell(new Phrase("   INTR", bsubhead));
                part4.AddCell(new Phrase("   Total", bsubhead));
                part4.SetWidths(w3);


                PdfPTable pracs = new PdfPTable(14);//#Prac_def    table partition starts
                pracs.WidthPercentage = 95;
                pracs.AddCell(new Phrase("i th sem Practical 1", subhead));
                pracs.AddCell(new Phrase(rd["PRMsub1"].ToString(), subhead));
                pracs.AddCell(new Phrase(rd["PRMisub1"].ToString(), subhead));
                pracs.AddCell(new Phrase(rd["TPRsub1"].ToString(), subhead));
                pracs.AddCell(new Phrase(rd["Oprsub1"].ToString(), subhead));
                pracs.AddCell(new Phrase(rd["Oprisub1"].ToString(), subhead));
                pracs.AddCell(new Phrase(rd["OTsub1"].ToString(), subhead));
                pracs.SetWidths(w3);


                PdfPTable prac2 = new PdfPTable(14);//#Prac_def    table partition starts
                prac2.WidthPercentage = 95;
                prac2.AddCell(new Phrase("i th sem Practical 1", subhead));
                prac2.AddCell(new Phrase(rd["PRMsub2"].ToString(), subhead));
                prac2.AddCell(new Phrase(rd["PRMisub2"].ToString(), subhead));
                prac2.AddCell(new Phrase(rd["TPRsub2"].ToString(), subhead));
                prac2.AddCell(new Phrase(rd["Oprsub2"].ToString(), subhead));
                prac2.AddCell(new Phrase(rd["Oprisub2"].ToString(), subhead));
                prac2.AddCell(new Phrase(rd["OTsub2"].ToString(), subhead));
              

               prac2.SetWidths(w3);

                PdfPTable prac3 = new PdfPTable(14);//#Prac_def    table partition starts
                prac3.WidthPercentage = 95;
                prac3.AddCell(new Phrase("i th sem Practical 1", subhead));
                prac3.AddCell(new Phrase(rd["PRMsub3"].ToString(), subhead));
                prac3.AddCell(new Phrase(rd["PRMisub3"].ToString(), subhead));
                prac3.AddCell(new Phrase(rd["TPRsub3"].ToString(), subhead));
                prac3.AddCell(new Phrase(rd["Oprsub3"].ToString(), subhead));
                prac3.AddCell(new Phrase(rd["Oprisub3"].ToString(), subhead));
                prac3.AddCell(new Phrase(rd["OTsub3"].ToString(), subhead));



                prac3.SetWidths(w3);


                PdfPTable prac4 = new PdfPTable(14);//#Prac_def    table partition starts
                prac4.WidthPercentage = 95;
                prac4.AddCell(new Phrase("i th sem Practical 1", subhead));
                prac4.AddCell(new Phrase(rd["PRMsub4"].ToString(), subhead));
                prac4.AddCell(new Phrase(rd["PRMisub4"].ToString(), subhead));
                prac4.AddCell(new Phrase(rd["TPRsub4"].ToString(), subhead));
                prac4.AddCell(new Phrase(rd["Oprsub4"].ToString(), subhead));
                prac4.AddCell(new Phrase(rd["Oprisub4"].ToString(), subhead));
                prac4.AddCell(new Phrase(rd["OTsub4"].ToString(), subhead));


                  prac4.SetWidths(w3);



                PdfPTable bottom = new PdfPTable(4);//#Prac_def    table partition starts
                float[] w4 = { 25f, 12.5f, 50f, 12.5f };
                bottom.WidthPercentage = 75;
                bottom.AddCell(new Phrase("Carry Over (if any)", subhead));

                PdfPTable bot1 = new PdfPTable(2);//#Prac_def    table partition starts
                float[] ww = { 50f, 50f };
                bot1.AddCell(new Phrase("Total No.", subhead));
                bot1.AddCell(new Phrase("Subject Code.", subhead));
                bot1.AddCell(new Phrase(rd["carry"].ToString(), subhead));
                bot1.AddCell(new Phrase(rd["c_code"].ToString(), subhead));
                bot1.SetWidths(ww);

                PdfPCell c = new PdfPCell(bot1);

                bottom.AddCell(new Phrase("Grace Marks (if any)", subhead));
                bottom.AddCell(new Phrase("Marks Obtained /Maximum Marks", subhead));
                bottom.AddCell(new Phrase("Result", subhead));

                bottom.AddCell(c);
                bottom.AddCell(new Phrase(rd["grace"].ToString(),subhead));
               
              
                bottom.SpacingBefore = 20;

            PdfPTable bot2 = new PdfPTable(3);//#Prac_def    table partition starts
            float[] ww2 = { .33f, .33f, .33f };
            bot2.AddCell(new Phrase("i th Semester", subhead));
            bot2.AddCell(new Phrase("i+1 th Semester", subhead));
            bot2.AddCell(new Phrase("Grand Total", bsubhead));
            bot2.AddCell(new Phrase(rd["Gtotal"].ToString() + "/" + rd["GMMtotal"].ToString(), subhead));
            bot2.SetWidths(ww2);
            int val = Convert.ToInt32(rd["Gtotal"]);
            int val2 = Convert.ToInt32(rd["GMMtotal"]);

            rd.Close();
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("D:/helll.png");
            //img.ScaleToFit(120, 140);
            //img.Alignment = Element.ALIGN_RIGHT;

            cmd = new OleDbCommand("Select * from [Sheet2$] where std_id='"+students.SelectedValue+"'", conn);
              rd = cmd.ExecuteReader();
              rd.Read();
            bot2.AddCell(new Phrase(rd["Gtotal"].ToString() + "/" + rd["GMMtotal"].ToString(), subhead));
            bot2.AddCell(new Phrase((val+ Convert.ToInt32(rd["Gtotal"]))/2+"/"+ (val2 + Convert.ToInt32(rd["GMMtotal"]))/2, subhead));
            PdfPCell c2 = new PdfPCell(bot2);
            bottom.AddCell(c2);
            bottom.AddCell(new Phrase("Passed", bsubhead));
            bottom.SetWidths(w4);

            pracs.WidthPercentage = 95;
            pracs.AddCell(new Phrase("i=1th th sem Practical 1", subhead));
            pracs.AddCell(new Phrase(rd["PRMsub1"].ToString(), subhead));
            pracs.AddCell(new Phrase(rd["PRMisub1"].ToString(), subhead));
            pracs.AddCell(new Phrase(rd["TPRsub1"].ToString(), subhead));
            pracs.AddCell(new Phrase(rd["Oprsub1"].ToString(), subhead));
            pracs.AddCell(new Phrase(rd["Oprisub1"].ToString(), subhead));
            pracs.AddCell(new Phrase(rd["OTsub1"].ToString(), subhead));
            prac2.AddCell(new Phrase("i=1th th sem Practical 1", subhead));
            prac2.AddCell(new Phrase(rd["PRMsub2"].ToString(), subhead));
            prac2.AddCell(new Phrase(rd["PRMisub2"].ToString(), subhead));
            prac2.AddCell(new Phrase(rd["TPRsub2"].ToString(), subhead));
            prac2.AddCell(new Phrase(rd["Oprsub2"].ToString(), subhead));
            prac2.AddCell(new Phrase(rd["Oprisub2"].ToString(), subhead));
            prac2.AddCell(new Phrase(rd["OTsub2"].ToString(), subhead));
            prac3.AddCell(new Phrase("i=1th th sem Practical 1", subhead));
            prac3.AddCell(new Phrase(rd["PRMsub3"].ToString(), subhead));
            prac3.AddCell(new Phrase(rd["PRMisub3"].ToString(), subhead));
            prac3.AddCell(new Phrase(rd["TPRsub3"].ToString(), subhead));
            prac3.AddCell(new Phrase(rd["Oprsub3"].ToString(), subhead));
            prac3.AddCell(new Phrase(rd["Oprisub3"].ToString(), subhead));
            prac3.AddCell(new Phrase(rd["OTsub3"].ToString(), subhead));
            prac4.AddCell(new Phrase("i=1th th sem Practical 1", subhead));
            prac4.AddCell(new Phrase(rd["PRMsub4"].ToString(), subhead));
            prac4.AddCell(new Phrase(rd["PRMisub4"].ToString(), subhead));
            prac4.AddCell(new Phrase(rd["TPRsub4"].ToString(), subhead));
            prac4.AddCell(new Phrase(rd["Oprsub4"].ToString(), subhead));
            prac4.AddCell(new Phrase(rd["Oprisub4"].ToString(), subhead));
            prac4.AddCell(new Phrase(rd["OTsub4"].ToString(), subhead));

            part.AddCell(new Phrase("i+1 th semester", subhead));
            subs.AddCell(new Phrase("i=1th th sem subject 1", subhead));
            subs.AddCell(new Phrase(rd["MMsub1"].ToString(), subhead));
            subs.AddCell(new Phrase(rd["SMsub1"].ToString(), subhead));
            subs.AddCell(new Phrase(rd["TMsub1"].ToString(), subhead));
            subs.AddCell(new Phrase(rd["OBsub1"].ToString(), subhead));
            subs.AddCell(new Phrase(rd["SOsub1"].ToString(), subhead));
            subs.AddCell(new Phrase(rd["TOsub1"].ToString(), subhead));
            sub2.AddCell(new Phrase("i=1th th sem subject 1", subhead));
            sub2.AddCell(new Phrase(rd["MMsub2"].ToString(), subhead));
            sub2.AddCell(new Phrase(rd["SMsub2"].ToString(), subhead));
            sub2.AddCell(new Phrase(rd["TMsub2"].ToString(), subhead));
            sub2.AddCell(new Phrase(rd["OBsub2"].ToString(), subhead));
            sub2.AddCell(new Phrase(rd["SOsub2"].ToString(), subhead));
            sub2.AddCell(new Phrase(rd["TOsub2"].ToString(), subhead));
            sub3.AddCell(new Phrase("i=1th th sem subject 1", subhead));
            sub3.AddCell(new Phrase(rd["MMsub3"].ToString(), subhead));
            sub3.AddCell(new Phrase(rd["SMsub3"].ToString(), subhead));
            sub3.AddCell(new Phrase(rd["TMsub3"].ToString(), subhead));
            sub3.AddCell(new Phrase(rd["OBsub3"].ToString(), subhead));
            sub3.AddCell(new Phrase(rd["SOsub3"].ToString(), subhead));
            sub3.AddCell(new Phrase(rd["TOsub3"].ToString(), subhead));
            sub4.AddCell(new Phrase("i=1th th sem subject 1", subhead));
            sub4.AddCell(new Phrase(rd["MMsub4"].ToString(), subhead));
            sub4.AddCell(new Phrase(rd["SMsub4"].ToString(), subhead));
            sub4.AddCell(new Phrase(rd["TMsub4"].ToString(), subhead));
            sub4.AddCell(new Phrase(rd["OBsub4"].ToString(), subhead));
            sub4.AddCell(new Phrase(rd["SOsub4"].ToString(), subhead));
            sub4.AddCell(new Phrase(rd["TOsub4"].ToString(), subhead));
            sub5.AddCell(new Phrase("i=1th th sem subject 1", subhead));
            sub5.AddCell(new Phrase(rd["MMsub5"].ToString(), subhead));
            sub5.AddCell(new Phrase(rd["SMsub5"].ToString(), subhead));
            sub5.AddCell(new Phrase(rd["TMsub5"].ToString(), subhead));
            sub5.AddCell(new Phrase(rd["OBsub5"].ToString(), subhead));
            sub5.AddCell(new Phrase(rd["SOsub5"].ToString(), subhead));
            sub5.AddCell(new Phrase(rd["TOsub5"].ToString(), subhead));
            sub6.AddCell(new Phrase("i=1th th sem subject 1", subhead));
            sub6.AddCell(new Phrase(rd["MMsub6"].ToString(), subhead));
            sub6.AddCell(new Phrase(rd["SMsub6"].ToString(), subhead));
            sub6.AddCell(new Phrase(rd["TMsub6"].ToString(), subhead));
            sub6.AddCell(new Phrase(rd["OBsub6"].ToString(), subhead));
            sub6.AddCell(new Phrase(rd["SOsub6"].ToString(), subhead));
            sub6.AddCell(new Phrase(rd["TOsub6"].ToString(), subhead));

                 dt.Add(p1);
                dt.Add(p2);
                dt.Add(p3);
                dt.Add(part);
                dt.Add(part2);
                dt.Add(part3);
                dt.Add(subs);
                dt.Add(sub2);
                dt.Add(sub3);
                dt.Add(sub4);
                dt.Add(sub5);
                dt.Add(sub6);
                dt.Add(part4);
                dt.Add(pracs);
                dt.Add(prac2);
                dt.Add(prac3);
                dt.Add(prac4);
                dt.Add(bottom);
            rd.Close();
            dt.Close();
            

        }
        catch (Exception ex)
        {
            Response.Write("unable GetResult File Missing or Inaccurate format" + Environment.NewLine + "Error code 12420" + Environment.NewLine);// + ex.ToString());

        }
    }


    protected void Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlConnection sq = new SqlConnection(s);
        sq.Open();
        SqlCommand c = new SqlCommand("Select name,Std_id from "+(Session["user"].ToString()).Substring(0,2)+Year.SelectedValue+"", sq);
        SqlDataReader rd =  c.ExecuteReader();
        while(rd.Read())
        {
            System.Web.UI.WebControls.ListItem list = new System.Web.UI.WebControls.ListItem();
            list.Value = rd["std_id"].ToString();
            list.Text = rd["name"].ToString();
            students.Items.Add(list);
        }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

    }

   
}