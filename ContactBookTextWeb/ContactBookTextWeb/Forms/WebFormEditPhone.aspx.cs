using System;
using System.Collections.Generic;
using DataAccess.Service;
using DataAccess.Entity;
using DataAccess.Repository;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormEditPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AuthenticationService.LoggedUser.Id == 1)
            {
                this.BtnAdministration.Visible = true;
            }

            if (!this.Page.IsPostBack)
            {
                this.TbPhone.Focus();
                this.TbPhone.Text = WebFormManager.phoneNumber;   
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
            int phoneParse;
            if (!Int32.TryParse(this.TbPhone.Text, out phoneParse))
            {
                Response.Write("<script>window.alert('Input digits only')</script>");
                return;
            }
            else if (this.TbPhone.Text == String.Empty)
            {
                Response.Write("<script>window.alert('No phone inserted')</script>");
                return;
            }            
            else
            {
                PhonesRepository phonesRepository = RepositoryFactory.GetPhonesRepository();
                Phone phone = new Phone();                
                phone.Id = WebFormManager.phoneId;
                phone.ParentContactId = WebFormManager.parentContactId;
                phone.PhoneNumber = this.TbPhone.Text;
                phonesRepository.Save(phone);

                Response.Write("<script>window.alert('Phone edited successfully')</script>");
                Response.Redirect("WebFormManager.aspx", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormManager.aspx", true);
        }             
    }
}