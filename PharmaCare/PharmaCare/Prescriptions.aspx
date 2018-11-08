<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="PharmaCare.Prescriptions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE PRESCRIPTIONS PAGE</h1>
    <div>
        <asp:SqlDataSource runat="server" ID="Patients" ConnectionString='<%$ ConnectionStrings:PharmaCareDB %>'
            SelectCommand="SELECT * FROM [Patients] ORDER BY [Name]">

        </asp:SqlDataSource>
        <asp:GridView runat="server"  ID="DgvPatients"  AutoGenerateColumns="False" DataSourceID="Patients"
                CssClass="table table-bordered table-striped table-condensed"
                OnPreRender="DgvPatients_PreRender" DataKeyNames="PatientID">
            <Columns>
                    <asp:BoundField DataField="PatientID" HeaderText="PatientID"
                        ReadOnly="True" SortExpression="PatientID" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" >
                    </asp:BoundField>
                    <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" >
                    </asp:BoundField>
                    <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" >
                    </asp:BoundField>
                    <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" >
                    </asp:BoundField>
                    <asp:BoundField DataField="DoctorID" HeaderText="DoctorID" SortExpression="DoctorID" >
                    </asp:BoundField>
                    <asp:BoundField DataField="WardID" HeaderText="WardID" SortExpression="WardID" >
                    </asp:BoundField>
                    <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" >
                    </asp:BoundField>
                </Columns>
                <PagerSettings Mode="NumericFirstLast" />
        </asp:GridView>
    </div>
</asp:Content>
