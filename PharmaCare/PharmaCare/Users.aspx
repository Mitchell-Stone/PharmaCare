<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="PharmaCare.Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="mainPlaceholder" runat="server">


<h1>PHMS</h1>


 <asp:Label ID="welcomeLbl" runat="server" Text="Welcome "></asp:Label>
<br /> 
       
 <asp:Button ID="LogOut_btn" class="btn" runat="server" OnClick="LogOut_btn_Click" Text="Logout" />


</asp:Content>