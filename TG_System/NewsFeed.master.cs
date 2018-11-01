using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class NewsFeed : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["UserDetails"];
        ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)this.FindControl("tabsContent");
        string[] tabsContent = { "Profile", "Show Slots", "Notification", "Report" };
        string userType = (string)cookie["UserType"];
        if(!IsPostBack)
            Label1.Text += (string)cookie["UserName"];
        int len;
        string type = "";
        if (userType.Equals("Admin"))
        {
            len = tabsContent.Length;
            type += "AD";
        }
        else
        {
            len = tabsContent.Length - 1;
            type += "TG";
        }
        for (int i = 0; i < len; i++)
        {
            Button btn = new Button();
            btn.ID = type + i + "btn";
            btn.Text = tabsContent[i];
            btn.Height = Unit.Pixel(30);
            btn.Visible = true;
            btn.ForeColor = ColorTranslator.FromHtml("#818181");
            btn.ControlStyle.CssClass = "Initial";
            btn.Width = Unit.Percentage(len%2==0?25:i==0?34:33);
            btn.Font.Size = 12;
            btn.Click += tab_click;
            contentPlaceHolder.Controls.Add(btn);

        }
    }
    protected void tab_click(Object o,EventArgs args)
    {
        HttpCookie cookie = Request.Cookies["UserDetails"];
        string type = (string)cookie["UserType"];
        Button btn = (Button)o;
        btn.ForeColor = Color.Red;
        string redirect = btn.ID.ToString().Substring(2, 1);
        switch (redirect) {
            case "0":Response.Redirect("ProfilePage.aspx");
                break;
            case "1":if (type.Equals("Admin"))
                    Response.Redirect("ShowSlotsPage.aspx");
                else
                    Response.Redirect("ShowSlotsPageTeacher.aspx");
                break;
            case "2": Response.Redirect("NotificationPage.aspx");
                break;
            case "3": Response.Redirect("ReportPage.aspx");
                break;
        }
    }


    protected void sideNav_about_Click(object sender, EventArgs e)
    {

    }

    protected void sideNav_services_Click(object sender, EventArgs e)
    {

    }

    protected void sideNav_clients_Click(object sender, EventArgs e)
    {

    }

    protected void sideNav_contact_Click(object sender, EventArgs e)
    {

    }

    protected void sideNav_logout_Click(object sender, EventArgs e)
    {
        // Deleting user info cookie
        HttpCookie cookie = new HttpCookie("UserDetails");
        cookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookie);

        Response.Redirect("SignIn.aspx");
    }

    protected void ThemeRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["Theme"] = ThemeRadioButtonList.SelectedItem.ToString();
        System.Diagnostics.Debug.WriteLine(Request.FilePath.ToString());
        Response.Redirect(Request.FilePath);
    }
}
