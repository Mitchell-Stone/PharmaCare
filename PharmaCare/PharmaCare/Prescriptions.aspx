<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="PharmaCare.Prescriptions" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE PRESCRIPTIONS PAGE</h1>
    <div class="col-sm-12">
        <label>Patient Name:</label>
        <asp:TextBox runat="server" ID="txtPatient"></asp:TextBox>
        <asp:Button runat="server" ID="btnPatient" Text="Search Patient" OnClick="btnPatient_Click" CssClass="btn btn-outline-primary" />
    </div>
    <div class="container">
        <div class="row">
            <div runat="server" class=" col-lg-2" id="PatientDetails">
                <h5 class="font-weight-bold">Patient Details:</h5>
                <div>
                    <div class="row">
                        <label class="font-weight-bold col">Name: </label>
                        <asp:Label runat="server" ID="Name" CssClass="col"></asp:Label>
                    </div>
                    <div class="row">
                        <label class="font-weight-bold col">Address: </label>
                        <asp:Label runat="server" ID="Address" CssClass="col"></asp:Label>
                    </div>
                    <div class="row">
                        <label class="font-weight-bold col">City: </label>
                        <asp:Label runat="server" ID="City" CssClass="col"></asp:Label>
                    </div>
                    <div class="row">
                        <label class="font-weight-bold col">ZipCode: </label>
                        <asp:Label runat="server" ID="Zip" CssClass="col"></asp:Label>
                    </div>
                    <div class="row">
                        <label class="font-weight-bold col">Type: </label>
                        <asp:Label runat="server" ID="Type" CssClass="col"></asp:Label>
                    </div>
                    <div class="row">
                        <label class="font-weight-bold col">DoctorID: </label>
                        <asp:Label runat="server" ID="DoctorID" CssClass="col"></asp:Label>
                    </div>
                    <div class="row">
                        <label class="font-weight-bold col">WardID: </label>
                        <asp:Label runat="server" ID="WardID" CssClass="col"></asp:Label>
                    </div>
                    <div class="row">
                        <label class="font-weight-bold col">RoomID: </label>
                        <asp:Label runat="server" ID="RoomID" CssClass="col"></asp:Label>
                    </div>
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
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="container">
        <h5 class="font-weight-bold">Prescription:</h5>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">PatientID:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresPatientID"></asp:TextBox>
                </div>
            <div class="col-md-4">
                <label class="font-weight-bold">DoctorID:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDocID"></asp:TextBox>
                </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Date:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDate"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">DrugID:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDrugID"></asp:TextBox>
                </div>
            <div class="col-md-4">
                <label class="font-weight-bold">First Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresFirst"></asp:TextBox>
                </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresStatus"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Drug Dose:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDrugDose"></asp:TextBox>
                </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Last Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresLast"></asp:TextBox>
                </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Dose Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDoseStatus"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Times Per Day:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresTimesADay"></asp:TextBox>
                </div>
            <div class="col-md-4">
            </div>
        </div>
        <div class="row col-sm-12">
            <div class="flex-column w-100">
                <label class="font-weight-bold">Additional Information:</label>
                <br />
            <textarea runat="server" class="w-100" id="PresAddInfo" style="resize:none" rows="3"></textarea>
            </div>
        </div>
        <div class="row">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Insert" CssClass="btn btn-outline-primary" ID="btnInsertPres" OnClick="btnInsertPres_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
