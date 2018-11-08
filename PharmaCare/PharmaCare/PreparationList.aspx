<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreparationList.aspx.cs" Inherits="PharmaCare.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <asp:GridView ID="gvPrepList" runat="server" AutoPostBack="True" AutoGenerateColumns="false" CssClass="grid">
        <Columns>
            <asp:BoundField DataField="PrescriptionDate" HeaderText="Prescription Date"
                SortExpression="PrescriptionDate"></asp:BoundField>
            <asp:BoundField DataField="DrugName" HeaderText="Drug Name"
                SortExpression="DrugName"></asp:BoundField>
            <asp:BoundField DataField="DrugForm" HeaderText="Drug Form"
                SortExpression="DrugForm"></asp:BoundField>
            <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose"
                SortExpression="DrugDose"></asp:BoundField>
            <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day"
                SortExpression="TimesPerDay"></asp:BoundField>
            <asp:ButtonField Text="Preperation Complete" HeaderText="P" 
                CommandName="PreperationComeplete" ButtonType="Button"></asp:ButtonField>
            <asp:ButtonField Text="Set Active" 
                CommandName="SetPrescriptionActive" ButtonType="Button"></asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>



