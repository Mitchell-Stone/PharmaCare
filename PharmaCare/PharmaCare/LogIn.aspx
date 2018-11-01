<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="PharmaCare.WebForm5" %>

<asp:Content ID="LogInContent" ContentPlaceHolderID="mainPlaceHolder" runat="server">
    <h1>THIS IS THE LOG IN PAGE</h1>
    <div class="row">
        <div class="col-sm-12">
            <div class="form-group">
                <label class="col-sm-1">Username:</label>
                <div class="col-sm-3">
                    <asp:textbox id="txtUsername" runat="server"
                        cssclass="form-control"></asp:textbox>
                </div>
                <label class="col-sm-1">Password:</label>
                <div class="col-sm-3">
                    <asp:textbox id="txtPassword" runat="server"
                        cssclass="form-control"></asp:textbox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <asp:button id="btnLogin" runat="server" text="Login"
                        onclick="btnLogin_Click" cssclass="btn" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
