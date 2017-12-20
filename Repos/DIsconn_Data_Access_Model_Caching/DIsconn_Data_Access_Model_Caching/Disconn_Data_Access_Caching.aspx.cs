using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Disconn_Data_Access_Caching : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void btnLoadData_Click(object sender, EventArgs e)
    {
        if(Cache["Data"] is null) { 
            //ProductDBConnectionString
            string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tblProductInventory",con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //create cache object assign it user defined name "Data"
                //when empty Cache["Data"] will be null
                Cache["Data"] = ds; //allows it to be used outside the scope of button click
                gridProducts.DataSource = ds;
                gridProducts.DataBind();   
            }//end using
            lblMessage.Text = "Data Loaded From Database";
        }//end check cache for null
        else  //how to retrieve ds somewhere else in the program
        {
            gridProducts.DataSource = (DataSet) Cache["Data"];//must be cast as a DataSet
            gridProducts.DataBind();
            lblMessage.Text = "Data Loaded From Cache";
        }
    }

    protected void btnClearCache_Click(object sender, EventArgs e)
    {
        if(Cache["Data"] != null)
        {
            Cache.Remove("Data"); //we can use a cache expiry time
            lblMessage.Text = "Cache Emptied";
        }
    }
}