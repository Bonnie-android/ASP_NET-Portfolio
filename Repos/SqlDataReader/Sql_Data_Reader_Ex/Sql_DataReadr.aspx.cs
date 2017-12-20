using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class Sql_DataReadr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataReaderConnectionString
        string CS = ConfigurationManager.ConnectionStrings["DataReaderConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.tblProductInventory";
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }      
        }

    }
}