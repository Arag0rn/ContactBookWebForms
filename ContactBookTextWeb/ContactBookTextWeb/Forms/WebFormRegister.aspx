<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormRegister.aspx.cs" Inherits="ContactBookTextWeb.Forms.WebFormRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="../Styles/Register.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtnRegister">
        <div class="regFields">    
            <div>
                <p class="labels">First name</p>           
                <asp:TextBox ID="TbFirstName" runat="server" Width="315px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>
            </div>               
            <div>
                <p class="labels">Last name</p>                
                <asp:TextBox ID="TbLastName" runat="server" Width="315px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>
            </div>            
            <div>
                <p class="labels">Username</p>                    
                <asp:TextBox ID="TbUsername" runat="server" Width="315px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>
            </div>                        
            <div>
                <p class="labels">Password</p>              
                <asp:TextBox ID="TbPassword" type="password" runat="server" Width="315px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>              
            </div>                
            <div>
                <p class="labels">Confiirm passowrd</p>                
                <asp:TextBox ID="TbConfirmPassword" type="password" runat="server" Width="315px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>
            </div>
            <div class="buttons">
                <asp:Button ID="BtnRegister" runat="server" Text="Register" Width="180px" OnClick="BtnRegister_Click" BackColor="#3399FF" BorderStyle="None" ForeColor="White" Height="26px" />   
                &nbsp;&nbsp;&nbsp;   
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" Width="180px" OnClick="BtnCancel_Click" BackColor="#99CCFF" BorderStyle="None" ForeColor="White" Height="26px" />
            </div>
            <p id="existingUser">Already registered? Login <a id="link" href="WebFormLogin.aspx">here</a></p>             
        </div>
    </form>
</body>
</html>
