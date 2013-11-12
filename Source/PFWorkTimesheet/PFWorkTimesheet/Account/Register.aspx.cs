using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace PFWorkTimesheet.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];

            //If no admin acount created yet, get user to make one.
            if (Membership.GetUser("Admin") == null)
            {
                RegisterUser.UserName = "Admin";
            }
            //If use is Admin, allow user to create accounts
            else if (User.Identity.Name.ToLower() == "admin")
            {
                //do nothing
            }
            //If there is an admin account but is not logged in, redirect to login page.
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }
    }
}