<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUserAccount.aspx.cs" Inherits="ContactBookTextWeb.Forms.WebFormUserAccount" %>
<%@ Import Namespace="DataAccess.Service" %>
<%@ Import Namespace="ContactBookTextWeb.Forms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">    
<head runat="server">
    <title>My account</title>
    <link href="../Styles/Account.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="BtnSave">
       <div class="header">
            <div class="account">                                
                <asp:Button ID="BtnContacts" CssClass="buttons" runat="server" Text="My contacts" BackColor="Blue" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnContacts_Click"/>
                <asp:Button ID="BtnExit" runat="server" Text="Exit" BackColor="Red" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnExit_Click"/>
                <asp:Button ID="BtnAdministration" runat="server" Text="All users" BackColor="#666666" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnAdministration_Click" Visible="False"/>
            </div>
        </div>
        <div class="fields">
            <p class="labels">First name</p>
            <asp:TextBox ID="TbFirstName" runat="server" Width="388px" MaxLength="20"></asp:TextBox>
        </div>
        <div class="fields">
            <p class="labels">Last name</p>
            <asp:TextBox ID="TbLastName" runat="server" Width="388px" MaxLength="20"></asp:TextBox>
        </div>        
        <div class="fields">
            <p class="labels">Password</p>
            <asp:TextBox ID="TbPassword" runat="server" type="password" Width="388px" MaxLength="20"></asp:TextBox>
        </div>
        <div class="fields">
            <p class="labels">Confirm password</p>
            <asp:TextBox ID="TbConfirmPassword" runat="server" type="password" Width="388px" MaxLength="20"></asp:TextBox>
        </div>
        <div class="operation">
            <asp:Button ID="BtnSave" CssClass="buttons" runat="server" OnClick="BtnSave_Click" Text="Save changes" Width="180px" BackColor="#3399FF" BorderStyle="None" ForeColor="White" Height="26px" />                                                                            
            <asp:Button ID="BtnCancel" runat="server" OnClick="BtnCancel_Click" Text="Cancel" Width="180px" BackColor="#99CCFF" BorderStyle="None" ForeColor="White" Height="26px" />  
        </div>          
    </form>
</body>
</html>
