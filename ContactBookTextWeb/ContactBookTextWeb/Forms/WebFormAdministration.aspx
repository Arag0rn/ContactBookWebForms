<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAdministration.aspx.cs" Inherits="ContactBookTextWeb.Forms.WebFormAdministration" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="DataAccess.Entity" %>
<%@ Import Namespace="DataAccess.Service" %>
<%@ Import Namespace="DataAccess.Repository" %>
<%@ Import Namespace="ContactBookTextWeb.Forms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script lang="C#" runat="server">
        ICollection ItemsSource()
        {
            UsersRepository usersRepository = RepositoryFactory.GetUsersRepository();
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new DataColumn("AdminPrivilegeIndex", typeof(short)));
            dt.Columns.Add(new DataColumn("Username", typeof(string)));
            dt.Columns.Add(new DataColumn("Password", typeof(string)));
            dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dt.Columns.Add(new DataColumn("LastName", typeof(string)));
                
            foreach (User user in usersRepository.GetAll())
            {
                dr = dt.NewRow();
                dr[0] = user.Id;
                dr[1] = user.AdminPrivilegeIndex;
                dr[2] = user.Username;
                dr[3] = user.Password;
                dr[4] = user.FirstName;
                dr[5] = user.LastName;

                dt.Rows.Add(dr);
            }

            DataView dv = new DataView(dt);
            return dv;
        }
        
        void Page_Load(Object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DgItems.DataSource = ItemsSource();
                DgItems.DataBind();   
            }

            if (AuthenticationService.LoggedUser.Id != 1)
            {
                Response.Redirect("WebFormManager.aspx", true);                    
            }
        }
    </script>
<head runat="server">
    <title>Administration</title>
    <link href="../Styles/Administration.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="">                       
        <div class="header">
            <div class="account">                
                <asp:Button ID="BtnAccount" CssClass="buttons" runat="server" Text="My account" BackColor="#009933" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnAccount_Click"/>
                <asp:Button ID="BtnContacts" CssClass="buttons" runat="server" Text="My contacts" BackColor="Blue" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" Height="22px" OnClick="BtnContacts_Click"/>
                <asp:Button ID="BtnExit" runat="server" Text="Exit" BackColor="Red" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnExit_Click"/>                
            </div>
        </div>                             
        <table align="center">
            <tr>
                <td>
                    <asp:DataGrid ID="DgItems" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="AdminPrivilege" DataField="AdminPrivilegeIndex" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Username" DataField="Username">
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Password" DataField="Password">
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="First name" DataField="FirstName">
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Last name" DataField="LastName">
                                    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                                </asp:BoundColumn>
                            </Columns>
                            <AlternatingItemStyle BackColor="White" />
                            <EditItemStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <ItemStyle BackColor="#EFF3FB" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        </asp:DataGrid>
                </td>
            </tr>
        </table>              
    </form>
</body>
</html>
