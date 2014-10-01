<%@ Page Language="C#" Title="EmployeeHomepage" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeComplaints.aspx.cs" Inherits= "Complaints_system.EmployeeComplaints" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HyperLink ID="HyperLink1" runat="server" Text="Create Complaints" NavigateUrl="~/CreateComplaints.aspx"></asp:HyperLink>
    <asp:GridView ID="gvComplaints" runat="server" 
    EmptyDataText="No data available" BackColor="White" BorderColor="#DEDFDE" 
        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
        GridLines="Vertical" ShowHeaderWhenEmpty="True">
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
</asp:Content>