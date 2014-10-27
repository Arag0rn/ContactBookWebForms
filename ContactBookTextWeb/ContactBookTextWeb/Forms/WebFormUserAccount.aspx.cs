using System;
using DataAccess.Entity;
using DataAccess.Repository;
using DataAccess.Service;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.LoggedUser.Id == 1)
            {
                this.BtnAdministration.Visible = true;
            }

            if (!this.Page.IsPostBack)
            {
                this.TbFirstName.Text = AuthenticationService.LoggedUser.FirstName.ToString();
                this.TbLastName.Text = AuthenticationService.LoggedUser.LastName.ToString();
                this.TbPassword.Text = AuthenticationService.LoggedUser.Password.ToString();
                this.TbConfirmPassword.Text = AuthenticationService.LoggedUser.Password.ToString();      
            }            
        }

        protected void BtnContacts_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormManager.aspx", true);
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormLogin.aspx", true);
        }

        protected void BtnAdministration_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAdministration.aspx", true);
        } 

        protected void BtnSave_Click(object sender, EventArgs e)
        {                       
            if (this.TbFirstName.Text == String.Empty ||
                this.TbLastName.Text == String.Empty ||
                this.TbPassword.Text == String.Empty ||
                this.TbConfirmPassword.Text == String.Empty)
            {
                Response.Write("<script>window.alert('All fields required')</script>");
                return;
            }
            else if (this.TbConfirmPassword.Text != this.TbPassword.Text)                
            {
                this.TbPassword.Text = String.Empty;
                this.TbConfirmPassword.Text = String.Empty;
                Response.Write("<script>window.alert(\"Password don't match\")</script>");
                return;
            }
            else
            {
                UsersRepository usersRepository = RepositoryFactory.GetUsersRepository();
                User user = usersRepository.GetById(AuthenticationService.LoggedUser.Id);                
                if (AuthenticationService.LoggedUser.AdminPrivilegeIndex == 1)
                {
                    user.AdminPrivilegeIndex = 1;
                }
                else
                {
                    user.AdminPrivilegeIndex = 0;
                }                
                user.FirstName = this.TbFirstName.Text;
                user.LastName = this.TbLastName.Text;                
                user.Password = this.TbPassword.Text;

                usersRepository.Update(user);                
                Response.Redirect("WebFormLogin.aspx", true);
            }  
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormManager.aspx", true);
        }           
    }
}