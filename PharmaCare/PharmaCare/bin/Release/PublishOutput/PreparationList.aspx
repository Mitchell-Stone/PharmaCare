﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreparationList.aspx.cs" Inherits="PharmaCare.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="mainPlaceholder" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label runat="server" ID="table_header" AutoPostBack="true" CssClass="h1"
                Text="Displaying Non-Verified Prescriptions"></asp:Label>
        </div>
        <div class="row">
            <p>This page is to assist with the preperation of patient prescriptions.
                Use the buttons below to toggle between all prescription status types</p>
        </div>
        <div class="row">
            <div class="col-6">
                <div class="row">                    
                    <div class="col-6">
                        <asp:Button runat="server" Text="Show Active" 
                            CssClass="btn btn-outline-primary m-2 btn-block" ID="btnActivePres" OnClick="btnActivePres_Click"/>
                        <asp:Button runat="server" Text="Show Non-Verified" 
                            CssClass="btn btn-outline-primary m-2 btn-block" ID="btnNonVerifiedPres" OnClick="btnNonVerifiedPres_Click"/>                
                        <asp:Button runat="server" Text="Show Cancelled" 
                            CssClass="btn btn-outline-primary m-2 btn-block" ID="btnCancelledPres" OnClick="btnCancelledPres_Click"/> 
                    </div>  
                    <div class="col-6">
                        <asp:Button runat="server" Text="Show On Hold" 
                            CssClass="btn btn-outline-primary m-2 btn-block" ID="btnOnHoldPres" OnClick="btnOnHoldPres_Click"/>
                        <asp:Button runat="server" Text="Show Expired" 
                            CssClass="btn btn-outline-primary m-2 btn-block" ID="btnExpiredPres" OnClick="btnExpiredPres_Click"/>
                        <asp:Button runat="server" Text="Show Cocktail" 
                            CssClass="btn btn-outline-primary m-2 btn-block" ID="btnCocktailPres" OnClick="btnCocktailPres_Click"/>
                    </div>                   
                    <asp:Button runat="server" Text="Show All"
                        CssClass="btn btn-outline-primary m-2 btn-block" ID="btnShowAll" OnClick="btnShowAll_Click"/>
                </div>
            </div>
            <div class="col-6">
                <div class="container">
                    <div class="row">
                        <p>Search by Prescription ID:</p>
                        <asp:TextBox runat="server" ID="tbPrescriptionIdSearch"></asp:TextBox>
                        <asp:Button runat="server" Text="Search for Prescription" 
                        CssClass="btn btn-outline-primary m-2" ID="btnSearchForPrescription" OnClick="btnSearchForPrescription_Click"/>
                    </div>
                    <div class="row">
                        <asp:Label runat="server" ID="txtWarning" CssClass="text-danger"></asp:Label>
                        <asp:CompareValidator runat="server" ID="vvPrescriptionId" Type="Integer" ControlToValidate="tbPrescriptionIdSearch"
                        ErrorMessage="A valid prescription ID must be entered" Operator="DataTypeCheck" CssClass="text-danger"></asp:CompareValidator>  
                    </div>                    
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:GridView ID="gvPrepList" runat="server" AutoPostBack="True" 
            AutoGenerateColumns="false" CssClass="table table-hover table-bordered">
            <Columns>
                <asp:BoundField DataField="DrugName" HeaderText="Drug Name"
                    SortExpression="DrugName"></asp:BoundField>
                <asp:BoundField DataField="DrugForm" HeaderText="Drug Form"
                    SortExpression="DrugForm"></asp:BoundField>
                <asp:BoundField DataField="DrugDose" HeaderText="Drug Dose (mg)"
                    SortExpression="DrugDose"></asp:BoundField>
                <asp:BoundField DataField="TimesPerDay" HeaderText="Times Per Day"
                    SortExpression="TimesPerDay"></asp:BoundField>
                <asp:BoundField DataField="PrescriptionStatus" HeaderText="Status"
                    SortExpression="PrescriptionStatus"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvGroupPrepList" runat="server" AutoPostBack="True" 
            AutoGenerateColumns="false" CssClass="table table-hover table-bordered"
            OnRowCommand="gvGroupPrepList_RowCommand">
            <Columns>           
                <asp:BoundField DataField="PrescriptionId" HeaderText="Prescription ID"
                    SortExpression="PrescriptionId"></asp:BoundField>
                <asp:BoundField DataField="PrescriptionDate" HeaderText="Prescription Date"
                    SortExpression="PrescriptionDate"></asp:BoundField>
                <asp:BoundField DataField="PrescriptionCount" HeaderText="Drug Count"
                    SortExpression="PrescriptionCount"></asp:BoundField>
                <asp:TemplateField HeaderText="Prescription Functions">
                    <ItemTemplate>  
                        <asp:Button runat="server" Text="View Prescription" CommandName="ViewPrescription" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            CssClass="btn btn-outline-primary m-2 btn-md btn-block" ID="btnViewPrescription"
                            AutoPostBack="false"/> 
                        <asp:DropDownList runat="server" ID="ddlStatusTypes" AutoPostBack="false" 
                            CssClass="form-control"></asp:DropDownList>
                        <asp:Button runat="server" Text="Apply Status" CommandName="SetPrescriptionStatus" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            CssClass="btn btn-outline-primary m-2 btn-md btn-block" ID="btnSetStatus"
                            AutoPostBack="false"/>                                     
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:Label runat="server" ID="test"></asp:Label>
</asp:Content>


