using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies["UserDetails"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLlocalDB;Initial Catalog = Project;Integrated Security = True;Pooling = False;";
            string[] query = {"SELECT Sender,Teacher.Name AS Name,Receiver,Timestamp From Notification,Teacher WHERE Teacher.TID = Notification.Sender AND (Receiver = 0 OR Receiver = @ID);",
                "SELECT Sender,Teacher.Name AS Sender,Receiver,Timestamp From Notification,Teacher WHERE Teacher.TID = Notification.Sender AND Receiver = @ID ;" };
            int t = 0;
            string[] res = {" sent you a request!", " approved your request!" };
            string ID = cookie["ID"].ToString();
            if (cookie["UserType"].Equals("Teacher"))
            {
                t = 1;
            }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query[t], con);
                cmd.Parameters.AddWithValue("@ID",ID);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    string className = "";
                    DateTime dt = DateTime.ParseExact(reader["Timestamp"].ToString(), "dd-MMM-yy h:mm:ss tt",CultureInfo.InvariantCulture);
                    TimeSpan timespan = DateTime.Now - dt;
                    if (timespan.Days >= 1)
                        className += "notice notice-warning";
                    else
                        className += "notice notice-success";
                    HtmlGenericControl createDIV = new HtmlGenericControl("DIV");
                    createDIV.ID = "createDIV" + i;
                    createDIV.Attributes.Add("class", className);
                    createDIV.InnerHtml = reader["Name"].ToString() + res[t];
                    NotificationContainer.Controls.Add(createDIV);
                    i++;
                }
            }
            catch(Exception err)
            {
                errLabel.Text = "Unable to fetch notification " + err;
                errLabel.ForeColor = Color.Red;
            }
            finally
            {
                con.Close();
            }
        }

    }
}