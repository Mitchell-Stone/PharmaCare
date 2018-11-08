<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPrescriptions.aspx.cs" Inherits="PharmaCare.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <h1>Outdoor Patient Prescription Page</h1>
    <div class="row">
        <div class="col-sm-2">
            <label>Search Patient : </label>
            <asp:TextBox ID="txtSearchPatient" runat="server"></asp:TextBox>
            <asp:Button ID="btnFindPatient" runat="server" Text="Find Patient" />
            <label>Search Prescription by ID : </label>
            <asp:TextBox ID="txtFindPrescription" runat="server"></asp:TextBox>
            <asp:Button ID="btnFindPrescription" runat="server" Text="Find Prescription" />            
        </div>
        <div class="col-sm-2">
            <label> First Name : </label>
            <asp:TextBox ID="txtPFname" runat="server"></asp:TextBox>
            <label> Last Name : </label>
            <asp:TextBox ID="txtPLname" runat="server"></asp:TextBox>
        </div>          
        <div class="col-sm-2">
            <asp:SqlDataSource runat="server" ID="Prescriptions"
                ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>'
                SelectCommand="SELECT [PrescriptionId], [DrugId], [PatientName], 
                        [PrescriptionDate], [PrescribingDoctor], [AdditionalInformation],[PrescriptionStatus],[DrugDose],[FirstTime],[LastTime],[TimesPerDay],[StatusOfDose] FROM [Prescription] 
                        ORDER BY [PatientName]">
    </asp:SqlDataSource>
            <asp:GridView ID="dgvPrescriptions" runat="server" AutoGenerateColumns="false" DataSourceID="Prescriptions"
                CssClass="table table-bordered table-striped table-condensed">
                <Columns>
                    <asp:BoundField DataField="PrescriptionID" HeaderText="Presciption ID"
                        ReadOnly="True" SortExpression="PrescriptionID" >
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name"
                        ReadOnly="True" SortExpression="PatientName" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DrugID" HeaderText="Drug ID"
                        ReadOnly="True" SortExpression="DrugID" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DrugDose" HeaderText="Dose"
                        ReadOnly="true" SortExpression="DrugDose" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="AdditionalInformation" HeaderText="Information"
                        ReadOnly="true" SortExpression="AdditionalInformation" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StatusOfDose" HeaderText="Dose Status"
                        ReadOnly="true" SortExpression="StatusOfDose" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day"
                        ReadOnly="true" SortExpression="TimesPerDay" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FirstTime" HeaderText="First Time"
                        ReadOnly="true" SortExpression="FirstTime" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="LastTime" HeaderText="Last Time"
                        ReadOnly="true" SortExpression="LastTime" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="Prescription Status"
                        ReadOnly="true" SortExpression="PrescriptionStatus" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="Prescription Date"
                        ReadOnly="true" SortExpression="PrescriptionDate" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PrescribingDoctor" HeaderText="Prescribing Doctor"
                        ReadOnly="true" SortExpression="PrescribingDoctor" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                </Columns>
                <PagerSettings Mode="NumericFirstLast" />
                
            </asp:GridView>
        </div>
    </div>
</asp:Content>
