<%@ Page Title="" Language="C#" MasterPageFile="~/NewsFeed.master" AutoEventWireup="true" CodeFile="ShowSlotsPage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tabsContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="restContent" Runat="Server">
    <div style="margin:10px;">
    <asp:GridView ID="ShowSlotsGV" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField AccessibleHeaderText="Sl No." HeaderText="Sl No." ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField AccessibleHeaderText="Department" DataField="Department" HeaderText="Department" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField AccessibleHeaderText="Section" DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center"/>
            <asp:BoundField AccessibleHeaderText="Teacher Assigned" DataField="Name" HeaderText="Teacher Assigned" ItemStyle-HorizontalAlign="Center"/>
            <asp:ButtonField HeaderText="Action" Text="Assign" ItemStyle-HorizontalAlign="Center"/>
        </Columns>
    </asp:GridView>
    <asp:Label ID="errLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>

