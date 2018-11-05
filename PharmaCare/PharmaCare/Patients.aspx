<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patients.aspx.cs" Inherits="PharmaCare.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <h1>ADD NEW PATIENT OR FIND PATIENT</h1>
    <div class="row">
        <div class="col-sm-2">
            <label>Patient ID : </label>
            <asp:TextBox ID="txtPId" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <label> First Name : </label>
            <asp:TextBox ID="txtPFname" runat="server"></asp:TextBox>
            <label> Last Name : </label>
            <asp:TextBox ID="txtPLname" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-3">
            <label> Floor Number : </label>
            <asp:TextBox ID="txtFloor" runat="server"></asp:TextBox>
            <label> Room Number : </label>
            <asp:TextBox ID="txtRoom" runat="server"></asp:TextBox>
            <label> Wing Number : </label>
            <asp:TextBox ID="txtWing" runat="server"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <asp:Button ID="btnAddPatient" runat="server" Text="Add Patient" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update Patient" />
        </div>
        <div class="col-sm-2">
            <asp:TextBox ID="txtFind" runat="server"></asp:TextBox>
            <asp:Button ID="btnFindPatient" runat="server" Text="Find Patient" />
        </div>  
        <div class="col-sm-1">
            <asp:GridView ID="dgvPrescriptions" runat="server" AutoGenerateColumns="false" DataSourceID=""
                DataKeyNames="" >
                <Columns>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
