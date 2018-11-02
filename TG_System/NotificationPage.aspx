<%@ Page Title="" Language="C#" MasterPageFile="~/NewsFeed.master" AutoEventWireup="true" CodeFile="NotificationPage.aspx.cs" Inherits="_Default" Theme="Light" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tabsContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="restContent" Runat="Server">
    <asp:Label ID="errLabel" runat="server" Text=""></asp:Label>
    <div id="NotificationContainer" runat="server">
    </div>
    
</asp:Content>

