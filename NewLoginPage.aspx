<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewLoginPage.aspx.cs" Inherits="NewLoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <link rel="stylesheet" href="login.css" />
    <div>
        <a href="#" class="h5"><b>RMS | </b>Record Management System</a>
    </div>

<div class="login">
  <h2 class="active"> sign in </h2>
   
    <asp:TextBox runat="server" ID="txtusername" CssClass="text"></asp:TextBox>
     <span>Username</span>

    <br>
    
    <br>

    <asp:TextBox runat="server" ID="txtpassword" CssClass="text" TextMode="Password"></asp:TextBox>
    <span>password</span>
    <br>

    
    
   <asp:Button runat="server" ID="btnsignin" Text="Sign In" CssClass="signin" OnClick="btnsignin_Click" />
   


    <hr>

    <asp:LinkButton runat="server" ID="txtclick" Text="Click Here To Register" OnClick="txtclick_Click"></asp:LinkButton>
  

</div>
    </div>
    </form>
</body>
</html>
