using System;
using System.Collections.Generic;
using DataAccess.Service;
using DataAccess.Entity;
using DataAccess.Repository;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormManager : System.Web.UI.Page
    {
        public static int contactId;
        public static string contactName;
        public static string contactEmail;
        public static string contactAddress;
        public static string contactCompany;

        public static int phoneId;
        public static int parentContactId;
        public static string phoneNumber;
        
        protected void Page_Load(object sender, EventArgs e)
        {                     
        }

        protected void BtnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormUserAccount.aspx", true);
        }

        protected void BtnExit_Click(object sender, EventArgs e)
        {           
            Response.Redirect("WebFormLogin.aspx", true);
        }

        protected void BtnAdministration_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAdministration.aspx", true);
        }                        

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormAddNewContact.aspx", true);
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.DgItems.Items.Count == 0)
            {
                Response.Write("<script>window.alert('No contacts to edit')</script>");
            }
            else if(this.DgItems.SelectedIndex < 0 || this.DgItems.SelectedIndex > this.DgItems.Items.Count - 1)
            {
                Response.Write("<script>window.alert('No contact selected')</script>");
                return;
            }
            else
            {
                contactId = Convert.ToInt32(this.DgItems.SelectedItem.Cells[1].Text);
                contactName = this.DgItems.SelectedItem.Cells[3].Text;
                contactEmail = this.DgItems.SelectedItem.Cells[4].Text;
                contactAddress = this.DgItems.SelectedItem.Cells[5].Text;
                contactCompany = this.DgItems.SelectedItem.Cells[6].Text;

                Response.Redirect("WebFormEditContact.aspx", true);
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.DgItems.Items.Count == 0)
            {
                Response.Write("<script>window.alert('No contacts to delete')</script>");
                return;
            }
            else if (this.DgItems.SelectedIndex < 0 || this.DgItems.SelectedIndex > this.DgItems.Items.Count - 1)
            {
                Response.Write("<script>window.alert('No contact selected')</script>");
                return;
            }
            else
            {
                // Response doesn't work
                Response.Write("<script>window.alert('Contact deleted successfully')</script>");
                ContactsRepository contactsRepository = RepositoryFactory.GetContactsRepository();
                Contact contact = new Contact();
                contact.Id = Convert.ToInt32(this.DgItems.SelectedItem.Cells[1].Text);                
                contactsRepository.Delete(contact);                
                Response.Redirect(Request.RawUrl);                          
            }              
        }

        protected void BtnNewPhone_Click(object sender, EventArgs e)
        {
            if (this.DgItems.SelectedIndex < 0 ||
                this.DgItems.SelectedIndex > this.DgItems.Items.Count - 1)
            {
                Response.Write("<script>window.alert('No contact selected to add a phone to')</script>");
                return;
            }
            else
            {
                parentContactId = Convert.ToInt32(this.DgItems.SelectedItem.Cells[1].Text);
                Response.Redirect("WebFormAddPhone.aspx", true);
            }
        }

        protected void BtnEditPhone_Click(object sender, EventArgs e)
        {
            if (this.DgSubItems.Items.Count == 0)
            {
                Response.Write("<script>window.alert('No phone to edit')</script>");
                return;
            }
            else if (this.DgSubItems.SelectedIndex < 0 || this.DgSubItems.SelectedIndex > this.DgSubItems.Items.Count - 1)
            {
                Response.Write("<script>window.alert('No phone selected')</script>");
                return;
            }
            else
            {
                phoneId = Convert.ToInt32(this.DgSubItems.SelectedItem.Cells[1].Text);
                parentContactId = Convert.ToInt32(this.DgSubItems.SelectedItem.Cells[2].Text);
                phoneNumber = this.DgSubItems.SelectedItem.Cells[3].Text;

                Response.Redirect("WebFormEditPhone.aspx", true);
            }
        }

        protected void BtnDeletePhone_Click(object sender, EventArgs e)
        {
            if (this.DgSubItems.Items.Count == 0)
            {
                Response.Write("<script>window.alert('No phones to delete')</script>");
                return;
            }
            else if (this.DgSubItems.SelectedIndex < 0 || this.DgSubItems.SelectedIndex > this.DgSubItems.Items.Count - 1)
            {
                Response.Write("<script>window.alert('No phone selected')</script>");
                return;
            }
            else
            {
                // Response doesn't work
                Response.Write("<script>window.alert('Phone deleted successfully')</script>");
                PhonesRepository phonesRepository = RepositoryFactory.GetPhonesRepository();
                Phone phone = new Phone();
                phone.Id = Convert.ToInt32(this.DgSubItems.SelectedItem.Cells[1].Text);                
                phonesRepository.Delete(phone);                
                Response.Redirect(Request.RawUrl);                
            }
        }        

        protected void DgItems_SelectedIndexChanged(object sender, EventArgs e)
        {            
        }
    }
}