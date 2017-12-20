using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class NewEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "spAddEmployee";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //use collection property of the command type stored procedures object
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Title", ddlTitle.SelectedValue);
            cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
            SqlParameter myOutputParm = new SqlParameter(); //this is an output parameter
            myOutputParm.ParameterName = "@EmpId";
            myOutputParm.SqlDbType = System.Data.SqlDbType.Int;
            myOutputParm.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(myOutputParm);

            cmd.Connection = con;
            con.Open();

            cmd.ExecuteNonQuery();
            string newEmpId = myOutputParm.Value.ToString();
            lblMessage.Text = "New Employee ID is " + newEmpId;

        }

    }
}