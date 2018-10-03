using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class SignUpaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void signUpButton_Click(object sender, EventArgs e)
    { 
        string query = "INSERT INTO Teacher(Name,Email,Username,Phone,Password,Department) VALUES('" + fname.Text.ToString() + " " + lname.Text.ToString() +"','" 
                + email.Text.ToString() + "','" + uname.Text.ToString() + "'," + phNum.Text.ToString() + ",'" + pwd.Text.ToString() +"','"+dept.SelectedItem.ToString()+ "');";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=Project;Integrated Security=True;Pooling=False";
        try
        {
            con.Open();    
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }catch(Exception err)
        {
            string text = ("An error has occured " + query+"\n"+err);
           // errLabel.Text = text.Substring(0, text.IndexOf(".")+1);
            errLabel.ForeColor = Color.Red;
            
        }
        finally
        {
            con.Close();
            clearComponents();
        }
    }
    protected void clearComponents()
    {
        fname.Text = "";
        lname.Text = "";
        uname.Text = "";
        email.Text = "";
        phNum.Text = "";
        dept.ClearSelection();

    }
}