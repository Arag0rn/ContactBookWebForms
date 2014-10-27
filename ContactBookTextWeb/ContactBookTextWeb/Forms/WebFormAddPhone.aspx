<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAddPhone.aspx.cs" Inherits="ContactBookTextWeb.Forms.WebFormAddPhone" %>
<%@ Import Namespace="DataAccess.Service" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <script lang="C#" runat="server">
        void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.LoggedUser.Id == 1)
            {
                this.BtnAdministration.Visible = true;
            } 
        }
    </script>
<head runat="server">
    <link href="../Styles/AddPhone.css" rel="stylesheet" />
    <title>Add phone</title>
</head>
<body>
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
                <p class="labels">Phone number</p>            
                <asp:TextBox ID="TbPhone" runat="server" BorderStyle="Solid" BorderWidth="1px" MaxLength="9" Width="180px"></asp:TextBox>  
            </div>
            <div class="operation">                      
                <asp:Button ID="BtnAdd" CssClass="buttons" runat="server" Text="Add phone" Width="180px" OnClick="BtnAdd_Click" BackColor="#3399FF" BorderStyle="None" ForeColor="White" Height="26px" />                
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" Width="180px" OnClick="BtnCancel_Click" BackColor="#99CCFF" BorderStyle="None" ForeColor="White" Height="26px" />                
            </div> 
        </div>          
    </form>
</body>
</html>
