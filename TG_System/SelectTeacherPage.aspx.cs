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

        string query = "SELECT TID, Name, Department FROM Teacher WHERE TID NOT IN (SELECT TID FROM Student WHERE TID IS NOT NULL);";
        SqlCommand cmd = new SqlCommand(query, conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet(); 
        try
        {
            conn.Open();
            adapter.Fill(ds, "freeTeachers");

            teachersList.DataSource = ds;
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


    protected void assignTGBtn_Command(object sender, CommandEventArgs e)
    {
        string SID = Request.QueryString["SID"];
        string TID = e.CommandArgument.ToString();
        string connString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);

        string query = "UPDATE Student SET TID=@tid WHERE SID=@sid;";
        string query2 = "INSERT INTO Notification(Sender, Receiver) VALUES(@sender, @receiver);";

        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@tid", TID);
        cmd.Parameters.AddWithValue("@sid", SID);

        SqlCommand cmd2 = new SqlCommand(query2, conn);
        cmd2.Parameters.AddWithValue("@sender", Request.Cookies["UserDetails"]["ID"]);
        cmd2.Parameters.AddWithValue("@receiver", TID);
        try
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            Response.Redirect("ShowSlotsPage.aspx");
        }
        catch (Exception err)
        {
            errLabel.Text = "Unable to update data! " + err;
        }
        finally
        {
            conn.Close();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["Theme"] != null)
        {
            RadioButtonList themeList = (RadioButtonList)this.Master.FindControl("ThemeRadioButtonList");
            if (Session["Theme"].ToString().Equals("Darcula"))
            {
                themeList.SelectedIndex = 1;
            }
            else
                themeList.SelectedIndex = 0;
            Page.Theme = Session["Theme"].ToString();
        }
    }
}