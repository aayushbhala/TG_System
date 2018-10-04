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
        Label1.Text += (string)cookie["UserName"];
        int len;
        string type = "";
        if (userType.Equals("Admin"))
        {
            len = tabsContent.Length;
            type += "ADM";
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
            contentPlaceHolder.Controls.Add(btn);

        }
    }
}
