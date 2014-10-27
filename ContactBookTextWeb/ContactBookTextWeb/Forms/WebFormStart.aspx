<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormStart.aspx.cs" Inherits="ContactBookTextWeb.Forms.WebFormStart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>
    <link rel="stylesheet" type="text/css" href="../Styles/Start.css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtnLogin">
        <div>           
            <p id="message">Welcome to your contact book<br />
                Login to manage your contacts 
            </p>
        </div>
        <div style="text-align:center">
            <br />
            <asp:Button ID="BtnLogin" runat="server" Text="Login" BackColor="#3399FF" BorderStyle="None" BorderWidth="0px" Font-Size="18px" ForeColor="White" Height="45px" Width="219px" OnClick="BtnLogin_Click" />
        </div>
        <div>
            <p id="newUser">Not registered? Register <a id="link" href="WebFormRegister.aspx">here</a></p>
        </div>
    </form>
</body>
</html>
