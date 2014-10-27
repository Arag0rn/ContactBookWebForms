using System;
using System.IO;
using DataAccess.Entity;
using DataAccess.Repository;

namespace ContactBookTextWeb.Forms
{
    public partial class WebFormRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TbFirstName.Focus();
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            User user = new User();
            UsersRepository usersRepository = RepositoryFactory.GetUsersRepository();
            user.Id = 1;            
            if (this.TbFirstName.Text == String.Empty ||
                this.TbLastName.Text == String.Empty ||
                this.TbUsername.Text == String.Empty ||
                this.TbPassword.Text == String.Empty ||
                this.TbConfirmPassword.Text == String.Empty)
            {
                Response.Write("<script>window.alert('All fields required!')</script>");                                
                return;
            }
            else if (this.TbConfirmPassword.Text != this.TbPassword.Text)                
            {
                this.TbPassword.Text = String.Empty;
                this.TbConfirmPassword.Text = String.Empty;                                
                Response.Write("<script>window.alert(\"Password don't match\")</script>");                
                return;                
            }
            else if (!File.Exists("users.txt"))
            {
                FileStream fs = new FileStream("users.txt", FileMode.Append, FileAccess.Write);
                fs.Close();

                if (new FileInfo("users.txt").Length == 0)
                {
                    user.Id = 1;
                    user.AdminPrivilegeIndex = 0;
                    user.FirstName = this.TbFirstName.Text;
                    user.LastName = this.TbLastName.Text;
                    user.Username = this.TbUsername.Text;
                    user.Password = this.TbPassword.Text;
                    usersRepository.Insert(user);
                    Response.Redirect("WebFormLogin.aspx", true);
                    return;
                }   
            }
            else if (new FileInfo("users.txt").Length == 0)
            {
                user.Id = 1;
                user.AdminPrivilegeIndex = 0;
                user.FirstName = this.TbFirstName.Text;
                user.LastName = this.TbLastName.Text;
                user.Username = this.TbUsername.Text;
                user.Password = this.TbPassword.Text;
                usersRepository.Insert(user);
                Response.Redirect("WebFormLogin.aspx", true);
                return;
            }      
            else
            {                               
                foreach (User item in usersRepository.GetAll())
                {
                    if (this.TbUsername.Text == item.Username)
                    {
                        Response.Write("<script>window.alert(\"Username already exists!\")</script>");
                        this.TbUsername.Text = String.Empty;
                        return;
                    }
                }

                user.AdminPrivilegeIndex = 0;
                user.FirstName = this.TbFirstName.Text;
                user.LastName = this.TbLastName.Text;
                user.Username = this.TbUsername.Text;
                user.Password = this.TbPassword.Text;
                usersRepository.Insert(user);
                Response.Redirect("WebFormLogin.aspx", true);
            }            
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            this.TbFirstName.Text = String.Empty;
            this.TbLastName.Text = String.Empty;
            this.TbUsername.Text = String.Empty;
            this.TbPassword.Text = String.Empty;
            this.TbConfirmPassword.Text = String.Empty;
        }
    }
}