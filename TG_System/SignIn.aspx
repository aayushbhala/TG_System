<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
        <div class="card" style="width:300px;height:350px;">
             <asp:Label ID="Label2" CssClass="fbtitlebar" Text="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Login" runat="server" Width="100%" Height="50"  />
            <div class="box">
                <p>
                    &nbsp;</p>
                <p>
                    &nbsp;</p>
                <p>
                    Username</p>
                <asp:TextBox ID="loginUname" runat="server" Width="85%" />
                <p>
                    Password
                </p>
                <asp:TextBox ID="loginPwd" runat="server" Width="85%" TextMode="Password"/>
                <br />
                <br />
                <br />
                <br />
                <p style="font-size:12px">
                    Don't have an account then click below!
                </p>
                <asp:Button ID="signUp" Text="SignUp" CssClass="transparentButton" runat="server" OnClick="signUp_Click" />
            </div>
        </div>
    </form>
</body>
</html>
