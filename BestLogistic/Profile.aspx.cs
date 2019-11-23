using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BestLogistic.Controllers;
using BestLogistic.Models;

namespace BestLogistic
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect back to home page if not signed in
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            if (!Authentication.IsSignedIn()
                && !path.Equals("/default.aspx")
                && !path.Equals("/SendPackage")
                && !path.Equals("/Tracking"))
            {
                Response.Redirect("~/", true);
            }

            Repository repository = new Repository();
            User user = repository.GetUser(Authentication.GetUid());

            Label1.Text = user.Name;
            email.Text = user.Email;
            dateBirth.Text = user.DateOfBirth.ToShortDateString();
            switch (user.IdType)
            {
                case 1:
                    idType.Text = "IC Number";
                    break;
                case 2:
                    idType.Text = "Old IC Number";
                    break;
                case 3:
                    idType.Text = "Passport";
                    break;
            }
            idNum.Text = user.IdNumber;

            //Address.Text = string.Empty;
            //postCode.Text = string.Empty;
            //location.Text = string.Empty;
            //TextBox2.Text = string.Empty;
            //TextBox1.Text = string.Empty;
        }
    }
}