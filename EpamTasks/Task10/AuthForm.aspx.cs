using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EpamTasks.Entities;
using EpamTasks.PL;

namespace Task10
{
    public partial class AuthForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = LogicProvider.UserLogic.GetMd5Hash(textBoxPassword.Text);

            HttpCookie loginCookie = new HttpCookie("login", login);
            loginCookie.Expires = DateTime.Now.AddDays(10);
            HttpCookie passwordCookie = new HttpCookie("password", password);
            passwordCookie.Expires = DateTime.Now.AddDays(10);

            Response.Cookies.Add(loginCookie);
            Response.Cookies.Add(passwordCookie);

            User user = LogicProvider.UserLogic.SelectFullUserByLoginAndPass(login, password) as User;
            Session.Add("user", user);
            Response.Redirect("~");

        }
    }
}