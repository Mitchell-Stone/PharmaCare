<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NursingStationListPharma.aspx.cs" Inherits="PharmaCare.NursingStationListPharma" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nursing Staion List</title>
     <link href="Content/site.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="content/stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron text-center">
            <h1>Nursing Station List</h1>
        </div>
        <div class="container">
  <h2>Basic Table</h2>           
  
    </div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </form>
</body>
</html>
