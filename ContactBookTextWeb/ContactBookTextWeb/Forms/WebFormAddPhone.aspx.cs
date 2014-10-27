using System;
using System.Collections.Generic;
using DataAccess.Service;
using DataAccess.Entity;
using DataAccess.Repository;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormAddPhone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TbPhone.Focus();            
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
            Phone phone = new Phone();
            PhonesRepository phonesRepository = RepositoryFactory.GetPhonesRepository();

            int phoneParse;
            if (this.TbPhone.Text == String.Empty)
            {
                Response.Write("<script>window.alert('No phone inserted')</script>");
                return;
            }
            else if (!Int32.TryParse(this.TbPhone.Text, out phoneParse))
            {
                Response.Write("<script>window.alert('Input digits only')</script>");
                return;
            }
            else
            {
                phone.ParentContactId = WebFormManager.parentContactId;
                phone.PhoneNumber = this.TbPhone.Text;
                phonesRepository.Save(phone);
                Response.Write("<script>window.alert('Phone added successfully')</script>");
                Response.Redirect("WebFormManager.aspx", true);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormManager.aspx", true);
        }        
    }
}