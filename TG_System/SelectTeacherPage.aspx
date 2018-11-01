<%@ Page Title="" Language="C#" MasterPageFile="~/NewsFeed.master" AutoEventWireup="true" CodeFile="SelectTeacherPage.aspx.cs" Inherits="_Default" Theme="Light" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tabsContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="restContent" Runat="Server">
    <asp:GridView ID="teachersList" runat="server" AutoGenerateColumns="false" Width="100%">
         <RowStyle HorizontalAlign="Center" />
        <Columns>
             <asp:TemplateField AccessibleHeaderText="Sl No." HeaderText="Sl No." ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Department" DataField="Department" />
             <asp:TemplateField HeaderText="Action" ShowHeader="False">
                 <ItemTemplate>
                     <asp:LinkButton ID="assignTGBtn" runat="server" CommandName="assign" Text="Assign" OnCommand="assignTGBtn_Command" CommandArgument='<%# Eval("TID") %>'/>
                 </ItemTemplate>
                 <ItemStyle HorizontalAlign="Center" />
             </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="errLabel" runat="server" ForeColor="Red" />
 
</asp:Content>

