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
                <input id="Text" type="text" />
                </div>

                 <div class="contents">
                <div class="label-textstwo">Last Name
                    </div>
                <input id="Text1" type="text" />
                </div>
            
                <div class="contents">
                <div class="label-textstwo">Email</div>
                <input id="Text2" type="text" />
                </div>

                <div class="contents">
                <div class="label-textstwo">Job</div>
                 <input id="Text3" type="text" />
                </div>

                <div class="contents">
                <div class="label-textstwo">Password</div>
                <input id="Password2" type="password" />
                </div>
                 
                    <button class="back">Back</button>

                   <button class="submit">Submit</button>


                </div>

         
        </div>   
    </form>
</body>
</html>

