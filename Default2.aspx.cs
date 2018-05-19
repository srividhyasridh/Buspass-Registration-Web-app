using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Collections;
using System.Text;
public partial class Default2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\lenovo\Documents\online.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dr;
    string fn,fn1,fn2,fn3;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox2.Text = Session["name"].ToString();

    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        fn = FileUpload1.FileName;
        FileUpload1.SaveAs(Server.MapPath(@"~/C:\Users\lenovo\Documents\Visual Studio 2010\WebSites\WebSite7\PHOTO\ "+ fn));
        fn1 = FileUpload2.FileName;
        FileUpload2.SaveAs(Server.MapPath(@"~/C:\Users\lenovo\Documents\Visual Studio 2010\WebSites\WebSite7\ID\ " + fn1));
        fn2 = FileUpload3.FileName;
        FileUpload3.SaveAs(Server.MapPath(@"~/C:\Users\lenovo\Documents\Visual Studio 2010\WebSites\WebSite7\BONAFIDE\ " + fn2));
        fn3 = FileUpload4.FileName;
        FileUpload4.SaveAs(Server.MapPath(@"~/C:\Users\lenovo\Documents\Visual Studio 2010\WebSites\WebSite7\SSC\ " + fn3));
        TextBox1.Text = Session["name"].ToString();
        con.Open();
        //cmd = new SqlCommand("create table cpass(sname nvarchar(50),adr nvarchar(50),scn nvarchar(10),md nvarchar(30),ph nvarchar(50),cst int)", con);
        cmd = new SqlCommand("insert into cpass values('" + TextBox2.Text + "','" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
        cmd.ExecuteNonQuery();
        //Response.Write("<Script>alert('Pass created..')</script>");
        con.Close();
        char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890".ToCharArray();
StringBuilder sb = new StringBuilder();
Random random = new Random();
for (int i = 0; i < 6; i++) {
    char c = chars[random.Next(chars.Length)];
    sb.Append(c);
}
String output = sb.ToString();
Response.Write("key=" + output);
Label8.Text = output;
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {


    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {

    }
}