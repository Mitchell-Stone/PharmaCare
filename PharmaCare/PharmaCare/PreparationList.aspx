<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreparationList.aspx.cs" Inherits="PharmaCare.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label runat="server" ID="table_header" AutoPostBack="true" CssClass="h1"
                Text="Displaying Non-Verified Prescriptions"></asp:Label>
        </div>
        <div class="row">
            <p>This page is to assist with the preperation of patient prescriptions.
                Use the buttons below to toggle between all active and non-verified prescriptions</p>
        </div>
        <div class="row">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Show Non-Verified Prescriptions" 
                    CssClass="btn btn-outline-primary m-2" ID="btnNonVerifiedPres" OnClick="btnNonVerifiedPres_Click"/>
                <asp:Button runat="server" Text="Show Active Prescriptions" 
                    CssClass="btn btn-outline-primary m-2" ID="btnActivePres" OnClick="btnActivePres_Click"/>         
            </div>
        </div>   
    </div>
    <asp:GridView ID="gvPrepList" runat="server" AutoPostBack="True" 
        AutoGenerateColumns="false" CssClass="table table-hover table-bordered" OnRowCommand="gvPrepList_RowCommand">
        <Columns>
            <asp:BoundField DataField="PrescriptionId" HeaderText="ID"
                SortExpression="PrescriptionId"></asp:BoundField>
            <asp:BoundField DataField="PrescriptionDate" HeaderText="Prescription Date"
                SortExpression="PrescriptionDate"></asp:BoundField>
            <asp:BoundField DataField="DrugName" HeaderText="Drug Name"
                SortExpression="DrugName"></asp:BoundField>
            <asp:BoundField DataField="DrugForm" HeaderText="Drug Form"
                SortExpression="DrugForm"></asp:BoundField>
            <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose (mg)"
                SortExpression="DrugDose"></asp:BoundField>
            <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day"
                SortExpression="TimesPerDay"></asp:BoundField>
            <asp:TemplateField HeaderText="Prescription Status">
                <ItemTemplate>
                    <asp:Button runat="server" Text="Set Active" CommandName="SetPrescriptionActive" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        CssClass="btn btn-outline-primary m-2 btn-md btn-block" ID="btnSetActive"
                        AutoPostBack="True"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label runat="server" ID="test"></asp:Label>
</asp:Content>



