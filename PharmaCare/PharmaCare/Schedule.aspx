<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="PharmaCare.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <h1>Administer Drug Schedule</h1>
    <h2>Select a nursing station:</h2>

    <%-- This dropdown list is so you can filter the schedule by nursing station --%>
    <asp:DropDownList ID="ddlNurseStations" runat="server" AutoPostBack="True" 
                        DataSourceID="NurseStationSource" DataTextField="NursingStationId" 
                        DataValueField="NursingStationId" CssClass="form-control" OnSelectedIndexChanged="ddlNurseStations_SelectedIndexChanged"
                        EnableViewState="true" AppendDataboundItems="true"> <%-- %>OnSelectedIndexChanged="ddlNurseStations_SelectedIndexChanged"> --%>
                        <asp:ListItem Selected="True" Value="0">Please select a Nursing Station</asp:ListItem>               
    </asp:DropDownList>
                    <asp:SqlDataSource ID="NurseStationSource" runat="server" 
                        ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>' 
                        SelectCommand="SELECT DISTINCT [NursingStationId] 
                        FROM [IndoorPrescriptions] 
                        ORDER BY [NursingStationId]" OnSelecting="NurseStationSource_Selecting">
                    </asp:SqlDataSource>

    <%-- Might be an idea to use a grid to display the schedule for a 24 hour period --%>
    <asp:DataGrid ID="scheduleList" runat="server" AutoPostBack="True" 
            AutoGenerateColumns="true" CssClass="table table-hover table-bordered">
    </asp:DataGrid>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

    <asp:Button ID="btnPrintbtn" runat="server" CssClass="btn btn-outline-primary m-2" Text="Print" OnClientClick="javascript:window.print();" />


</asp:Content>

