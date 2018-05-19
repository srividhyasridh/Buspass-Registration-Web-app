using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Default3 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\lenovo\Documents\online.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dr;
    SqlDataAdapter da;
    
    

    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Text = Session["name"].ToString();


                }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
       // cmd = new SqlCommand("create table renew(name nvarchar(50),date nvarchar(50))", con);
        cmd = new SqlCommand("insert into renew values('" + TextBox1.Text + "','"+Calendar1.SelectedDate + "')", con);
        cmd.ExecuteNonQuery();
        Response.Write("<Script>alert('renewed')</script>");
        //p++;
        con.Close();
    
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        con.Open();
        da = new SqlDataAdapter("select * from cpass right outer Join renew on cpass.sname=renew.name", con);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();

    }
}