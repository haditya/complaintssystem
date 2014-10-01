<%@ Page Title ="Service Desk"  Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" MasterPageFile="~/Site.Master"  Inherits="Complaints_system.Login" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <asp:Label ID="Lbluname" runat="server" Text="Enter your username"></asp:Label>
    <asp:TextBox ID="Txtuname"  runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="Lblpwd" runat="server" Text="Enter your password"></asp:Label>
    <asp:TextBox ID="Txtpwd" runat="server" ></asp:TextBox>
    <br />
    <asp:Button ID="Btnlogin" runat="server" Text="Login" onclick="Btnlogin_Click" 
        style="height: 26px" />
    <asp:Label ID="exceplbl" runat="server" Text=""></asp:Label>
    <asp:Label ID="Lbltxt" runat="server" Text=""></asp:Label>

</asp:Content>