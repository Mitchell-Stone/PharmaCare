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
                        DataValueField="NursingStationId" CssClass="form-control" OnSelectedIndexChanged="ddlNurseStations_SelectedIndexChanged"> <%-- %>OnSelectedIndexChanged="ddlNurseStations_SelectedIndexChanged"> --%>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="NurseStationSource" runat="server" 
                        ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>' 
                        SelectCommand="SELECT DISTINCT [NursingStationId] 
                        FROM [IndoorPrescriptions] 
                        ORDER BY [NursingStationId]" OnSelecting="NurseStationSource_Selecting">
                    </asp:SqlDataSource>

    <%-- Might be an idea to use a grid to display the schedule for a 24 hour period --%>
    <asp:DataGrid ID="scheduleList" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Horizontal" Width="1031px" >
        <AlternatingItemStyle BackColor="#F7F7F7" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <ItemStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" Mode="NumericPages" />
        <SelectedItemStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:DataGrid>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

    <asp:Button ID="btnPrintbtn" runat="server" Text="Print" OnClientClick="javascript:window.print();" />

</asp:Content>

