<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateComplaints.aspx.cs" MasterPageFile="~/Site.Master" Inherits="Complaints_system.CreateComplaints" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="Lblmsg" runat="server" Text=""></asp:Label>
    <asp:Label ID="Lblexception" runat="server" Text=""></asp:Label>
<table>
    <tr>
        <td>
            Complaint Description
        </td>
        <td>
            <asp:TextBox ID="TxtDescription" runat="server" TextMode="MultiLine" Rows="5" MaxLength="3000" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field *" ControlToValidate="TxtDescription"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Complaint Status
        </td>
        <td>
            <asp:Label ID="LblStatus" runat="server" Text="Open"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Enter Clearance Date
        </td>
        <td>
            <asp:TextBox ID="TxtClearancedate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Enter Complaint Type
        </td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem>Hardware</asp:ListItem>
                <asp:ListItem>OS</asp:ListItem>
                <asp:ListItem>I/O</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field *" ControlToValidate="RadioButtonList1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
            Enter Device Name
        </td>
        <td>
            <asp:TextBox ID="TxtDevice" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Field *" ControlToValidate="TxtDevice"></asp:RequiredFieldValidator>
        </td>
    <tr>
        <td>
            <asp:Button ID="BtnComplaint" runat="server" Text="Submit Complaint" 
                onclick="BtnComplaint_Click" />
        </td>
    </tr>
    </tr>
</table>



</asp:Content>