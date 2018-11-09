<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="PharmaCare.Prescriptions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE PRESCRIPTIONS PAGE</h1>
    <div>
        <asp:SqlDataSource runat="server" ID="Patients" ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>'
            SelectCommand="SELECT Patients.PatientID, Patients.Name, Patients.Address, Patients.City, Patients.ZipCode, 
            Patients.Type, Doctors.Name AS DocName, Patients.WardID, Patients.RoomID FROM Patients INNER JOIN Doctors ON
            Patients.DoctorID = Doctors.DoctorID ORDER BY Patients.Name"></asp:SqlDataSource>
        <asp:GridView runat="server" ID="DgvPatients" AutoGenerateColumns="False" DataSourceID="Patients"
            CssClass="table table-bordered table-striped table-condensed"
            OnPreRender="DgvPatients_PreRender" DataKeyNames="PatientID" AllowPaging="True" OnRowCommand="DgvPatients_RowCommand">
            <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="PatientID" SortExpression="PatientID" ReadOnly="True"></asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address"></asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
                <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode"></asp:BoundField>
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type"></asp:BoundField>
                <asp:BoundField DataField="DocName" HeaderText="Doctor" SortExpression="DocName"></asp:BoundField>
                <asp:BoundField DataField="WardID" HeaderText="Ward" SortExpression="WardID"></asp:BoundField>
                <asp:BoundField DataField="RoomID" HeaderText="Room" SortExpression="RoomID" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnViewPatientPrecriptions" runat="server" CausesValidation="false" CommandName="View"
                            Text="View Prescription" CommandArgument='<%# Eval("PatientID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" />
        </asp:GridView>
    </div>
</asp:Content>
