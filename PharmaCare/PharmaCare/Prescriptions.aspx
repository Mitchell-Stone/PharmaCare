<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="PharmaCare.Prescriptions" EnableEventValidation="False" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE PRESCRIPTIONS PAGE</h1>
    <div class="container">
        <div class="row">
            <div class="col-6">
                <label>Patient Name:</label>
                <asp:TextBox runat="server" ID="txtPatient"></asp:TextBox>
                <asp:Button runat="server" ID="btnPatient" Text="Search Patient" OnClick="btnPatient_Click" CssClass="btn btn-outline-primary float-right" />
                <br />
                <div class="table-responsive">
                    <asp:GridView ID="dgvPatients" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover"
                        EmptyDataText="No Patients With that Name" EmptyDataRowStyle-ForeColor="Red" AutoGenerateSelectButton="True"
                        OnPreRender="dgvPatients_PreRender" ShowHeader="False" OnRowDataBound="dgvPatients_RowDataBound" OnSelectedIndexChanged="dgvPatients_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="PatientId" ItemStyle-CssClass="d-none" HeaderStyle-CssClass="d-none" />
                            <asp:BoundField DataField="Name" />
                            <asp:BoundField DataField="Address" />
                            <asp:BoundField DataField="Type" />
                        </Columns>
                    </asp:GridView>
                </div>
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
    <div class="row">
        <div class="mx-auto">
            <asp:Button runat="server" Text="Indoor" CssClass="btn btn-outline-primary m-2" ID="btnIndoor" OnClick="btnIndoor_Click" />
            <asp:Button runat="server" Text="Outdoor" CssClass="btn btn-outline-primary m-2" ID="btnOutdoor" OnClick="btnOutdoor_Click" />
        </div>
    </div>
    <div class="container">
        <%-- Indoor Table --%>
        <div class="table-responsive" id="IndoorTable" runat="server" visible="true">
            <h5 class="font-weight-bold">Patient Indoor Prescriptions:</h5>
            <asp:GridView ID="DgvPrescriptions" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover"
                OnPreRender="DgvPrescriptions_PreRender" AutoGenerateSelectButton="true"
                EmptyDataText="There Are No Indoor Prescriptions For This Patient" EmptyDataRowStyle-ForeColor="Red"
                OnRowDataBound="DgvPrescriptions_RowDataBound" OnSelectedIndexChanged="DgvPrescriptions_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="PrescriptionId" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Patient" />
                    <asp:BoundField DataField="DoctorName" HeaderText="Doctor" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="Date" />
                    <asp:BoundField DataField="AdditionalInformation" HeaderText="Additional Information" NullDisplayText=" " />
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="Prescription Status" />
                    <asp:BoundField DataField="RoomNumber" HeaderText="Room" />
                    <asp:BoundField DataField="WingNumber" HeaderText="Wing" />
                    <asp:BoundField DataField="FloorNumber" HeaderText="Floor" />
                    <asp:BoundField DataField="NursingStationId" HeaderText="Nursing Station" />
                </Columns>
            </asp:GridView>
        </div>
        <%-- End Indoor Table --%>
        <%-- Outdoor Table --%>
        <div class="table-responsive" id="OutdoorTable" runat="server" visible="false">
            <h5 class="font-weight-bold">Patient Outdoor Prescriptions:</h5>
            <asp:GridView ID="DgvOutdoorPrescriptions" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true"
                CssClass="table table-striped table-bordered table-hover" EmptyDataText="There Are No Outdoor Prescriptions For This Patient"
                EmptyDataRowStyle-ForeColor="Red" OnPreRender="DgvOutdoorPrescriptions_PreRender"
                OnRowDataBound="DgvOutdoorPrescriptions_RowDataBound" OnSelectedIndexChanged="DgvOutdoorPrescriptions_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="PrescriptionId" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Patient" />
                    <asp:BoundField DataField="DoctorName" HeaderText="Doctor" />
                    <asp:BoundField DataField="PrescriptionDate" HeaderText="Date" />
                    <asp:BoundField DataField="AdditionalInformation" HeaderText="Additional Information" NullDisplayText=" " />
                    <asp:BoundField DataField="PrescriptionStatus" HeaderText="Prescription Status" />
                    <asp:BoundField DataField="Filled&Dispatched" HeaderText="Filled & Dispatched" />
                    <asp:BoundField DataField="DateDispatched" HeaderText="Date Dispatched" />
                    <asp:BoundField DataField="TimeDispatched" HeaderText="Date Dispatched" />
                    <asp:BoundField DataField="IndoorEmergency" HeaderText="Indoor Emergency" />
                    <asp:BoundField DataField="ToFill" HeaderText="To Fill" />
                </Columns>
            </asp:GridView>
        </div>
        <%-- End Outdoor Table --%>
    </div>
    <%-- Indoor Prescription Div --%>
    <div id="Indoor" class="container" runat="server" visible="true">
        <h5 class="font-weight-bold">Indoor Prescription:</h5>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Patient:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresPatientID" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvPatientID" runat="server" ErrorMessage="Patient is required"
                    ControlToValidate="PresPatientID" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Doctor:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDocID" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDocID" runat="server" ErrorMessage="Doctor is required"
                    ControlToValidate="PresDocID" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Date:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDate" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="Date is required"
                    ControlToValidate="PresDate" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresStatus" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ErrorMessage="Prescription status is required"
                    ControlToValidate="PresStatus" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Room Number:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtRoom" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvRoom" runat="server" ErrorMessage="Room Number is required"
                    ControlToValidate="txtRoom" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Wing Number:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtWing" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvWing" runat="server" ErrorMessage="Wing Number is required"
                    ControlToValidate="txtWing" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Floor Number:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtFloor" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvFloor" runat="server" ErrorMessage="Floor Number is required"
                    ControlToValidate="txtFloor" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Nursing Station:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtNursingStationId" ValidationGroup="presValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvNursingStationId" runat="server" ErrorMessage="Nursing Station Id is required"
                    ControlToValidate="txtNursingStationId" CssClass="text-danger float-right" ValidationGroup="presValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row col-md">
            <div class="flex-column w-100">
                <label class="font-weight-bold">Additional Information:</label>
                <textarea runat="server" class="w-100" id="PresAddInfo" style="resize: none" rows="2"></textarea>
            </div>
        </div>
        <div class="row col-md table-responsive">
            <label class="font-weight-bold">Drug Details:</label><br />
            <asp:GridView runat="server" ID="dgvAddPrescriptionDetails" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" 
                EmptyDataText="No Drug Details for this Indoor Prescription" EmptyDataRowStyle-ForeColor="Red" AutoGenerateSelectButton="true"
                OnRowDataBound="dgvAddPrescriptionDetails_RowDataBound" OnSelectedIndexChanged="dgvAddPrescriptionDetails_SelectedIndexChanged" 
                OnPreRender="dgvAddPrescriptionDetails_PreRender">
                <Columns>
                    <asp:BoundField DataField="DrugDetailsId" HeaderText="ID" />
                    <asp:BoundField DataField="DrugName" HeaderText="Drug" />
                    <asp:BoundField DataField="DrugForm" HeaderText="Drug Form" />
                    <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose(mg)" />
                    <asp:BoundField DataField="FirstTime" HeaderText="First Time" />
                    <asp:BoundField DataField="LastTime" HeaderText="Last Time" />
                    <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day" />
                    <asp:BoundField DataField="StatusOfDose" HeaderText="Dose Status" />
                    
                </Columns>
            </asp:GridView>
        </div>
        <div class="row" runat="server" id="IndoorBtns" visible="true">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Check Cocktail" CssClass="btn btn-outline-primary m-2" ID="btnCheckCocktail" OnClick="btnCheckCocktail_Click" />
                <asp:Button runat="server" Text="Create" CssClass="btn btn-outline-primary m-2" ID="btnInsert" OnClick="btnInsertPres_Click" ValidationGroup="presValidation" />
                <asp:Button runat="server" Text="Modify" CssClass="btn btn-outline-primary m-2" ID="btnModify" OnClick="btnModifyPres_Click" ValidationGroup="presValidation" />
                <asp:Button runat="server" Text="Clear" CssClass="btn btn-outline-primary m-2" ID="btnClear" OnClick="btnClearPres_Click" />
            </div>
        </div>
        <h5 class="font-weight-bold">Add/Edit Drug:</h5>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" ID="presID" CssClass="d-none"></asp:Label>
                <asp:Label runat="server" ID="txtDrugDetailsId" CssClass="d-none"></asp:Label>
                <label class="font-weight-bold">Drug:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDrugID" ValidationGroup="InValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDrugID" runat="server" ErrorMessage="Drug is required"
                    ControlToValidate="PresDrugID" CssClass="text-danger float-right" ValidationGroup="InValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Drug Dose:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDrugDose" ValidationGroup="InValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDrugDose" runat="server" ErrorMessage="Drug dose is required"
                    ControlToValidate="PresDrugDose" CssClass="text-danger float-right" ValidationGroup="InValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Dose Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresDoseStatus" ValidationGroup="InValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Drug dose status is required"
                    ControlToValidate="PresDoseStatus" CssClass="text-danger float-right" ValidationGroup="InValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">First Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresFirst" ValidationGroup="InValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvFirst" runat="server" ErrorMessage="First time use is required"
                    ControlToValidate="PresFirst" CssClass="text-danger float-right" ValidationGroup="InValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Last Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresLast" ValidationGroup="InValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvLast" runat="server" ErrorMessage="Last time use is required"
                    ControlToValidate="PresLast" CssClass="text-danger float-right" ValidationGroup="InValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Times Per Day:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="PresTimesADay" ValidationGroup="InValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvTimesPerDay" runat="server" ErrorMessage="Times per day is required"
                    ControlToValidate="PresTimesADay" CssClass="text-danger float-right" ValidationGroup="InValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Add" CssClass="btn btn-outline-primary m-2" ID="btnAddPresDetails"
                    OnClick="btnAddPresDetails_Click" ValidationGroup="InValidation" />
                <asp:Button runat="server" Text="Edit" CssClass="btn btn-outline-primary m-2" ID="btnEditPresDetails"
                    OnClick="btnEditPresDetails_Click" ValidationGroup="InValidation" />
            </div>
        </div>
    </div>
    <%-- End Of Indoor Prescription --%>
    <%-- OutDoor Prescription Div --%>
    <div id="Outdoor" class="container" runat="server" visible="false">
        <h5 class="font-weight-bold">Outdoor Prescription:</h5>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Patient:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutPatient" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutPatient" runat="server" ErrorMessage="Patient is required"
                    ControlToValidate="txtOutPatient" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Doctor:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutDoctor" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDoctor" runat="server" ErrorMessage="Doctor is required"
                    ControlToValidate="txtOutDoctor" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Date:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutDate" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutDate" runat="server" ErrorMessage="Date is required"
                    ControlToValidate="txtOutDate" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Prescription Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutPresStatus" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutPresStatus" runat="server" ErrorMessage="Prescription status is required"
                    ControlToValidate="txtOutPresStatus" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Filled & Dispatched:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtFilledDispatched" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvFilledDispatched" runat="server" ErrorMessage="Filled and Dispatched is required"
                    ControlToValidate="txtFilledDispatched" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Date Dispatched:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtDateDispatched" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvDateDispatched" runat="server" ErrorMessage="Date Dispatched is required"
                    ControlToValidate="txtDateDispatched" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">Time Dispatched:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtTimeDispatched" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvTimeDispatched" runat="server" ErrorMessage="Time Dispatched is required"
                    ControlToValidate="txtTimeDispatched" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Indoor Emergency:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtInEmergency" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvInEmergency" runat="server" ErrorMessage="Indoor Emergency is required"
                    ControlToValidate="txtInEmergency" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">To Fill:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtToFill" ValidationGroup="presOutValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvToFill" runat="server" ErrorMessage="To Fill is required"
                    ControlToValidate="txtToFill" CssClass="text-danger float-right" ValidationGroup="presOutValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row col-md">
            <div class="flex-column w-100">
                <label class="font-weight-bold">Additional Information:</label>
                <textarea runat="server" class="w-100" id="txtOutPresDetails" style="resize: none" rows="2"></textarea>
            </div>
        </div>
        <div class="row col-md table-responsive">
            <label class="font-weight-bold">Drug Details:</label><br />
            <asp:GridView runat="server" ID="dgvOutdoorDrugDetails" AutoGenerateColumns="false" CssClass="table table-bordered table-hover">
                <Columns>
                    <asp:BoundField DataField="DrugName" HeaderText="Drug" />
                    <asp:BoundField DataField="DrugForm" HeaderText="Drug Form" />
                    <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose(mg)" />
                    <asp:BoundField DataField="FirstTime" HeaderText="First Time" />
                    <asp:BoundField DataField="LastTime" HeaderText="Last Time" />
                    <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day" />
                    <asp:BoundField DataField="StatusOfDose" HeaderText="Dose Status" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="row" runat="server" id="OutdoorBtns" visible="false">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Check Cocktail" CssClass="btn btn-outline-primary m-2" ID="btnCheckOutCocktail" OnClick="btnCheckOutCocktail_Click" />
                <asp:Button runat="server" Text="Create" CssClass="btn btn-outline-primary m-2" ID="btnInsertOutdoor" OnClick="btnInsertOutdoor_Click" ValidationGroup="presOutValidation" />
                <asp:Button runat="server" Text="Modify" CssClass="btn btn-outline-primary m-2" ID="btnModifyOutdoor" OnClick="btnModifyOutdoor_Click" ValidationGroup="presOutValidation" />
                <asp:Button runat="server" Text="Clear" CssClass="btn btn-outline-primary m-2" ID="btnClearOutdoor" OnClick="btnClearOutdoor_Click" />
            </div>
        </div>
        <h5 class="font-weight-bold">Add/Edit Drug:</h5>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" ID="txtOutPresId" CssClass="d-none"></asp:Label>
                <label class="font-weight-bold">Drug:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutDrug" ValidationGroup="OutDrugValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutDrug" runat="server" ErrorMessage="Drug is required"
                    ControlToValidate="txtOutDrug" CssClass="text-danger float-right" ValidationGroup="OutDrugValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Drug Dose:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutDrugDose" ValidationGroup="OutDrugValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutDrugDose" runat="server" ErrorMessage="Drug Dose is required"
                    ControlToValidate="txtOutDrugDose" CssClass="text-danger float-right" ValidationGroup="OutDrugValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Dose Status:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutDoseStatus" ValidationGroup="OutDrugValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutDoseStatus" runat="server" ErrorMessage="Drug Dose status is required"
                    ControlToValidate="txtOutDoseStatus" CssClass="text-danger float-right" ValidationGroup="OutDrugValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <label class="font-weight-bold">First Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutFTime" ValidationGroup="OutDrugValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutFTime" runat="server" ErrorMessage="First time use is required"
                    ControlToValidate="txtOutFTime" CssClass="text-danger float-right" ValidationGroup="OutDrugValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Last Time:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutLTime" ValidationGroup="OutDrugValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutLTime" runat="server" ErrorMessage="Last time use is required"
                    ControlToValidate="txtOutLTime" CssClass="text-danger float-right" ValidationGroup="OutDrugValidation"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-4">
                <label class="font-weight-bold">Times Per Day:</label>
                <asp:TextBox runat="server" CssClass="float-right" ID="txtOutTimesPerDay" ValidationGroup="OutDrugValidation"></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="rfvOutTimesPerDay" runat="server" ErrorMessage="Times per day is required"
                    ControlToValidate="txtOutTimesPerDay" CssClass="text-danger float-right" ValidationGroup="OutDrugValidation"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row">
            <div class="mx-auto">
                <asp:Button runat="server" Text="Add" CssClass="btn btn-outline-primary m-2" ID="btnAddOutPresDetails"
                    OnClick="btnAddOutPresDetails_Click" ValidationGroup="OutDrugValidation" />
            </div>
        </div>
    </div>
    <%-- End of Outdoor Prescription --%>
</asp:Content>
