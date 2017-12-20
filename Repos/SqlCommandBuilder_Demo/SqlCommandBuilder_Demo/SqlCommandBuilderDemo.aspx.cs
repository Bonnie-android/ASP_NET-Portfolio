using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class SqlCommandBuilderDemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ProductDBConnectionString
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            string sqlQuery = "Select * from tblStudents where StudentID = " + txtStudentID.Text;
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataSet ds = new DataSet();
            
            da.Fill(ds,"Students");
            
            ViewState["SQL_QUERY"] = sqlQuery;
            ViewState["DATASET"] = ds;
            if(ds.Tables["Students"].Rows.Count > 0)
            {
                //grab the data row
                DataRow dr = ds.Tables["Students"].Rows[0];
                txtName.Text =  dr["StudentName"].ToString();
                ddlYear.SelectedValue =  dr["StudentGrade"].ToString();
                txtStudentID.Text =  dr["StudentID"].ToString();
                txtMarks.Text =  dr["StudentTotalMarks"].ToString();
            }
            else //not found
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = txtStudentID.Text + " Student ID Not Found In Database";

            }

        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            //for update we will use SqlDataAdapter
            SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            DataSet ds = (DataSet)ViewState["DATASET"];
            //in the dataset is a table called "Students"
            //bring in the changes from the web page and update ds first
            if (ds.Tables["Students"].Rows.Count > 0) //if there are rows to update
            {
                DataRow dr = ds.Tables["Students"].Rows[0];
                // dr["StudentID"] = txtStudentID.Text;
                dr["StudentName"] = txtName.Text;
                dr["StudentGrade"] = ddlYear.SelectedValue;
                dr["StudentTotalMarks"] = txtMarks.Text;

            }
            int rowsUpdated = da.Update(ds, "Students");
            if (rowsUpdated > 0)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = rowsUpdated.ToString() + " row(s) were updated";
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "No row(s) were updated";
            }
        }
    }
}