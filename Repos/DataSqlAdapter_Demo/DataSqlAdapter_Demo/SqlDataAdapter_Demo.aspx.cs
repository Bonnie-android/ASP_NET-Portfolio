using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SqlDataAdapter_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //ProductDBConnectionString
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("spProductInventoryById", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ProdID", TextBox1.Text);
            DataSet myDS = new DataSet();
            da.Fill(myDS); //this does the open close and load for us
            GridView1.DataSource = myDS;
            GridView1.DataBind();
        }
    }
}