using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
            string query = "SELECT SID,Student.Department AS Department,Section,count(*) AS Total FROM Student FULL OUTER JOIN Teacher ON Student.TID = Teacher.TID GROUP BY SID,Student.Department,Section,Teacher.Name HAVING Teacher.Name IS NULL;";
            string filled_query = "SELECT SID,Teacher.Name AS Name,Student.Department AS Department,Section,count(*) AS Total FROM Student INNER JOIN Teacher ON Student.TID = Teacher.TID GROUP BY SID,Student.Department,Section,Teacher.Name HAVING Teacher.Name IS NOT NULL;";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "SlotsInfo");
                ShowSlotsGV.DataSource = ds.Tables["SlotsInfo"];
                ShowSlotsGV.DataBind();
                cmd.CommandText = filled_query;
                adapter.Fill(ds, "FilledSlotsInfo");
                FilledGV.DataSource = ds.Tables["FilledSlotsInfo"];
                FilledGV.DataBind();

                
            }
            catch (Exception err)
            {
                errLabel.Text = "Unable to fetch data! " + err;
            }
            finally
            {
                con.Close();
            }
        }
    }

    protected void ShowSlotsGV_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "apply_btn")
        {
            SqlConnection con = new SqlConnection();
            HttpCookie cookie = Request.Cookies["UserDetails"];
            con.ConnectionString = @"Data Source = (localdb)\MSSQLlocalDB;Initial Catalog = Project;Integrated Security = True;Pooling = False;";
            string query = "INSERT INTO Notification(Sender,Receiver,SID) VALUES (@sender,@recv,@sid);";
            int index = Convert.ToInt32(e.CommandArgument);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@sender",cookie["ID"].ToString());
                cmd.Parameters.AddWithValue("@recv","0");
                cmd.Parameters.AddWithValue("@sid",e.CommandArgument.ToString());
                cmd.ExecuteNonQuery();
                Response.Redirect("ProfilePage.aspx");
            }
            catch (Exception err)
            {
                errLabel.Text = "Unable to send apply request! " + err;
            }
            finally
            {
                con.Close();
            }
        }
    }
}