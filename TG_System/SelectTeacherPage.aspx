<%@ Page Title="" Language="C#" MasterPageFile="~/NewsFeed.master" AutoEventWireup="true" CodeFile="SelectTeacherPage.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tabsContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="restContent" Runat="Server">
    <asp:GridView ID="teachersList" runat="server">
        <Columns>
             <asp:TemplateField AccessibleHeaderText="Sl No." HeaderText="Sl No." ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Department" DataField="Department" />
            <asp:ButtonField HeaderText="Action" CommandName="assign" Text="Assign" ItemStyle-HorizontalAlign="Center"/>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="errLabel" runat="server" ForeColor="Red" />
 
</asp:Content>

