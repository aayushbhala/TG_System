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
        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
        string query = "SELECT SID,Student.Department AS Department,Section,Teacher.Name AS Name,count(*) AS Total FROM Student LEFT JOIN Teacher ON Student.TID = Teacher.TID GROUP BY SID,Student.Department,Section,Teacher.Name;";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "SlotsInfo");
            ShowSlotsGV.DataSource = ds;
            ShowSlotsGV.DataBind();
        }
        catch(Exception err)
        {
            errLabel.Text = "Unable to fetch data! " + err;
        }
        finally
        {
            con.Close();
        }
    }
}