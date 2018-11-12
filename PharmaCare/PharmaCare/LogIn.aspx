<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="PharmaCare.WebForm5" %>

    
<asp:Content ID="LogInContent" ContentPlaceHolderID="mainPlaceHolder" runat="server">

    <div class="row">
            
        <div class="col-sm-12">
            <div class="box">
                <h3 class="page"> LOGIN PAGE</h3>
            <div class="form-group">
                <label class="col-sm-1">Username:</label>
                <div class="col-sm-3">
                   <asp:textbox id="txtUsername" runat="server" 
                    cssclass="form-control" placeholder="Email"></asp:textbox>     
                </div>
                <div class="col-sm-6">
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" 
                ErrorMessage="Username Required" ControlToValidate="txtUsername" 
                CssClass="text-danger" Display="Dynamic" OnDataBinding="Page_Load">Username Required</asp:RequiredFieldValidator>
                   </div>
                <label class="col-sm-1">Password:</label>
                <div class="col-sm-5">
                    <asp:textbox id="txtPassword" runat="server"
                        cssclass="form-control" placeholder="Password" type="password"></asp:textbox>
                </div>
                <div class="col-sm-6">
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                ErrorMessage="Email address" ControlToValidate="txtPassword" 
                CssClass="text-danger" Display="Dynamic">Password Required</asp:RequiredFieldValidator>
        </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <asp:button id="btnLogin" runat="server" text="Login"
                        onclick="btnLogin_Click" cssclass="btn" />
                    <asp:Button class="btnsignup" runat="server" Text="SignUp" ID="btn_Signup" OnClick="btn_SignUp" CausesValidation="false" />
                </div>
            </div>
                
        </div>
            </div>
    </div>
</asp:Content>
