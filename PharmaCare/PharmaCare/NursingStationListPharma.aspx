<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NursingStationListPharma.aspx.cs"
    Inherits="PharmaCare.NursingStationListPharma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="mainPlaceholder" runat="server">

    
            <h2>Nursing Station List
            </h2>
    Select a Nursing Station:
     
    <asp:DropDownList ID="DropDownListNurse" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="NursingStationId" DataValueField="PrescriptionId"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT [PrescriptionId], [NursingStationId] FROM [IndoorPrescriptions]"></asp:SqlDataSource>
    <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" />
                    <asp:BoundField DataField="WardID" HeaderText="WardID" SortExpression="WardID" />
                    <asp:BoundField DataField="StatusOfDose" HeaderText="StatusOfDose" SortExpression="StatusOfDose" />
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="PrescriptionStatus" SortExpression="PrescriptionStatus" />
                    <asp:BoundField DataField="DrugDose" HeaderText="DrugDose" SortExpression="DrugDose" />
                    <asp:BoundField DataField="PrescriptionId" HeaderText="PrescriptionId" SortExpression="PrescriptionId" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="PrescriptionDate" SortExpression="PrescriptionDate" />
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
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT Patients.Name, Patients.RoomID, Patients.WardID, DrugDetails.StatusOfDose, Prescription.PrescriptionStatus, DrugDetails.DrugDose, IndoorPrescriptions.PrescriptionId, Prescription.PrescriptionDate FROM IndoorPrescriptions INNER JOIN Prescription ON IndoorPrescriptions.PrescriptionId = Prescription.PrescriptionId INNER JOIN Patients ON Prescription.PatientID = Patients.PatientID INNER JOIN PrescriptionDrugs ON Prescription.PrescriptionId = PrescriptionDrugs.PrescriptionId INNER JOIN DrugDetails ON PrescriptionDrugs.LinkId = DrugDetails.LinkId"></asp:SqlDataSource>
    <br />
      <asp:Button ID="Printbtn" runat="server" Text="Print" OnClientClick="javascript:window.print();" />

   </asp:Content>