using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["UserDetails"];
        string type = (((string)cookie["UserType"]).Equals("Admin") ? "AD" : "TG");
        Button btn = (Button)this.Master.FindControl("tabsContent").FindControl(type + "0" + "btn");
        if (btn != null)
            btn.ForeColor = Color.Black;
        name.Text = cookie["Name"].ToString();
        email.Text = cookie["Email"].ToString();
        phNumber.Text = cookie["Number"].ToString();
        if (type.Equals("TG"))
        {
            dept.Visible = true;
            dept_img.Visible = true;
            string dep = cookie["Department"].ToString();
            switch (dep)
            {
                case "CSE":
                    dept.Text = "Computer Science and Engineering";
                    break;
                case "IT":
                    dept.Text = "Information Technology";
                    break;
                case "ECE":
                    dept.Text = "Electronics and Communication Engineering";
                    break;
                case "EEE":
                    dept.Text = "Electrical and Electronics Engineering";
                    break;
                case "ME":
                    dept.Text = "Mechanical Engineering";
                    break;
            }
        }
        else
        {
            dept.Visible = false;
            dept_img.Visible = false;
        }
    }

    protected void Page_PreInit(object sender,EventArgs e)
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