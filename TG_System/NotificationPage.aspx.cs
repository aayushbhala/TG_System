﻿using System;
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
        
        
            HttpCookie cookie = Request.Cookies["UserDetails"];
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source = (localdb)\MSSQLlocalDB;Initial Catalog = Project;Integrated Security = True;Pooling = False;";
            string[] query = {"SELECT Sender,Teacher.Name AS Name,Receiver,Timestamp From Notification,Teacher WHERE Teacher.TID = Notification.Sender AND (Receiver = 0 OR Receiver = @ID);",
                "SELECT Sender,Admin.Name AS Name,Receiver,Timestamp From Notification,Admin WHERE Admin.AID = Notification.Sender AND Receiver = @ID ;" };
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
                    HtmlGenericControl approveDiv = new HtmlGenericControl("DIV");
                    approveDiv.Style.Add("display","inline");
                    approveDiv.Style.Add("float", "right");
                    approveDiv.Style.Add("margin-right", "25px");
                    Button btn = new Button();
                    btn.Text = "Approve";
                    btn.CommandArgument = reader["Sender"].ToString();
                    btn.CssClass = "transparentButton";
                    btn.Command += approve_action;
                    if (t == 1)
                        btn.Visible = false;
                    approveDiv.Controls.Add(btn);
                    createDIV.Controls.Add(textDIV);
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
        con.ConnectionString = @"Data Source = (localdb)\MSSQLlocalDB;Initial Catalog = Project;Integrated Security = True;Pooling = False;";
        string query = "DELETE FROM Notification WHERE Sender=@sender_id;";
        string insert_query = "INSERT INTO Notification(Sender,Receiver) VALUES(@sender_id,@receiver_id);";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@sender_id",e.CommandArgument.ToString());
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand(insert_query, con);
            cmd.Parameters.AddWithValue("@receiver_id", e.CommandArgument.ToString());
            cmd.Parameters.AddWithValue("@sender_id",cookie["ID"]);
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
}