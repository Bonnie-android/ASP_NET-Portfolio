using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Disconnected_Data_Model_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //ProductDBConnectionString
    }

    private void GetDataFromDB()
    {
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);
        string strSelectQuery = "Select * from dbo.tblStudents";
        SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);
        DataSet ds = new DataSet();
        da.Fill(ds, "Students"); //name result set table in fill step
        //I want to set the primary key of the result set table
        ds.Tables["Students"].PrimaryKey = new DataColumn[] { ds.Tables["Students"].Columns["StudentID"] };
        //cache table and put time limit on it
        Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(3), System.Web.Caching.Cache.NoSlidingExpiration);
        gridStudents.DataSource = ds;
        gridStudents.DataBind();
        lblMessage.Text = "Data Loaded From Database";
    }

    private void GetDataFromCache()
    {
        //retrieve data from cache and bind to gridview
        if(Cache["DATASET"] != null)
        {
            //retrieve dataset
            DataSet ds = (DataSet) Cache["DATASET"];
            gridStudents.DataSource = ds;
            gridStudents.DataBind();
            lblMessage.Text = "Data Loaded From Cache";

        }
    }

    protected void btnGetDataDB_Click(object sender, EventArgs e)
    {
        GetDataFromDB();
        
    }

    protected void gridStudents_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gridStudents.EditIndex = e.NewEditIndex;
        GetDataFromCache();
    }


    protected void gridStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //retrieve data from webform and update dataset
        //use e object to obtain information by primary key StudentID
        if(Cache["DATASET"] != null)
        {
            //retrieve dataset from Cache
           DataSet ds =  (DataSet) Cache["DATASET"];
           DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["StudentID"]);
            dr["StudentName"] = e.NewValues["StudentName"];
            dr["StudentGrade"] = e.NewValues["StudentGrade"];
            dr["StudentTotalMarks"] = e.NewValues["StudentTotalMarks"];
            //Move the altered dataset into Cache
            Cache.Insert("DATASET",ds,null,DateTime.Now.AddHours(3),System.Web.Caching.Cache.NoSlidingExpiration);
            gridStudents.EditIndex = -1;
            GetDataFromCache();
        }
    }


    protected void gridStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //to cancel give a EditIndex of -1 and pull dataset from cache
        gridStudents.EditIndex = -1;
        GetDataFromCache();
    }

    protected void gridStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if(Cache["DATASET"] != null)
        {
            //retrieve dataset from cache
            DataSet ds = (DataSet)Cache["DATASET"];
            //find the data row using primary key
            DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["StudentID"]);
         
            dr.Delete();
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(3), System.Web.Caching.Cache.NoSlidingExpiration);
           // gridStudents.EditIndex = -1; row was not set in edit mode
            GetDataFromCache();
        }
    }

    protected void gridStudents_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gridStudents_Sorting(object sender, GridViewSortEventArgs e)
    {

    }

    protected void gridStudents_PageIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gridStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void gridStudents_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gridStudents_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

    }

    protected void gridStudents_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string CS = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(CS);
        string strSelectQuery = "select * from dbo.Students"; //da needs a select query 
        SqlDataAdapter da = new SqlDataAdapter(strSelectQuery,con);
        DataSet ds = (DataSet)Cache["DATASET"];

        //Updates
        string strUpdateCommand = "Update dbo.tblStudents set StudentName = @StudentName, StudentGrade = @StudentGrade, StudentTotalMarks = @StudentTotalMarks where StudentID = @StudentID";
        SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);
        //Add parameters referenced above
        updateCommand.Parameters.Add("@StudentName", SqlDbType.VarChar, 20, "StudentName");
        updateCommand.Parameters.Add("@StudentGrade", SqlDbType.VarChar, 20, "StudentGrade");
        updateCommand.Parameters.Add("@StudentTotalMarks", SqlDbType.Int, 0, "StudentTotalMarks");
        updateCommand.Parameters.Add("@StudentID", SqlDbType.Int, 0, "StudentID");

        da.UpdateCommand = updateCommand;
       // da.Update(ds, "Students");
        

        //Deletes
        string strDeleteCommand = "Delete from dbo.tblStudents where StudentID = @StudentID";
        SqlCommand deleteCommand = new SqlCommand(strDeleteCommand, con);
        deleteCommand.Parameters.Add("@StudentID", SqlDbType.Int, 0, "StudentID");
        //associate the command with the adapter
        da.DeleteCommand = deleteCommand;
        da.Update(ds, "Students");

        lblMessage.Text = "Database Table Students Updated";


    }
}