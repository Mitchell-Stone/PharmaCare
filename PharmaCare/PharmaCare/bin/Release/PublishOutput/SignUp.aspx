<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="PharmaCare.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <link href="Content/site.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="content/stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       
        <div class="signupform">
            
             <div class="content-wrappertwo">  
                  <h2 class="heading">SignUp Form</h2>
                <div class="contents">
                <div class="label-textstwo">First Name
                    </div>
                <input class="Text" id="inputsm" type="text" />
                </div>

                 <div class="contents">
                <div class="label-textstwo">Last Name
                    </div>
                <input class="Text" type="text" />
                </div>
            
                <div class="contents">
                <div class="label-textstwo">UserName</div>
                <input class="Text" type="text" />
                </div>

                <div class="contents">
                <div class="label-textstwo">SecurityLevel</div>
                 <input class="Text" type="text" />
                </div>

                <div class="contents">
                <div class="label-textstwo">Password</div>
                <input class="Text" type="password" />
                </div>
                  
                 
                  
                    <asp:Button class="back" runat="server" Text="Back" ID="btn_Back" OnClick="btn_back" />

                   
                    <asp:Button class="submit" runat="server" Text="Submit" ID="btn_Submit" OnClick="btn_submit" />

                 
                </div>

            

         
        </div>   
    </form>
</body>
</html>

