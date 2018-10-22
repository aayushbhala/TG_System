<%@ Page Title="" Language="C#" MasterPageFile="~/NewsFeed.master" AutoEventWireup="true" CodeFile="ReportPage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tabsContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="restContent" Runat="Server">
    Select any of the filters below to customize the report.<br />
    
    Department: 
    <asp:CheckBoxList ID="deptList" runat="server" >
        <asp:ListItem Text="CSE" />
        <asp:ListItem Text="ECE" />
        <asp:ListItem Text="IT" />
        <asp:ListItem Text="EEE" />
        <asp:ListItem Text="ME" />
    </asp:CheckBoxList> 
    <br />
    <br />

    Section: 
    <asp:CheckBoxList ID="secList" runat="server" >
        <asp:ListItem Text="A" />
        <asp:ListItem Text="B" />
        <asp:ListItem Text="C" />
        <asp:ListItem Text="D" />
    </asp:CheckBoxList>
    <br />
    <br />

    <asp:Button ID="genReportBtn" Text="Generate Report" runat="server" OnClick="genReportBtn_Click"/> 
    <br />
    <br />

    <asp:Panel ID="reportPanel" runat="server" Visible="false">
        <h2>Information on Assigned Slots:</h2><br />
        <asp:GridView ID="displayRepAssigned" runat="server"  Width="100%"/>
        <br />
        <br />

        <h3>Slot Info</h3><br />
        <asp:GridView ID="displayRepAssignedSlots" runat="server" Width="100%"/>
        <br />
        <br />

        <h2>Information on Vacant Slots:</h2><br />
        <asp:GridView ID="displayRepVacant" runat="server" Width="100%"/>
        <br />
        <br />

        <h3>Slot Info</h3><br />
        <asp:GridView ID="displayRepVacantSlots" runat="server" Width="100%"/>
        <br />
    <br />
    </asp:Panel>
</asp:Content>

