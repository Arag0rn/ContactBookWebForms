using System;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebFormLogin.aspx", true);
        }
    }
}