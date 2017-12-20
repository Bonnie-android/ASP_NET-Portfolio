using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class SqlDataReader_App : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //SqlDataReaderConnectionString
        string CS = ConfigurationManager.ConnectionStrings["SqlDataReaderConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.tblProductInventory";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();


        }
    }
}