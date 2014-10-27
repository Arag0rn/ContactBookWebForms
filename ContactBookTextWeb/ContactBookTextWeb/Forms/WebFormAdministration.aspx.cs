using System;
using DataAccess.Service;
using DataAccess.Entity;
using DataAccess.Repository;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormAdministration : System.Web.UI.Page
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
    }
}