<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAddNewContact.aspx.cs" Inherits="ContactBookTextWeb.Forms.WebFormAddNewContact" %>
<%@ Import Namespace="DataAccess.Service" %>
<%@ Import Namespace="ContactBookTextWeb.Forms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script lang="C#" runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.LoggedUser.Id == 1)
            {
                this.BtnAdministration.Visible = true;
            }

            this.TbFullName.Focus();
        }
    </script>
<head runat="server">
    <title>New contact</title>
    <link href="../Styles/AddNewContact.css" rel="stylesheet" />    
</head>
<body style="height: 255px">
    <form id="form1" runat="server" defaultbutton="BtnAdd">        
        <div class="header">
            <div class="account">                
                <asp:Button ID="BtnAccount" CssClass="buttons" runat="server" Text="My account" BackColor="#009933" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnAccount_Click"/>
                <asp:Button ID="BtnContacts" CssClass="buttons" runat="server" Text="My contacts" BackColor="Blue" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnContacts_Click"/>
                <asp:Button ID="BtnExit" runat="server" Text="Exit" BackColor="Red" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnExit_Click"/>
                <asp:Button ID="BtnAdministration" runat="server" Text="All users" BackColor="#666666" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnAdministration_Click" Visible="False"/>
            </div>
        </div>
        <div class="contactFields">            
            <div>
                <p class="labels">Full name</p>                
                <asp:TextBox ID="TbFullName" runat="server" Width="388px" BorderStyle="Solid" BorderWidth="1px" MaxLength="50"></asp:TextBox>
            </div>   
            <div>
                <p class="labels">Email</p>
                <asp:TextBox ID="TbEmail" runat="server" Width="388px" BorderStyle="Solid" BorderWidth="1px" MaxLength="40"></asp:TextBox>
            </div>                               
            <div>
                <p class="labels">Address</p>               
                <asp:TextBox ID="TbAddress" runat="server" Width="388px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>
            </div>
            <div>
                <p class="labels">Company</p>    
                <asp:TextBox ID="TbCompany" runat="server" Width="388px" BorderStyle="Solid" BorderWidth="1px" MaxLength="20"></asp:TextBox>              
            </div>
            <div class="operation">
                <asp:Button ID="BtnAdd" CssClass="buttons" runat="server" OnClick="BtnAdd_Click" Text="Add contact" Width="180px" BackColor="#3399FF" BorderStyle="None" ForeColor="White" Height="26px" />                                                                            
                <asp:Button ID="BtnCancel"  runat="server" OnClick="BtnCancel_Click" Text="Cancel" Width="180px" BackColor="#99CCFF" BorderStyle="None" ForeColor="White" Height="26px" />                
            </div>            
        </div>
    </form>
</body>
</html>
