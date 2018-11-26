<%--/* 
 *          Page Create By Hsuan-Yi Lin(a.k.a Alex Pasalic) 
 *
 *          Student ID= 452400286
 *          Known error= search engine not fully built
 */--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPrescriptions.aspx.cs" Inherits="PharmaCare.SearchPrescriptions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <h1>Outdoor Patient Prescription Page</h1>
    <div class="row">
        <div class="col-md-12">
            <label class="float-left">Search Patient :     </label>
            <asp:TextBox ID="txtSearchPatient" runat="server" CssClass="float-center "></asp:TextBox>
            <asp:Button ID="btnFindPatient" runat="server" Text="Find Patient" CssClass="right"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <label class="float-left">Search Prescription by ID :     </label>
            <asp:TextBox ID="txtFindPrescription" runat="server" CssClass="float-none"></asp:TextBox>
            <asp:Button ID="btnFindPrescription" runat="server" Text="Find Prescription" CssClass="right" />            
        </div>
    </div>
        <div class="container">            
            <asp:GridView ID="dgvPrescriptions" runat="server" AutoGenerateColumns="False" 
                AllowSorting="True"
                CssClass="table table-bordered table-striped table-condensed"  CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="SqlDataSource1">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />              
                <Columns>
                    <asp:BoundField DataField="OPDId" HeaderText="OPDId" ReadOnly="True" SortExpression="OPDId" InsertVisible="False" />
                    <asp:BoundField DataField="PrescriptionId" HeaderText="PrescriptionId" ReadOnly="true" InsertVisible="False" SortExpression="PrescriptionId"  />
                    <asp:BoundField DataField="PatientID" HeaderText="PatientID" ReadOnly="true" InsertVisible="False" SortExpression="PatientID"  />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"  />
                    <asp:BoundField DataField="DateDispatched" HeaderText="DateDispatched" SortExpression="DateDispatched" />
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="PrescriptionStatus" SortExpression="PrescriptionStatus" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="PrescriptionDate" SortExpression="PrescriptionDate" />
                    <asp:BoundField DataField="DoctorID" HeaderText="DoctorID" SortExpression="DoctorID" />
                    <asp:BoundField DataField="IndoorEmergency" HeaderText="IndoorEmergency" SortExpression="IndoorEmergency" />
                    
                </Columns>                             
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT OPDPrescriptions.OPDId, OPDPrescriptions.DateDispatched, OPDPrescriptions.IndoorEmergency, OPDPrescriptions.ToFill, Drugs.DrugId, Drugs.DrugName, Drugs.DrugForm, Patients.PatientID, Patients.Name, Prescription.PrescriptionId, Prescription.DoctorID, Prescription.PrescriptionDate, Prescription.PrescriptionStatus, DrugDetails.DrugDose FROM OPDPrescriptions LEFT OUTER JOIN Prescription ON OPDPrescriptions.PrescriptionId = Prescription.PrescriptionId LEFT OUTER JOIN Patients ON Prescription.PatientID = Patients.PatientID LEFT OUTER JOIN PrescriptionDrugs ON Prescription.PrescriptionId = PrescriptionDrugs.PrescriptionId LEFT OUTER JOIN Drugs ON PrescriptionDrugs.DrugId = Drugs.DrugId LEFT OUTER JOIN DrugDetails ON DrugDetails.LinkId = PrescriptionDrugs.LinkId WHERE (Prescription.PrescriptionStatus = @status) ORDER BY Prescription.PrescriptionDate">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Active" Name="status" Size="20" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:DetailsView ID="DetailsPrescription" runat="server" AllowPaging="True"  
                AutoGenerateRows="False" CellPadding="4" DataKeyNames="id"   DataSourceID="SQLDrugDetails" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <EditRowStyle BackColor="#999999" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="PrescriptionId" HeaderText="PrescriptionId" ReadOnly="true" />
                    <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="true"/>
                    <asp:BoundField DataField="DrugId" HeaderText="Drug Id" ReadOnly="true"/>
                    <asp:BoundField DataField="DrugName" HeaderText="Drug Name" ReadOnly="true"/>
                    <asp:BoundField DataField="DrugForm" HeaderText="Drug Form" ReadOnly="true"/>
                    <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose" ReadOnly="true"/>
                    <asp:BoundField DataField="ToFill" HeaderText="To Fill" ReadOnly="true"/>
                </Fields>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />


            </asp:DetailsView>
            
            <asp:SqlDataSource ID="SQLDrugDetails" runat="server" ConnectionString="<%$ ConnectionStrings:PharmaCareDB %>" SelectCommand="SELECT OPDPrescriptions.ToFill, Drugs.DrugId, Drugs.DrugName, Drugs.DrugForm, Patients.Name, Prescription.PrescriptionId, DrugDetails.DrugDose FROM OPDPrescriptions LEFT OUTER JOIN Prescription ON OPDPrescriptions.PrescriptionId = Prescription.PrescriptionId LEFT OUTER JOIN Patients ON Prescription.PatientID = Patients.PatientID LEFT OUTER JOIN PrescriptionDrugs ON Prescription.PrescriptionId = PrescriptionDrugs.PrescriptionId LEFT OUTER JOIN Drugs ON PrescriptionDrugs.DrugId = Drugs.DrugId LEFT OUTER JOIN DrugDetails ON DrugDetails.LinkId = PrescriptionDrugs.LinkId WHERE (Prescription.PrescriptionId = @status) ORDER BY Prescription.PrescriptionId"></asp:SqlDataSource>
            <SelectParameters>
                <asp:ControlParameter ID="DetailSelector" runat="server" ControlId="dgvPrescriptions" Name="PresctiptionId" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>

        </div>
</asp:Content>
