<%@ Page Title="" Language="C#" MasterPageFile="~/NewsFeed.master" AutoEventWireup="true" CodeFile="ShowSlotsPageTeacher.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tabsContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="restContent" Runat="Server">
    <div style="margin:10px;">
        
    <asp:Panel ID="slotsID" runat="server" >
        <h3>Empty Slots</h3>

    <asp:GridView ID="ShowSlotsGV" runat="server" AutoGenerateColumns="False" Width="100%" OnRowCommand="ShowSlotsGV_RowCommand">
        <Columns>
            <asp:TemplateField AccessibleHeaderText="Sl No." HeaderText="Sl No." ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField AccessibleHeaderText="Department" DataField="Department" HeaderText="Department" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField AccessibleHeaderText="Section" DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="ApplyBtn" runat="server" Text="Apply" CommandArgument='<%# Eval("SID") %>' CommandName="apply_btn" BackColor="Transparent" BorderStyle="None" ForeColor="Blue" Font-Size="16px" Font-Underline="true" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="errLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
        
         <br />
        <br />
        <h3>Alloted Slots</h3>
        <asp:GridView ID="FilledGV" runat="server" AutoGenerateColumns="False" Width="100%">
        <Columns>
            <asp:TemplateField AccessibleHeaderText="Sl No." HeaderText="Sl No." ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                <%# Container.DataItemIndex + 1 %>
            </ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField AccessibleHeaderText="Department" DataField="Department" HeaderText="Department" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField AccessibleHeaderText="Section" DataField="Section" HeaderText="Section" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField AccessibleHeaderText="Teacher Assigned" DataField="Name" HeaderText="Teacher Assigned" ItemStyle-HorizontalAlign="Center">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
        <br />
        <asp:Label ID="errLabel1" runat="server" ForeColor="Red" />
        </asp:Panel>
        </div>
</asp:Content>

