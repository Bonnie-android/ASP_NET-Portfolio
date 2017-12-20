using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class SqlAdaptManyTablesDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ProductDBConnectionString
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
              SqlDataAdapter da = new SqlDataAdapter("spGetData", con);
          //  SqlDataAdapter da = new SqlDataAdapter("spProductInventory", con);
          // da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet myDS = new DataSet();
            da.Fill(myDS);
            myDS.Tables[0].TableName = "ProductInv";
            myDS.Tables[1].TableName = "Catalog";
            //myDS now contains two tables
            gridProdInv.DataSource = myDS.Tables["ProductInv"];
            gridProdInv.DataBind();
            gridCatalog.DataSource = myDS.Tables["Catalog"];
            gridCatalog.DataBind();
        }

    }
}