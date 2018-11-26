<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NursingStationListPharma.aspx.cs"
    Inherits="PharmaCare.NursingStationListPharma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="mainPlaceholder" runat="server">

    
            <h2>Nursing Station List
            </h2>
    Select a Nursing Station:
     
    <asp:DropDownList ID="DropDownListNurse" runat="server" CssClass="form-control"></asp:DropDownList>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="WardID" HeaderText="WardID" SortExpression="WardID" />
            <asp:BoundField DataField="PrescriptionDate" HeaderText="PrescriptionDate" SortExpression="PrescriptionDate" />
            <asp:BoundField DataField="PrescriptionStatus" HeaderText="PrescriptionStatus" SortExpression="PrescriptionStatus" />
            <asp:BoundField DataField="DrugDose" HeaderText="DrugDose" SortExpression="DrugDose" />
            <asp:BoundField DataField="StatusOfDose" HeaderText="StatusOfDose" SortExpression="StatusOfDose" />
            <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView> 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT Patients.Name, Patients.Address, Patients.WardID, Prescription.PrescriptionDate, Prescription.PrescriptionStatus, Prescription.DrugDose, Prescription.StatusOfDose, Patients.RoomID FROM Patients INNER JOIN Prescription ON Patients.PatientID = Prescription.PatientID"></asp:SqlDataSource>
    <br />
      <asp:Button ID="Printbtn" runat="server" Text="Print" OnClientClick="javascript:window.print();" />

   </asp:Content>