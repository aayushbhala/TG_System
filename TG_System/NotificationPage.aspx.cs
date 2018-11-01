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
using System.Web.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
            HttpCookie cookie = Request.Cookies["UserDetails"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
            string[] query = {"SELECT SID,MID,Sender,Teacher.Name AS Name,Receiver,Timestamp From Notification,Teacher WHERE Teacher.TID = Notification.Sender AND (Receiver = 0 OR Receiver = @ID);",
                "SELECT SID,MID,Sender,Admin.Name AS Name,Receiver,Timestamp From Notification,Admin WHERE Admin.AID = Notification.Sender AND Receiver = @ID ;" };
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
                    HtmlGenericControl textDIV = new HtmlGenericControl("DIV");
                    textDIV.Style.Add("display", "inline");
                    textDIV.Style.Add("float", "left");
                    textDIV.InnerHtml = reader["Name"].ToString() + res[t];
                    HtmlGenericControl deleteDIV = new HtmlGenericControl("DIV");
                    deleteDIV.Style.Add("display", "inline");
                    deleteDIV.Style.Add("float", "right");
                    deleteDIV.Style.Add("margin-right", "25px");
                    Button del_btn = new Button();
                    del_btn.Text = "Delete";
                    del_btn.CommandArgument = reader["Sender"].ToString()+"$"+reader["MID"].ToString();
                    del_btn.CssClass = "transparentButton";
                    del_btn.Command += delete_action;
                    del_btn.ForeColor = Color.Red;
                    HtmlGenericControl approveDiv = new HtmlGenericControl("DIV");
                    approveDiv.Style.Add("display","inline");
                    approveDiv.Style.Add("float", "right");
                    approveDiv.Style.Add("margin-right", "5px");
                    Button btn = new Button();
                    btn.Text = "Approve";
                    btn.CommandArgument = reader["Sender"].ToString() + "$" + reader["SID"].ToString(); ;
                    btn.CssClass = "transparentButton";
                    btn.Command += approve_action;
                    if (t == 1)
                    {
                        btn.Visible = false;
                        del_btn.Visible = false;
                    }
                    deleteDIV.Controls.Add(del_btn);
                    approveDiv.Controls.Add(btn);
                    createDIV.Controls.Add(textDIV);
                    createDIV.Controls.Add(deleteDIV);
                    createDIV.Controls.Add(approveDiv);
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

    protected void approve_action(Object o,CommandEventArgs e)
    {
        HttpCookie cookie = Request.Cookies["UserDetails"];
        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
        string query = "DELETE FROM Notification WHERE Sender=@sender_id;";
        string insert_query = "INSERT INTO Notification(Sender,Receiver) VALUES(@sender_id,@receiver_id);";
        string approve_query = "UPDATE Student SET TID=@tid WHERE SID=@sid;";
        string[] args = e.CommandArgument.ToString().Split('$');
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sender_id",args[0]);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(insert_query, con);
            cmd.Parameters.AddWithValue("@receiver_id", args[0]);
            cmd.Parameters.AddWithValue("@sender_id",cookie["ID"]);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(approve_query, con);
            cmd.Parameters.AddWithValue("@tid", args[0]);
            cmd.Parameters.AddWithValue("@sid", args[1]);
            cmd.ExecuteNonQuery();
            Response.Redirect("NotificationPage.aspx");
        }
        catch(Exception err)
        {
            errLabel.Text = "Unable to approve your request! " + err;
            errLabel.ForeColor = Color.Red;
        }
        finally
        {
            con.Close();
        }
    }

    protected void delete_action(Object o,CommandEventArgs e)
    {
        HttpCookie cookie = Request.Cookies["UserDetails"];
        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
        string query = "DELETE FROM Notification WHERE Sender=@sender_id AND MID=@msg_id;";
        string[] args = e.CommandArgument.ToString().Split('$');
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue ("@sender_id", args[0]);
            cmd.Parameters.AddWithValue("@msg_id", args[1]);
            cmd.ExecuteNonQuery();
            Response.Redirect("NotificationPage.aspx");
            
        }
        catch(Exception err)
        {
            errLabel.Text = "Unable to delete the request! " + err;
            errLabel.ForeColor = Color.Red;
        }
        finally
        {
            con.Close();
        }
    }
}