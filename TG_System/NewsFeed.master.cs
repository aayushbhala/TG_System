using System;
using System.Collections.Generic;
using System.Linq;
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
            default:Response.Redirect("NotificationPage.aspx");
                break;
        }
    }

}
