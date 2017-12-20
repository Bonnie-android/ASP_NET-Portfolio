using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class MyGridView1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        /* System.Data.DataSet here is where the data set resides */


        /** EXACT SAME THING WRAPPED IN A USING { BLOCK 
        SqlConnection con = new SqlConnection("Data Source = LAPTOP-QKVFQ59K\\SQLEXPRESS; Initial Catalog = ProductDB; Integrated Security = True");
        try { 
            SqlCommand cmd = new SqlCommand("select * from dbo.tblProduct", con);
            con.Open();
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
        }
        catch
        {

        }
        finally
        {
            con.Close();
        }
    *******/
        string CS =  ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            // SqlCommand cmd = new SqlCommand("select * from dbo.tblProduct", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.tblProduct";
            cmd.Connection = con;
            con.Open();
            GridView2.DataSource = cmd.ExecuteReader();
            GridView2.DataBind();
        }

//reading a scalar value and passing it back to the web page in response stream
        using (SqlConnection con = new SqlConnection(CS))
        {
            // SqlCommand cmd = new SqlCommand("select * from dbo.tblProduct", con);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select count(*) from dbo.tblProduct"; //use  ExecuteScalar() and not ExecuteReader() returns a single value
            cmd.Connection = con;
            con.Open();
            //string myValue = cmd.ExecuteScalar().ToString();
            int thisValue = (int) cmd.ExecuteScalar();
            //Add this to the response stream .........
            Response.Write("<br/>The number of products is " + thisValue.ToString());
            
        }

        //Doing an insert into the Sql Server database Products and adding to the product table
        using (SqlConnection con = new SqlConnection(CS))
        {
            // SqlCommand cmd = new SqlCommand("select * from dbo.tblProduct", con);
           // SqlCommand cmd = new SqlCommand();
          //  cmd.CommandText = "insert into [ProductDB].[dbo].[tblProduct] values(11,'Headphones Model 300',50,100)"; //use  ExecuteScalar() and not ExecuteReader() returns a single value
          //  cmd.Connection = con;
          //  con.Open();
         //   int rowsEffected = cmd.ExecuteNonQuery(); 
          //  Response.Write("<br/>The item was succesfully added to the database with return code " + rowsEffected.ToString());

        }

        //Doing an insert into the Sql Server database Products and adding to the product table
        using (SqlConnection con = new SqlConnection(CS))
        {
            // SqlCommand cmd = new SqlCommand("select * from dbo.tblProduct", con);
          //  SqlCommand cmd = new SqlCommand();
          //  cmd.CommandText = "update  dbo.tblProduct set Name = 'Modem Model 111' where Name = 'Modem Model 100'"; //use  ExecuteScalar() and not ExecuteReader() returns a single value
          //  cmd.Connection = con;
          //  con.Open();
            //string myValue = cmd.ExecuteScalar().ToString();
          //  int rowsUpdated = cmd.ExecuteNonQuery();
            //Add this to the response stream .........
          //  Response.Write("<br/>Update was successfully done " + rowsUpdated.ToString());

        }

        //Use them all togeher in a single transaction not in separate transactions
        using (SqlConnection con = new SqlConnection(CS))
        {
            // SqlCommand cmd = new SqlCommand("select * from dbo.tblProduct", con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "update  dbo.tblProduct set Name = 'Modem Model 222' where Name = 'Modem Model 200'"; //use  ExecuteScalar() and not ExecuteReader() returns a single value
            int rowsUpdated = cmd.ExecuteNonQuery();
            Response.Write("<br/>Rows Updated " + rowsUpdated);
            cmd.CommandText = "insert into [ProductDB].[dbo].[tblProduct] values(12,'Keyboard Model 100',50,100)";
            int rowInserted = cmd.ExecuteNonQuery();
            Response.Write("<br/>Row successfully added");
            cmd.CommandText = "insert into [ProductDB].[dbo].[tblProduct] values(13,'Keyboard Model 200',50,100)";
            rowInserted = cmd.ExecuteNonQuery();
            Response.Write("<br/>Row successfully added");
        }


    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}