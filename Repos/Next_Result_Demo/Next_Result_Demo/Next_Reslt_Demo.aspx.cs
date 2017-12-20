using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Next_Reslt_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ProductDBConnectionString
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        using(SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from tblProductInventory;select * from tblProductCategory;select * from dbo.Employees";
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                gridProducts.DataSource = rdr;
                gridProducts.DataBind();

                while(rdr.NextResult())
                {
                    gridCategories.DataSource = rdr;
                    gridCategories.DataBind();

                    while(rdr.NextResult())
                    {
                        gridEmployees.DataSource = rdr;
                        gridEmployees.DataBind();
                    }
                    
                }
                
            }

        }

    }


}