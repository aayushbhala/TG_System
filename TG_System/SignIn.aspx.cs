﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Web.Configuration;

public partial class SignIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void signUp_Click(object sender, EventArgs e)
    {
        clearComponents();
        Response.Redirect("SignUp.aspx");
    }
    protected void clearComponents()
    {
        loginUname.Text = "";
        loginUname.Text = "";
    }

    protected void signInBtn_Click(object sender, EventArgs e)
    {
        Boolean isAdmin = loginUname.Text.ToString().Contains("admin_");
        HttpCookie cookie = new HttpCookie("UserDetails");
        string table="";
        string ID = "";
        if (!isAdmin)
        {
            cookie["UserType"] = "Teacher";
            table += "Teacher";
            ID += "TID";
        }
        else
        {
            cookie["UserType"] = "Admin";
            table += "Admin";
            ID += "AID";
        }
        string query = "SELECT * FROM " + table + " WHERE Username = @username;";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = WebConfigurationManager.ConnectionStrings["mainDB"].ConnectionString;
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", loginUname.Text.ToString());
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            reader.Read();
            if (reader["Password"].ToString().Equals(loginPwd.Text.ToString()))
            {
                cookie["UserName"] = loginUname.Text.ToString();
                cookie["Name"] = reader["Name"].ToString();
                cookie["Email"] = reader["Email"].ToString();
                cookie["Number"] = reader["Phone"].ToString();
                cookie["ID"] = reader[ID].ToString();
                if(table.Equals("Teacher"))
                    cookie["Department"] = reader["Department"].ToString();
                Response.Cookies.Add(cookie);
                Response.Redirect("ProfilePage.aspx");
            }
            else
            {
                errLabelSignIn.Text = "Username or Password Incorrect";
                errLabelSignIn.ForeColor = Color.Red;
            }
        }
        catch (Exception err)
        {
            errLabelSignIn.Text = "User doesn't exist "+err;
            errLabelSignIn.ForeColor = Color.Red;
        }
        finally
        {
            con.Close();
            loginPwd.Text = "";
            loginUname.Text = "";
        }
    }
}