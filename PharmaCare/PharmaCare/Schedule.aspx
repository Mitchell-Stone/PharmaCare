<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="PharmaCare.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <h1>Administer Drug Schedule</h1>
    <h2>Select a nursing station:</h2>
    <%-- Put this in here for you kyle to give you a bit of a head start --%>

    <%-- This dropdown list is so you can filter the schedule by nursing station --%>
    <asp:DropDownList ID="ddlNurseStations" runat="server" AutoPostBack="True" 
                        DataSourceID="NurseStationSource" DataTextField="NursingStationId" 
                        DataValueField="NursingStationId" CssClass="form-control">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="NurseStationSource" runat="server" 
                        ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>' 
                        SelectCommand="SELECT [NursingStationId] 
                        FROM [IndoorPrescriptions] 
                        ORDER BY [NursingStationId]">
                    </asp:SqlDataSource>

    <%-- Might be an idea to use a grid to display the schedule for a 24 hour period --%>
    <asp:DataGrid runat="server"></asp:DataGrid>
</asp:Content>
