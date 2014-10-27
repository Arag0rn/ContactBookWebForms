using System;
using DataAccess.Service;

namespace ContactBookTextWeb
{
    public partial class WebFormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TbUsername.Focus();   
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = this.TbUsername.Text;
            string password = this.TbPassword.Text;
            AuthenticationService.AuthenticateUser(username, password);
            if (AuthenticationService.LoggedUser != null)
            {
                Response.Redirect("WebFormManager.aspx", true);
            }           
            
            if (this.TbUsername.Text == String.Empty ||
                this.TbPassword.Text == String.Empty)
            {
                Response.Write("<script>alert('All fields required')</script>");
                return;
            }
            else
            {                                
                Response.Write("<script>alert('Invalid username or password')</script>");
                return;
            }            
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.TbUsername.Text = String.Empty;
            this.TbPassword.Text = String.Empty;
        }
    }
}