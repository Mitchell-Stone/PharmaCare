<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreparationList.aspx.cs" Inherits="PharmaCare.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div class="row">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Show Active Prescriptions" 
                    CssClass="btn btn-outline-primary m-2" ID="btnActivePres" OnClick="btnActivePres_Click"/>
                <asp:Button runat="server" Text="Show Verified Prescriptions" 
                    CssClass="btn btn-outline-primary m-2" ID="btnVerifiedPres" OnClick="btnVerifiedPres_Click"/>
            </div>
        </div>
    <asp:GridView ID="gvPrepList" runat="server" AutoPostBack="True" 
        AutoGenerateColumns="false" CssClass="table table-hover table-bordered">
        <Columns>
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
            <asp:ButtonField Text="Set Active" HeaderText="Prescription Status"
                CommandName="SetPrescriptionActive" ButtonType="Button" 
                ControlStyle-CssClass="btn btn-outline-primary m-2 btn-md btn-block"></asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>



