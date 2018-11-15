<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrintLabels.aspx.cs" Inherits="PharmaCare.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div class="row">
        <h1>Patient Labels</h1>
        <div class="prescription-label">
            <asp:Label runat="server" ID="lblPatientId" Text=""></asp:Label>
            <asp:Label runat="server" ID="lblDoctorName" Text=""></asp:Label>
            <asp:Label runat="server" ID="lblPatientName" Text=""></asp:Label>
            <asp:Label runat="server" ID="lblDrugName" Text=""></asp:Label>
            <asp:Label runat="server" ID="lblDrugDose" Text=""></asp:Label>
            <asp:Label runat="server" ID="lblTimesPerDay" Text=""></asp:Label>
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
                    <asp:Button runat="server" Text="Print Label" CommandName="PrintLabel" 
                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                        CssClass="btn btn-outline-primary m-2 btn-md btn-block" ID="btnPrintLabel"
                        AutoPostBack="True"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
