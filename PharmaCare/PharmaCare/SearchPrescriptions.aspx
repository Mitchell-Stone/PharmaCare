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
            <asp:SqlDataSource runat="server" ID="Prescriptions"
                ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>'
                SelectCommand="SELECT * FROM [Prescription] ORDER BY [PatientID]">
    </asp:SqlDataSource>
            <asp:GridView ID="dgvPrescriptions" runat="server" AutoGenerateColumns="false" 
                DataSourceID="Prescriptions" AllowSorting="true" Allowpaging="true"
                UseAccessibleHeader="true"
                CssClass="table table-bordered table-striped table-condensed"
                OnPreRender="DgvPrescriptions_PreRender">
                <Columns>
                    <asp:BoundField DataField="PrescriptionID" HeaderText="Presciption ID"
                        ReadOnly="True" SortExpression="PrescriptionID" >
                        <ItemStyle CssClass="col-xs-1" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PatientID" HeaderText="Patient ID"
                        ReadOnly="True" SortExpression="PatientID" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Patient Name"
                        ReadOnly="True" SortExpression="Name" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DoctorID" HeaderText="Doctor ID"
                        ReadOnly="true" SortExpression="DoctorID" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DrugID" HeaderText="Drug ID"
                        ReadOnly="True" SortExpression="DrugID" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DrugName" HeaderText="Drug Name"
                        ReadOnly="True" SortExpression="DrugName" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DrugForm" HeaderText="Drug Form"
                        ReadOnly="true"  >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DrugDose" HeaderText="Dose"
                        ReadOnly="true"  >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="StatusOfDose" HeaderText="Dose Status"
                        ReadOnly="true"  >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Filled&Dispatched" HeaderText="Information"
                        ReadOnly="true" SortExpression="Filled&Dispatched" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>                    
                    <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day"
                        ReadOnly="true"  >
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
                    <asp:BoundField DataField="DateDispatched" HeaderText="Dispatch Date"
                        ReadOnly="true" SortExpression="DateDispatched" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ToFill" HeaderText="To Fill"
                        ReadOnly="true" SortExpression="ToFill" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="Prescription Date"
                        ReadOnly="true" SortExpression="PrescriptionDate" >
                        <ItemStyle CssClass="col-xs-2" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle CssClass="pagerStyle" HorizontalAlign="Center" />
                <PagerSettings Mode="NumericFirstLast" />
                
            </asp:GridView>
        </div>
</asp:Content>
