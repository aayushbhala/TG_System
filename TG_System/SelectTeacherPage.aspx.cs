using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string SID = Request.QueryString["SID"];

        string connString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);

        string query = "SELECT Name, Department FROM Teacher WHERE TID NOT IN (SELECT TID FROM Student WHERE TID IS NOT NULL);";
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet(); 
        try
        {
            conn.Open();
            adapter.Fill(ds, "freeTeachers");

            teachersList.DataSource = ds.Tables["freeTeachers"];
            this.DataBind();
        }
        catch (Exception err)
        {
            errLabel.Text = "Unable to fetch data! " + err;
        }
        finally
        {
            conn.Close();
        }

    }
}