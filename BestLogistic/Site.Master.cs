using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BestLogistic.Controllers;
using BestLogistic.Models;

namespace BestLogistic
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect back to home page if not signed in
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            Debug.WriteLine(path);
            if (!Authentication.IsSignedIn() 
                && !path.Equals("/default.aspx")
                && !path.Equals("/SendPackage.aspx")
                && !path.Equals("/Tracking.aspx")
                && !path.Equals("/SendPackage")
                && !path.Equals("/Tracking"))
            {
                Response.Redirect("~/", true);
            }
            ChangeHeader();
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string email = RegisterEmail.Text;
            string password = RegisterPassword.Text;
            string fullName = RegisterFullName.Text;
            string idType = RegisterIdType.SelectedValue;
            string idNumber = RegisterIdNumber.Text;
            string dateOfBirth = RegisterDob.Text;

            Authentication.RegisterUser(email, password, fullName, idType, idNumber, dateOfBirth);
        }

        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            string email = SignInEmail.Text;
            string password = SignInPassword.Text;

            Debug.WriteLine(Authentication.SignInUser(email, password));
            ChangeHeader();
        }

        protected void SignOutBtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Sign out");
            Authentication.SignOutUser();
            Response.Redirect("~/");
        }

        protected void ChangeHeader()
        {
            object obj = Session["uid"];
            if (obj == null)
            {
                HeaderModalBtn.Visible = true;
                HeaderProfileBtn.Visible = false;
                HeaderDashboardNavItem.Visible = false;
            }
            else
            {
                HeaderModalBtn.Visible = false;
                HeaderProfileBtn.Visible = true;
                HeaderDashboardNavItem.Visible = true;
            }
        }
    }
}