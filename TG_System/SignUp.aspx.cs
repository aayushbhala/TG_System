using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignUpaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Select_dept(object source, ServerValidateEventArgs args)
    {
        if(Page.IsValid)
            args.IsValid = false;
        return;

        if (dept.SelectedItem.ToString().Equals("Select"))
        {
            args.IsValid = false;
            return;
        }
        args.IsValid = true;
        
    }
}