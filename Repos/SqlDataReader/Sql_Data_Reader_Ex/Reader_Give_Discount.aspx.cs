using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Reader_Give_Discount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["DataReaderConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from dbo.tblProductInventory";
            cmd.Connection = con;
            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                //store each row in a table row
                DataTable myTable = new DataTable(); //create the table object then add each row
                myTable.Columns.Add("ProductId");
                myTable.Columns.Add("ProductName");
                myTable.Columns.Add("UnitPrice"); //this is the original price in the database
                myTable.Columns.Add("DiscountedPrice"); //this is a calculated column and is calc row by row
                while (rdr.Read())  //process row by row
                {
                    DataRow myRow = myTable.NewRow();
                    double unitPrice = Convert.ToInt32(rdr["UnitPrice"]); //returns a string Use Convert.ToIt32(row)
                    double discountPrice =  unitPrice * .90;
                    string productName = Convert.ToString(rdr["ProductName"]);
                    string productID = Convert.ToString(rdr["ProductId"]);
                    //add to tables data rows
                    myRow["ProductId"] = productID;
                    myRow["ProductName"] = productName;
                    myRow["UnitPrice"] = unitPrice;
                    myRow["DiscountedPrice"] = discountPrice;
                    //create a data row and populate the columns of the data row then add to the table
                    myTable.Rows.Add(myRow);
                }
                //while reader read fill table then after while loop add to web control
                GridView1.DataSource = myTable;
                GridView1.DataBind();
            }

        }

    }
}