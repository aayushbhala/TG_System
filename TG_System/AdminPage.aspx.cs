using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)this.Master.FindControl("mainContent");
        string[] tabsContent = { "Profile", "Show Slots", "Notification", "Report" };
        for(int i = 0; i < 4; i++)
        {
            Button btn = new Button();
            btn.ID = "adm" + i + "btn";
            btn.Text = tabsContent[i];
            btn.Height = Unit.Pixel(30);
            btn.Visible = true;
            btn.Width = Unit.Percentage(25);
            btn.Font.Size = 15;
            contentPlaceHolder.Controls.Add(btn);
            //ButtonChange.Font.Size = FontUnit.Point(7);
            //ButtonChange.ControlStyle.CssClass = "button";
            //ButtonChange.Click += new EventHandler(test);

        }
    }
}