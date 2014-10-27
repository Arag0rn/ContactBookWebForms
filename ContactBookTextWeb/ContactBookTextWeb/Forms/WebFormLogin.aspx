<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLogin.aspx.cs" Inherits="ContactBookTextWeb.WebFormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Styles/Login.css" rel="stylesheet" />
    </head>
<body>
    <form id="form1" runat="server" defaultbutton="BtnLogin">
        <div class="loginFields">      
            <div class="labels">           
                <asp:Label ID="LabelUsername" runat="server" Text="Username" Font-Names="Arial" ForeColor="White"></asp:Label> 
            </div>
            <div class="textBoxes">     
                <asp:TextBox ID="TbUsername" runat="server" Width="327px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>
            </div>            
            <div class="labels">
                <asp:Label ID="LabelPassword" runat="server" Text="Password" Font-Names="Arial" ForeColor="White"></asp:Label>
            </div>
            <div class="textBoxes">
                <asp:TextBox ID="TbPassword" type="password" runat="server" Width="327px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>        
            </div>
        </div>
        <div class="buttons">
            <asp:Button ID="BtnLogin" runat="server" Text="Login" Width="180px" OnClick="BtnLogin_Click" BackColor="#3399FF" BorderStyle="None" ForeColor="White" Height="26px" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="BtnCancel" runat="server" Text="Cancel" Width="180px" OnClick="BtnCancel_Click" BackColor="#99CCFF" BorderStyle="None" ForeColor="White" Height="26px" />                       
        </div>
        <p id="newUser">Not registered? Register <a id="link" href="WebFormRegister.aspx">here</a></p>
    </form>
</body>
</html>
