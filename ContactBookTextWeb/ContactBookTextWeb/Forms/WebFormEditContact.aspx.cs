using System;
using DataAccess.Entity;
using DataAccess.Repository;
using DataAccess.Service;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormEditContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.LoggedUser.Id == 1)
            {
                this.BtnAdministration.Visible = true;
            }

            if (!this.Page.IsPostBack)
            {
                this.TbFullName.Focus();
                this.TbFullName.Text = WebFormManager.contactName;
                this.TbEmail.Text = WebFormManager.contactEmail;
                this.TbAddress.Text = WebFormManager.contactAddress;
                this.TbCompany.Text = WebFormManager.contactCompany;
            }
        }

        protected void BtnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormUserAccount.aspx", true);
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

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.TbFullName.Text == String.Empty)
            {
                Response.Write("<script>window.alert('Name field must not be empty')</script>");
                return;
            }
            else
            {
                ContactsRepository contactsRepository = RepositoryFactory.GetContactsRepository();
                Contact contact = new Contact();
                contact.Id = WebFormManager.contactId;
                contact.ParentUserId = AuthenticationService.LoggedUser.Id;
                contact.FullName = this.TbFullName.Text;
                contact.Email = this.TbEmail.Text;
                contact.Address = this.TbAddress.Text;
                contact.Company = this.TbCompany.Text;

                contactsRepository.Save(contact);
                
                Response.Redirect("WebFormManager.aspx", true);
            }            
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormManager.aspx", true);
        }       
    }
}