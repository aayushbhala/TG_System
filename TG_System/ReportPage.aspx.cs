using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
//rWS
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void genReportBtn_Click(object sender, EventArgs e)
    {
        List<string> sections = new List<string>();
        List<string> departments = new List<string>();

        foreach(ListItem li in deptList.Items)
        {
            if (li.Selected == true)
                departments.Add(li.Text);
        }

        foreach(ListItem li in secList.Items)
        {
            if (li.Selected == true)
                sections.Add(li.Text);
        }

        string connString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        
        string query1 = "SELECT DISTINCT Teacher.Name as TG, Student.SID as Slot, Section, Student.Department as Department FROM Teacher INNER JOIN Student ON Teacher.TID=Student.TID WHERE Student.TID IS NOT NULL";
        string query2 = "SELECT * FROM Student WHERE TID IS NOT NULL";
        string query3 = "SELECT DISTINCT SID as Slot, Department, Section FROM Student WHERE TID IS NULL";
        string query4 = "SELECT * FROM Student WHERE TID IS NULL";

        if (sections.Count != 0)
        {
            query1 += " AND Student.Section in (";
            query2 += " AND Section in (";
            query3 += " AND Section in (";
            query4 += " AND Section in (";

            foreach (string s in sections)
            {
                query1 += "'" + s + "', ";
                query2 += "'" + s + "', ";
                query3 += "'" + s + "', ";
                query4 += "'" + s + "', ";
            }
            query1 = query1.Remove(query1.Length - 2);
            query1 += ")";

            query2 = query2.Remove(query2.Length - 2);
            query2 += ")";

            query3 = query3.Remove(query3.Length - 2);
            query3 += ")";

            query4 = query4.Remove(query4.Length - 2);
            query4 += ")";
        }

        if (departments.Count != 0)
        {
            query1 += " AND Student.Department in (";
            query2 += " AND Department in (";
            query3 += " AND Student.Department in (";
            query4 += " AND Department in (";

            foreach (string s in departments)
            {
                query1 += "'" + s + "', ";
                query2 += "'" + s + "', ";
                query3 += "'" + s + "', ";
                query4 += "'" + s + "', ";
            }
            query1 = query1.Remove(query1.Length - 2);
            query1 += ");";

            query2 = query2.Remove(query2.Length - 2);
            query2 += ")";

            query3 = query3.Remove(query3.Length - 2);
            query3 += ");";

            query4 = query4.Remove(query4.Length - 2);
            query4 += ")";
        }

        System.Diagnostics.Debug.WriteLine(query1);
        System.Diagnostics.Debug.WriteLine("\n");
        System.Diagnostics.Debug.WriteLine(query2);
        System.Diagnostics.Debug.WriteLine("\n");
        System.Diagnostics.Debug.WriteLine(query3);
        System.Diagnostics.Debug.WriteLine("\n");
        System.Diagnostics.Debug.WriteLine(query1);

        query1 += ";";
        query2 += " ORDER BY SID;";
        query3 += ";";
        query4 += " ORDER BY SID;";

        SqlCommand cmd1 = new SqlCommand(query1, conn);
        SqlCommand cmd2 = new SqlCommand(query2, conn);
        SqlCommand cmd3 = new SqlCommand(query3, conn);
        SqlCommand cmd4 = new SqlCommand(query4, conn);

        DataSet ds = new DataSet();

        try
        {
            conn.Open();
            SqlDataAdapter adap = new SqlDataAdapter(cmd1);

            adap.Fill(ds, "Assigned");
            displayRepAssigned.DataSource = ds.Tables["Assigned"];
            
            adap = new SqlDataAdapter(cmd2);
            adap.Fill(ds, "AssignedSlots");
            displayRepAssignedSlots.DataSource = ds.Tables["AssignedSlots"];
            
            adap = new SqlDataAdapter(cmd3);
            adap.Fill(ds, "Vacant");
            displayRepVacant.DataSource = ds.Tables["Vacant"];

            adap = new SqlDataAdapter(cmd4);
            adap.Fill(ds, "VacantSlots");
            displayRepVacantSlots.DataSource = ds.Tables["VacantSlots"];

            this.DataBind();
            reportPanel.Visible = true;
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