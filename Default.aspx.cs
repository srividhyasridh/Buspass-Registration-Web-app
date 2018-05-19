using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\lenovo\Documents\online.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
    SqlCommand cmd = new SqlCommand();
   SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        con.Open();
        //cmd = new SqlCommand("create table regis(un nvarchar(50),pd nvarchar(50))", con);
       // cmd.ExecuteNonQuery();
       // Response.Write("<Script>alert('Successfully Registered')</script>");
        cmd = new SqlCommand("insert into regis values('" + TextBox1.Text + "','"+TextBox2.Text+"')", con);
        cmd.ExecuteNonQuery();
        Response.Write("<Script>alert('Successfully Registered!')</script>");
         con.Close();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["name"] = TextBox1.Text;
        con.Open();
        cmd = new SqlCommand("select * from regis where un='" + TextBox1.Text + "' and pd='" + TextBox2.Text + "' ", con);
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<Script>alert('Login success!')</script>");
            Response.Redirect("default2.aspx");


        }
        con.Close();
    }
}