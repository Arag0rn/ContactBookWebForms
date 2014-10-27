<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormManager.aspx.cs" Inherits="ContactBookTextWeb.Forms.WebFormManager" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="DataAccess.Repository" %>
<%@ Import Namespace="DataAccess.Service" %>
<%@ Import Namespace="DataAccess.Entity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <script lang="C#" runat="server">
        ICollection ItemsSource()
        {
            ContactsRepository contactsRepository = RepositoryFactory.GetContactsRepository();
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new DataColumn("ParentUserId", typeof(Int32)));
            dt.Columns.Add(new DataColumn("FullName", typeof(string)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("Address", typeof(string)));
            dt.Columns.Add(new DataColumn("Company", typeof(string)));

            foreach (Contact contact in contactsRepository.GetAll(AuthenticationService.LoggedUser.Id))
            {
                dr = dt.NewRow();
                dr[0] = contact.Id;
                dr[1] = contact.ParentUserId;
                dr[2] = contact.FullName;
                dr[3] = contact.Email;
                dr[4] = contact.Address;
                dr[5] = contact.Company;

                dt.Rows.Add(dr);
            }

            DataView dv = new DataView(dt);
            return dv;
        }
        
        ICollection SubItemsSource()
        {
            PhonesRepository phonesRepository = RepositoryFactory.GetPhonesRepository();
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add(new DataColumn("Id", typeof(Int32)));
            dt.Columns.Add(new DataColumn("ParentContactId", typeof(Int32)));
            dt.Columns.Add(new DataColumn("PhoneNumber", typeof(string)));

            int parentContactId = Convert.ToInt32(this.DgItems.SelectedItem.Cells[1].Text);
            foreach (Phone phone in phonesRepository.GetAll(parentContactId))
            {
                dr = dt.NewRow();
                dr[0] = phone.Id;
                dr[1] = phone.ParentContactId;
                dr[2] = phone.PhoneNumber;

                dt.Rows.Add(dr);
            }

            DataView dv = new DataView(dt);
            return dv;
        }
        
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DgItems.DataSource = ItemsSource();
                DgItems.DataBind();
            }
            
            if (AuthenticationService.LoggedUser.Id == 1)
            {
                this.BtnAdministration.Visible = true;
            }            
        }

        void DgItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            DgSubItems.DataSource = SubItemsSource();
            DgSubItems.DataBind();
        }        
    </script>
<head runat="server">
    <title>Contact manager</title>
    <link href="../Styles/Manager.css" rel="stylesheet" />
    <style type="text/css">
        .items {}
        .auto-style1 {
            width: 142px;
        }
        .auto-style2 {
            right: 0px;
            width: 142px;
        }
        .auto-style3 {
            height: 32px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server" defaultbutton="">
    <div class="header">
            <div class="account">                
                <asp:Button ID="BtnAccount" CssClass="buttons" runat="server" Text="My account" BackColor="#009933" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnAccount_Click"/>               
                <asp:Button ID="BtnExit" runat="server" Text="Exit" BackColor="Red" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnExit_Click"/>
                <asp:Button ID="BtnAdministration" runat="server" Text="All users" BackColor="#666666" BorderStyle="None" Font-Bold="True" Font-Names="Arial" Font-Underline="False" ForeColor="White" Width="100px" OnClick="BtnAdministration_Click" Visible="False"/>
            </div>
        </div>
    <div style="height: 583px">
        <br />
        <h2>Contact manager</h2>
        <table id="itemsManager" style="clip: rect(auto, auto, auto, auto); top: 100px; position: fixed;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LblContactManager" runat="server" Font-Names="Arial" Font-Size="11pt" ForeColor="White" Text="Contact manager" Width="115px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1"></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="BtnNew" runat="server" OnClick="BtnNew_Click" Text="New contact" Width="115px" BackColor="#3399FF" BorderStyle="None" ForeColor="White" Height="26px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="BtnEdit" runat="server" OnClick="BtnEdit_Click" Text="Edit contact" Width="115px" BackColor="#539358" BorderStyle="None" ForeColor="White" Height="26px" ViewStateMode="Disabled" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td style="clip: rect(auto, 10%, auto, auto);" class="auto-style2">
                    <asp:Button ID="BtnDelete" runat="server" OnClick="BtnDelete_Click" Text="Delete contact" Width="115px" BackColor="Red" BorderStyle="None" ForeColor="White" Height="26px" ViewStateMode="Disabled" />
                </td>
            </tr>
        </table>
        <table id="subItemsManager" style="clip: rect(auto, auto, auto, auto); top: 100px; left: 89%; position: fixed; right: 3%;">
            <tr>
                <td style="right: 10%; top: 150%; left: 70%;">
                    <asp:Label ID="LblPhoneManager" runat="server" Font-Names="Arial" Font-Size="11pt" ForeColor="White" Text="Phone manager"
                            Width="115px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td style="right: 10%; top: 150%; left: 70%;">
                    <asp:Button ID="BtnNewPhone" runat="server" OnClick="BtnNewPhone_Click" Text="New phone" Width="115px" BackColor="#66CCFF" BorderStyle="None" ForeColor="White" Height="26px" ViewStateMode="Disabled" />
                </td>
            </tr>
            <tr>
                <td style="right: 10%; top: 150%; left: 70%;">&nbsp;</td>
            </tr>
            <tr>
                <td style="right: 10%; top: 150%; left: 70%;">
                    <asp:Button ID="BtnEditPhone" runat="server" OnClick="BtnEditPhone_Click" Text="Edit phone" Width="115px" BackColor="#00CC99" BorderStyle="None" ForeColor="White" Height="26px" ViewStateMode="Disabled" />
                </td>
            </tr>
            <tr>
                <td style="right: 10%; top: 150%; left: 70%;">&nbsp;</td>
            </tr>
            <tr>
                <td style="right: 10%; top: 150%; left: 70%;">
                    <asp:Button ID="BtnDeletePhone" runat="server" OnClick="BtnDeletePhone_Click" Text="Delete phone" Width="115px" BackColor="#FF5050" BorderStyle="None" ForeColor="White" Height="26px" ViewStateMode="Disabled" />
                </td>
            </tr>
        </table>
        <table id="tableItems" style="clip: rect(auto, auto, auto, auto); top: 100px; left: 13%; position: absolute; right: 18%;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="LblItems" runat="server" Font-Names="Arial" Font-Size="11pt" ForeColor="White" Text="Contacts" BackColor="#3399FF" Width="585px" Height="19px" style="text-align:center; padding-top: 1%; padding-bottom: 1%;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="DgItems" runat="server" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" CssClass="items" OnSelectedIndexChanged="DgItems_SelectedIndexChanged" Width="584px" DataKeyField="Id">
                        <Columns>
                            <asp:ButtonColumn HeaderText="Select contact" CommandName="Select" Text="Select">
                                <HeaderStyle BackColor="#9999FF" Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                            </asp:ButtonColumn>
                            <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="ParentUserId" DataField="ParentUserId" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Name" DataField="FullName">
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Email" DataField="Email">
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Address" DataField="Address">
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Company" DataField="Company">
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="100px" />
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
        <table id="tableSubItems" style="clip: rect(auto, auto, auto, auto); top: 100px; position: fixed; right: 13%;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="LblSubItems" runat="server" Font-Names="Arial" Font-Size="11pt" ForeColor="White" Text="Phones" BackColor="#3399FF" Width="258px" Height="19px" style="text-align:center; padding-top: 1%; padding-bottom: 1%;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="DgSubItems" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" Width="258px" style="margin-right: 0px">
                        <HeaderStyle BackColor="#9999FF" Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="100px" />
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                        <AlternatingItemStyle BackColor="White" />
                        <Columns>
                            <asp:ButtonColumn CommandName="Select" HeaderText="Select phone" Text="Select"></asp:ButtonColumn>
                            <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="ParentContactId" DataField="ParentContactId" Visible="false"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Phone" DataField="PhoneNumber">
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="11pt" Font-Strikeout="False" Font-Underline="False" Width="130px" />
                                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Arial" Font-Overline="False" Font-Size="Small" Font-Strikeout="False" Font-Underline="False" />
                            </asp:BoundColumn>
                        </Columns>
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
    </div>
    </form>
</body>
</html>
