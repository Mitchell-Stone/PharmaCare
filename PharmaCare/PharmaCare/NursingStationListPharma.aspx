


<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NursingStationListPharma.aspx.cs"
    Inherits="PharmaCare.NursingStationListPharma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="mainPlaceholder" runat="server">

    
            <h2>Nursing Station List
            </h2>
    Select a Nursing Station:
      <%-- Drop Down Function     --%>
    <asp:DropDownList ID="DropDownListNurse" runat="server" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="NursingStationId" DataValueField="PrescriptionId" AutoPostBack="True"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT [PrescriptionId], [NursingStationId] FROM [IndoorPrescriptions]"></asp:SqlDataSource>
    <br />

     <%-- Datagrid View  --%>
	 <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource4" ForeColor="#333333" GridLines="None" CssClass="table table-hover table-bordered">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="PrescriptionId" HeaderText="PrescriptionId" SortExpression="PrescriptionId" />
                    <asp:BoundField DataField="PatientID" HeaderText="PatientID" SortExpression="PatientID" />
                    <asp:BoundField DataField="RoomNumber" HeaderText="RoomNumber" SortExpression="RoomNumber" />
                    <asp:BoundField DataField="WingNumber" HeaderText="WingNumber" SortExpression="WingNumber" />
                    <asp:BoundField DataField="FloorNumber" HeaderText="FloorNumber" SortExpression="FloorNumber" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="PrescriptionDate" SortExpression="PrescriptionDate" />
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="PrescriptionStatus" SortExpression="PrescriptionStatus" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
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
     <%-- Sql Data Source  --%>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT distinct(IndoorPrescriptions.PrescriptionId), Prescription.PatientID, IndoorPrescriptions.RoomNumber, IndoorPrescriptions.WingNumber, IndoorPrescriptions.FloorNumber, Prescription.PrescriptionDate, Prescription.PrescriptionStatus, Patients.Name FROM Drugs INNER JOIN DrugDetails INNER JOIN Prescription INNER JOIN IndoorPrescriptions ON Prescription.PrescriptionId = IndoorPrescriptions.PrescriptionId INNER JOIN Patients ON Prescription.PatientID = Patients.PatientID INNER JOIN PrescriptionDrugs ON Prescription.PrescriptionId = PrescriptionDrugs.PrescriptionId ON DrugDetails.LinkId = PrescriptionDrugs.LinkId ON Drugs.DrugId = PrescriptionDrugs.DrugId WHERE (Prescription.PrescriptionId = @PrescriptionId)">
    <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownListNurse" Name="PrescriptionId" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>



            <br />
      <asp:Button ID="Printbtn" runat="server" Text="Print" OnClientClick="javascript:window.print();" />

   </asp:Content>