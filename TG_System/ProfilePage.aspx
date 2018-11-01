<%@ Page Title="" Language="C#" MasterPageFile="~/NewsFeed.master" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="_Default" Theme="Light" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tabsContent" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="restContent" runat="server">
    <div class="card" style="width:700px;height:400px;top:55%;left:55%;">
        <div class="box">
        <img src="default-gmail-profile-picture.jpg" style="border-style: groove; border-color: inherit; border-width: medium; height: 192px; width: 163px; margin-bottom: 10px;margin-left:10px;margin-top:10px;margin-right:35px; "/>
        <div style="display:inline-block;vertical-align:top;">
            <div style="margin-top:15px;text-align:left;">
                <asp:Label ID="name" runat="server" Text="" ForeColor="Black" Font-Size="25px"/>
            </div>
            <div style="margin-top:5px;margin-bottom:20px;text-align:left;">
                <asp:Label ID="Label1" runat="server" Text="Manipal Institute Of Technology,Manipal" Font-Size="15px"></asp:Label>
                <div style="display:inline-block;vertical-align:top;">
                    <img src="map_marker_image.png" style="height: 16px; width: 15px;" />
                </div>
            </div>
            <div style="text-align:left;">
                <img src="email_image.png" style="height: 23px; width: 24px;" />
                <div style="display:inline-block;vertical-align:top;">
                    <asp:Label ID="email" runat="server" Text="" />
                </div>
            </div>
            <div style="margin-top:10px;text-align:left;">
                <img src="phone_image.png" style="height: 23px; width: 24px;" />
                <div style="display:inline-block;vertical-align:top;">
                    <asp:Label ID="phNumber" runat="server" Text="" />
                </div>
            </div>
            <div style="margin-top:10px;text-align:left;">
                <asp:Image ID="dept_img" runat="server" ImageUrl="~/globe_image.png" Height="23px" Width="24px"/>
                <div style="display:inline-block;vertical-align:top;">
                    <asp:Label ID="dept" runat="server" Text="" />
                </div>
            </div>
        </div>
        </div>
    </div>
</asp:Content>

