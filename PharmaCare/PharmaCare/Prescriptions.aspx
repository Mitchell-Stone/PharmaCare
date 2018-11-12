<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="PharmaCare.Prescriptions" EnableEventValidation="False" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE PRESCRIPTIONS PAGE</h1>
    <div class="container">
        <div class="row">
            <div class="col-6">
                <label>Patient Name:</label>
                <asp:TextBox runat="server" ID="txtPatient"></asp:TextBox>
                <asp:Button runat="server" ID="btnPatient" Text="Search Patient" OnClick="btnPatient_Click" CssClass="btn btn-outline-primary" />
            </div>
            <div class="col-6">
                <div class="row">
                    <h5 class="font-weight-bold">Patient Details:</h5>
                </div>
                <div class="row">
                    <div class="col-6">
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
                    </div>
                    <div class="col-6">
                        <div class="row">
                    <label class="font-weight-bold col">Type: </label>
                    <asp:Label runat="server" ID="Type" CssClass="col"></asp:Label>
                </div>
                <div class="row">
                    <label class="font-weight-bold col">Doctor: </label>
                    <asp:Label runat="server" ID="DoctorID" CssClass="col"></asp:Label>
                </div>
                <div class="row">
                    <label class="font-weight-bold col">Ward: </label>
                    <asp:Label runat="server" ID="WardID" CssClass="col"></asp:Label>
                </div>
                <div class="row">
                    <label class="font-weight-bold col">Room: </label>
                    <asp:Label runat="server" ID="RoomID" CssClass="col"></asp:Label>
                </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
    <div class="container">
        <div class="table-responsive">
            <h5 class="font-weight-bold">Patient Prescriptions:</h5>
            <asp:GridView ID="DgvPrescriptions" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                OnPreRender="DgvPrescriptions_PreRender"
                EmptyDataText="There Are No Prescriptions For This Patient" EmptyDataRowStyle-ForeColor="Red"
                OnRowDataBound="DgvPrescriptions_RowDataBound" OnSelectedIndexChanged="DgvPrescriptions_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="PrescriptionId" HeaderText="Prescription" ItemStyle-CssClass="d-none" HeaderStyle-CssClass="d-none" />
                    <asp:BoundField DataField="DrugName" HeaderText="Drug" />
                    <asp:BoundField DataField="Name" HeaderText="Patient" />
                    <asp:BoundField DataField="DoctorName" HeaderText="Doctor" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="Date" />
                    <asp:BoundField DataField="AdditionalInformation" HeaderText="Additional Information" NullDisplayText=" " />
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="Prescription Status" />
                    <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose" />
                    <asp:BoundField DataField="FirstTime" HeaderText="First Time" />
                    <asp:BoundField DataField="LastTime" HeaderText="Last Time" />
                    <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day" />
                    <asp:BoundField DataField="StatusOfDose" HeaderText="Dose Status" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="container">
        <h5 class="font-weight-bold">Prescription:</h5>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" ID="presID" CssClass="d-none"></asp:Label>
                <label class="font-weight-bold">Drug:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDrugID" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDrugID" runat="server" ErrorMessage="Drug ID is required"
                    ControlToValidate="PresDrugID" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Patient:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresPatientID" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvPatientID" runat="server" ErrorMessage="Patient ID is required"
                    ControlToValidate="PresPatientID" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Doctor:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDocID" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDocID" runat="server" ErrorMessage="Doctor ID is required"
                    ControlToValidate="PresDocID" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Date:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDate" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Date is required"
                    ControlToValidate="PresDate" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">First Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresFirst" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvFirst" runat="server" ErrorMessage="First time use is required"
                    ControlToValidate="PresFirst" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Prescription Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresStatus" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ErrorMessage="Prescription status is required"
                    ControlToValidate="PresStatus" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Drug Dose:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDrugDose" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDrugDose" runat="server" ErrorMessage="Drug dose is required"
                    ControlToValidate="PresDrugDose" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
                <br />
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Last Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresLast" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvLast" runat="server" ErrorMessage="Last time use is required"
                    ControlToValidate="PresLast" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Dose Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDoseStatus" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Drug dose status is required"
                    ControlToValidate="PresDoseStatus" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Times Per Day:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresTimesADay" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvTimesPerDay" runat="server" ErrorMessage="Times per day is required"
                    ControlToValidate="PresTimesADay" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
            </div>
        </div>
        <div class="row col-sm-12">
            <div class="flex-column w-100">
                <label class="font-weight-bold">Additional Information:</label>
                <br />
                <textarea runat="server" class="w-100" id="PresAddInfo" style="resize: none" rows="3"></textarea>
            </div>
        </div>
        <div class="row">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Create" CssClass="btn btn-outline-primary m-2" ID="btnInsertPres" OnClick="btnInsertPres_Click" ValidationGroup="presValidation" />
                <asp:Button runat="server" Text="Modify" CssClass="btn btn-outline-primary m-2" ID="btnModifyPres" OnClick="btnModifyPres_Click" ValidationGroup="presValidation" />
                <asp:Button runat="server" Text="Clear" CssClass="btn btn-outline-primary m-2" ID="btnClearPres" OnClick="btnClearPres_Click" />
            </div>
        </div>
    </div>
</asp:Content>
