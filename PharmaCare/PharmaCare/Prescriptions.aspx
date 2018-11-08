<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="PharmaCare.Prescriptions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE PRESCRIPTIONS PAGE</h1>
    <asp:TextBox runat="server" ID="txtPatients" Height="124px" Width="256px"></asp:TextBox>
    <asp:Button runat="server" ID="btnPatients" Text="Show Patients" OnClick="btnPatients_Click" />
</asp:Content>
