<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreparationList.aspx.cs" Inherits="PharmaCare.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <asp:DataGrid ID="dgPreperationList" runat="server" AutoPostBack="True"
                    DataSourceID="PrepDataSource" DataValueField="Pre" 
                    CssClass="form-control">


    </asp:DataGrid>

    <asp:SqlDataSource ID="PrepDataSource" runat="server" 
        ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>' 
        SelectCommand="SELECT [Drugs].[DrugName], [Drugs].[DrugForm], [Prescription].[DrugDose], [Prescription].[TimesPerDay] 
        FROM [Prescription]
        LEFT JOIN [Drugs] ON [Prescription].[DrugId] = [Drugs].[DrugId]
        WHERE [Prescription].[PrescriptionStatus] = 'verified'
        ORDER BY [DrugName]">
    </asp:SqlDataSource>

</asp:Content>
