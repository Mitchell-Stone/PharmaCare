<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreparationList.aspx.cs" Inherits="PharmaCare.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <asp:DataGrid ID="dgPreperationList" runat="server" AutoPostBack="True" AutoGenerateColumns="false" CssClass="grid">
        <Columns>
            <asp:BoundColumn DataField="PrescriptionDate" HeaderText="Prescription Date"
                SortExpression="PrescriptionDate"></asp:BoundColumn>
            <asp:BoundColumn DataField="DrugName" HeaderText="Drug Name"
                SortExpression="DrugName"></asp:BoundColumn>
            <asp:BoundColumn DataField="DrugForm" HeaderText="Drug Form"
                SortExpression="DrugForm"></asp:BoundColumn>
            <asp:BoundColumn DataField="DrugDose" HeaderText="Drug Dose"
                SortExpression="DrugDose"></asp:BoundColumn>
            <asp:BoundColumn DataField="TimesPerDay" HeaderText="Times Per Day"
                SortExpression="TimesPerDay"></asp:BoundColumn>
            <asp:ButtonColumn ButtonType="PushButton" Text="Preperation Complete" 
                CommandName="PreperationComeplete"></asp:ButtonColumn>
            <asp:ButtonColumn ButtonType="PushButton" Text="Set Active" 
                CommandName="SetPrescriptionActive"></asp:ButtonColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>



