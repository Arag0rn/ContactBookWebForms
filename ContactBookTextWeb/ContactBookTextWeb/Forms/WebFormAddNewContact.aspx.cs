using System;
using System.Configuration;
using DataAccess.Entity;
using DataAccess.Repository;
using DataAccess.Service;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormAddNewContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {                                            
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

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.ParentUserId = AuthenticationService.LoggedUser.Id;
            ContactsRepository contactsRepository = RepositoryFactory.GetContactsRepository();
            if (this.TbFullName.Text == String.Empty)
            {
                Response.Write("<script>window.alert('Name field must not be empty')</script>");
                return;
            }                    
            else
            {
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