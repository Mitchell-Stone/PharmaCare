<%--/* 
 *          Page Create By Hsuan-Yi Lin(a.k.a Alex Pasalic) 
 *
 *          Student ID= 452400286
 *
 */--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPrescriptions.aspx.cs" Inherits="PharmaCare.SearchPrescriptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <h1>Outdoor Patient Prescription Page</h1>
    <div class="row">
        <div class="col-md-4">
            <label class="float-left">Search Patient : </label>
            <asp:TextBox ID="txtSearchPatient" runat="server" CssClass="float-center"></asp:TextBox>
            <asp:Button ID="btnFindPatient" runat="server" Text="Find Patient" CssClass="right"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">
            <label class="float-left">Search Prescription by ID : </label>
            <asp:TextBox ID="txtFindPrescription" runat="server" CssClass="float-none"></asp:TextBox>
            <asp:Button ID="btnFindPrescription" runat="server" Text="Find Prescription" CssClass="float-right" />            
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <label> First Name : </label>
            <asp:TextBox ID="txtPFname" runat="server" ></asp:TextBox>
            <label> Last Name : </label>
            <asp:TextBox ID="txtPLname" runat="server" ></asp:TextBox>
        </div>   
    </div>
        <div class="col-xl-12">            
            <asp:GridView ID="dgvPrescriptions" runat="server" AutoGenerateColumns="False" 
                AllowSorting="True"
                CssClass="table table-bordered table-striped table-condensed"  CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1">
            <AlternatingRowStyle BackColor="White" />              
                <Columns>
                    <asp:BoundField DataField="OPDId" HeaderText="OPDId" ReadOnly="True" SortExpression="OPDId" InsertVisible="False" />
                    <asp:BoundField DataField="DateDispatched" HeaderText="DateDispatched" SortExpression="DateDispatched" />
                    <asp:BoundField DataField="IndoorEmergency" HeaderText="IndoorEmergency" SortExpression="IndoorEmergency" />
                    <asp:BoundField DataField="ToFill" HeaderText="ToFill" SortExpression="ToFill" />
                    <asp:BoundField DataField="DrugId" HeaderText="DrugId" SortExpression="DrugId" />
                    <asp:BoundField DataField="DrugName" HeaderText="DrugName" SortExpression="DrugName" />
                    <asp:BoundField DataField="DrugForm" HeaderText="DrugForm" SortExpression="DrugForm"  />
                    <asp:BoundField DataField="PatientID" HeaderText="PatientID" ReadOnly="true" InsertVisible="False" SortExpression="PatientID"  />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
                    <asp:BoundField DataField="PrescriptionId" HeaderText="PrescriptionId" ReadOnly="true" InsertVisible="False" SortExpression="PrescriptionId"  />
                    <asp:BoundField DataField="DoctorID" HeaderText="DoctorID" SortExpression="DoctorID" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="PrescriptionDate" SortExpression="PrescriptionDate" />
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="PrescriptionStatus" SortExpression="PrescriptionStatus" />
                    <asp:BoundField DataField="DrugDose" HeaderText="DrugDose" SortExpression="DrugDose" />
                </Columns>                             
            </asp:GridView>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT OPDPrescriptions.OPDId, OPDPrescriptions.DateDispatched, OPDPrescriptions.IndoorEmergency, OPDPrescriptions.ToFill, Drugs.DrugId, Drugs.DrugName, Drugs.DrugForm, Patients.PatientID, Patients.Name, Prescription.PrescriptionId, Prescription.DoctorID, Prescription.PrescriptionDate, Prescription.PrescriptionStatus, DrugDetails.DrugDose FROM OPDPrescriptions LEFT OUTER JOIN Prescription ON OPDPrescriptions.PrescriptionId = Prescription.PrescriptionId LEFT OUTER JOIN Patients ON Prescription.PatientID = Patients.PatientID LEFT OUTER JOIN PrescriptionDrugs ON Prescription.PrescriptionId = PrescriptionDrugs.PrescriptionId LEFT OUTER JOIN Drugs ON PrescriptionDrugs.DrugId = Drugs.DrugId LEFT OUTER JOIN DrugDetails ON DrugDetails.LinkId = PrescriptionDrugs.LinkId WHERE (Prescription.PrescriptionStatus = @status) ORDER BY Prescription.PrescriptionDate">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Active" Name="status" Size="20" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            

        </div>
</asp:Content>
