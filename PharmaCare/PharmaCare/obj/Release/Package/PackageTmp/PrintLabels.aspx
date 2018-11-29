<%--
    Created by: Mitchell Stone 451381461
    Date Created: 5th Novemeber 2018
    Purpose = The Print Labes page displays all the currently active prescriptions so they can be printed.
    Bugs = nil
    
--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintLabels.aspx.cs" Inherits="PharmaCare.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div class="col-6">
        <div class="row">
            <h1>Patient Labels</h1>       
        </div>
        <div class="row">
            <h2>Listing Currently Active Prescriptions</h2>
        </div>
    </div>
    <div class="col-6">
        <div class="prescription-label">
            <h2 class="label-heading">Pharmacare Prescription Label</h2>
            <div class="row col-lg-12">
                <asp:Label CssClass="label-content" runat="server" ID="lblPatientId" Text="Patient ID:    "></asp:Label>
                <asp:Label CssClass="label-content" runat="server" ID="lblPatientName" Text="Patient Name:    "></asp:Label> 
            </div>
            <div class="row col-lg-12">
                <asp:Label CssClass="label-content" runat="server" ID="lblDoctorName" Text="Prescribing Doctor:    "></asp:Label>
                <asp:Label CssClass="label-content" runat="server" ID="lblDrugName" Text="Drug Prescribed:    "></asp:Label>
            </div>
            <div class="row col-lg-12">
                <asp:Label CssClass="label-content" runat="server" ID="lblDrugDose" Text="Dose Prescribed:    "></asp:Label>
                <asp:Label CssClass="label-content" runat="server" ID="lblTimesPerDay" Text="Take prescribed dose 0 time/s per day"></asp:Label>
            </div>
        </div>
    </div>
    <asp:GridView ID="gvLabelList" runat="server" AutoPostBack="True" 
        AutoGenerateColumns="false" CssClass="table table-hover table-bordered" OnRowCommand="gvLabelList_RowCommand">
        <Columns>
            <asp:BoundField DataField="PatientId" HeaderText="Patient ID"
                SortExpression="PatientId"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Patient Name"
                SortExpression="Name"></asp:BoundField>
            <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name"
                SortExpression="DoctorName"></asp:BoundField>
            <asp:BoundField DataField="DrugName" HeaderText="Drug Name"
                SortExpression="DrugName"></asp:BoundField>
            <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose"
                SortExpression="DrugDose"></asp:BoundField>
            <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day"
                SortExpression="TimesPerDay"></asp:BoundField>
            <asp:TemplateField HeaderText="Printing Options">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Preview Label" CommandName="ViewLabel" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        CssClass="btn btn-outline-primary m-2 btn-md btn-block" ID="btnViewLabel"
                        AutoPostBack="True"/>
                    <asp:Button runat="server" Text="Print Label" CommandName="PrintLabel" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        CssClass="btn btn-outline-primary m-2 btn-md btn-block" ID="btnPrintLabel"
                        AutoPostBack="True" OnClientClick="javascript:window.print();"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
