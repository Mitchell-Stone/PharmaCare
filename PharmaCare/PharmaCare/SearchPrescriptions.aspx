<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPrescriptions.aspx.cs" Inherits="PharmaCare.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <h1>Search Prescription Page</h1>
    <div class="row">
        <div class="col-sm-2">
            <label>Search Patient : </label>
            <asp:TextBox ID="txtSearchPatient" runat="server"></asp:TextBox>
            <asp:Button ID="btnFindPatient" runat="server" Text="Find Patient" />
            <label>Search Prescription by ID : </label>
            <asp:TextBox ID="txtFindPrescription" runat="server"></asp:TextBox>
            <asp:Button ID="btnFindPrescription" runat="server" Text="Find Prescription" />            
        </div>
        <div class="col-sm-2">
            <label> First Name : </label>
            <asp:TextBox ID="txtPFname" runat="server"></asp:TextBox>
            <label> Last Name : </label>
            <asp:TextBox ID="txtPLname" runat="server"></asp:TextBox>
        </div>
       
     <%-- <div class="col-sm-3">
            <label> Floor Number : </label>
            <asp:TextBox ID="txtFloor" runat="server"></asp:TextBox>
            <label> Room Number : </label>
            <asp:TextBox ID="txtRoom" runat="server"></asp:TextBox>
            <label> Wing Number : </label>
            <asp:TextBox ID="txtWing" runat="server"></asp:TextBox>
        </div>--%> 
          
        <div class="col-sm-1">
            <asp:GridView ID="dgvPrescriptions" runat="server" AutoGenerateColumns="false" DataSourceID="GetPrescriptions"
                ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>' 
                        SelectCommand="SELECT [PrescriptionId], [DrugId], [PatientName], 
                        [PrescriptionDate], [PrescribingDoctor], [AdditionalInformation],[PrescriptionStatus],[DrugDose],[FirstTime],[LastTime],[TimesPerDay],[StatusOfDose] FROM [Prescription] 
                        ORDER BY [PatientName]" >
                <Columns>

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
