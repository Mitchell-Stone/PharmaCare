<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="PharmaCare.Prescriptions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE PRESCRIPTIONS PAGE</h1>
    <div class="col-sm-12">
        <label>Patient Name:</label>
        <asp:TextBox runat="server" ID="txtPatient"></asp:TextBox>
        <asp:Button runat="server" ID="btnPatient" Text="Search Patient" OnClick="btnPatient_Click" CssClass="btn-primary" />
    </div>
    <div class="container">
        <div class="row">
    <div runat="server" class=" col-lg-2" id="PatientDetails">
        <h5 class="font-weight-bold">Patient Details:</h5>
        <div>
            <div class="row"><label class="font-weight-bold col">Name: </label><asp:Label runat="server" ID="Name" CssClass="col"></asp:Label></div>
            <div class="row"><label class="font-weight-bold col">Address: </label><asp:Label runat="server" ID="Address" CssClass="col"></asp:Label></div>
            <div class="row"><label class="font-weight-bold col">City: </label><asp:Label runat="server" ID="City" CssClass="col"></asp:Label></div>
            <div class="row"><label class="font-weight-bold col">ZipCode: </label><asp:Label runat="server" ID="Zip" CssClass="col"></asp:Label></div>
            <div class="row"><label class="font-weight-bold col">Type: </label><asp:Label runat="server" ID="Type" CssClass="col"></asp:Label></div>
            <div class="row"><label class="font-weight-bold col">DoctorID: </label><asp:Label runat="server" ID="DoctorID" CssClass="col"></asp:Label></div>
            <div class="row"><label class="font-weight-bold col">WardID: </label><asp:Label runat="server" ID="WardID" CssClass="col"></asp:Label></div>
            <div class="row"><label class="font-weight-bold col">RoomID: </label><asp:Label runat="server" ID="RoomID" CssClass="col"></asp:Label></div>
        </div>
    </div>
    <div class="table-responsive col-lg-10">
        <h5 class="font-weight-bold">Patient Prescriptions:</h5>
        <asp:GridView ID="DgvPrescriptions" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
            DataKeyNames="PrescriptionId" OnPreRender="DgvPrescriptions_PreRender"
            EmptyDataText="There Are No Prescriptions For This Patient" EmptyDataRowStyle-ForeColor="Red">
            <Columns>
                <%--<asp:BoundField DataField="PrescriptionId" HeaderText="Prescription ID" />--%>
                <asp:BoundField DataField="DrugId" HeaderText="Drug ID" />
                <asp:BoundField DataField="PatientID" HeaderText="Patient ID" />
                <asp:BoundField DataField="DoctorID" HeaderText="Doctor ID" />
                <asp:BoundField DataField="PrescribingDate" HeaderText="Date" />
                <asp:BoundField DataField="InformationExtra" HeaderText="Extra Information" />
                <asp:BoundField DataField="StatusPrescription" HeaderText="Status" />
                <asp:BoundField DataField="Doses" HeaderText="Drug Dose" />
                <asp:BoundField DataField="FirstTimeUse" HeaderText="First Time" />
                <asp:BoundField DataField="LastTimeUse" HeaderText="Last Time" />
                <asp:BoundField DataField="FrequenseUseInADay" HeaderText="Times Per Day" />
                <asp:BoundField DataField="DoseStatus" HeaderText="Status Of Dose" />
<%--                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnEditPrescription" runat="server" CausesValidation="false" CommandName="Edit"
                            Text="Edit" CommandArgument='<%# Eval("PrescriptionId") %>' CssClass="btn-primary" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDeletePrecription" runat="server" CausesValidation="false" CommandName="Delete"
                            Text="Delete" CommandArgument='<%# Eval("PrescriptionId") %>' CssClass="btn-primary" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
                    </div>
    </div>
</asp:Content>
