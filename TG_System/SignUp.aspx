<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUpaspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
        <div class="card">  
            <asp:Label ID="Label1" CssClass="fbtitlebar" Text="&nbsp;&nbsp;Create your account here!" runat="server" Width="100%" Height="50"  />  
            <br />
            <br />
            <br />

            <p> &nbsp;&nbsp;First Name &nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Last Name &nbsp&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server"/>
            </p>
            <br />
            <p>
                &nbsp;&nbsp;Username &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </p>
            <br />
            <p>
                &nbsp;&nbsp;Password &nbsp;&nbsp;&nbsp;&nbsp; 
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Confirm Password&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </p>
            <br />
            <br />
            <br />
            <p style="margin-left: 150px">
                &nbsp;&nbsp;<asp:Button CssClass="transparentButton" ID="Button1" runat="server" Text="Sign In Instead" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button CssClass="transparentButton" ID="Button2" runat="server" Text="SignUp" />
            </p>
        </div>
    </form>
</body>
</html>
