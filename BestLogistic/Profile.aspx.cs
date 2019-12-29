using System;
using System.Collections;
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
        Repository repository = new Repository();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            // redirect back to home page if not signed in
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            if (!Authentication.IsSignedIn()
                && !path.Equals("/default.aspx")
                && !path.Equals("/SendPackage.aspx")
                && !path.Equals("/Tracking.aspx")
                && !path.Equals("/SendPackage")
                && !path.Equals("/Tracking"))
            {
                Response.Redirect("~/", true);
            }

            if (IsPostBack)
                return;
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

            address.Text = user.Address;
            postCode.Text = user.Postcode;
            homeNumber.Text = user.HomeNumber;
            mobileNumber.Text = user.PhoneNumber;

            if (user.Postcode != null || user.Location != null)
            {
                ArrayList arr = repository.GetAreaFromPostCode(user.Postcode);
                userLocation.Items.Clear();
                userLocation.DataSource = arr;
                userLocation.DataBind();

                string[] array = repository.GetCityAndStateFromPostCodeAndLocation(user.Postcode, user.Location);
                city.Text = array[0];
                state.Text = array[1];

                userLocation.SelectedValue = user.Location;
            }

            


        }

        protected void postCode_TextChanged(object sender, EventArgs e)
        {
            city.Text = "";
            state.Text = "";
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Repository repository = new Repository();
                ArrayList arr = repository.GetAreaFromPostCode(textbox.Text);
                userLocation.Items.Clear();
                userLocation.DataSource = arr;
                userLocation.DataBind();
                userLocation.Items.Insert(0, new ListItem(""));
            }
        }

        protected void userLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;
            if (list != null)
            {
                if (list.Items[0].Value == "")
                    list.Items.Remove("");
                Repository repository = new Repository();
                string[] arr = repository.GetCityAndStateFromPostCodeAndLocation(postCode.Text, list.Text);
                city.Text = arr[0];
                state.Text = arr[1];
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            User user = repository.GetUser(Authentication.GetUid());

            if (address.Text == "" || postCode.Text == "" || userLocation.SelectedValue == "")
            {

            }
            else
            {
                Repository.UpdateUserAddress(user.Uid, address.Text, postCode.Text, userLocation.SelectedValue);
                ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Update address successful');", true);
            }
        }

        protected void updateMobile_Click(object sender, EventArgs e)
        {
            User user = repository.GetUser(Authentication.GetUid());
            if (mobileNumber.Text == "")
            {
               
            }
            else
            {
                Repository.UpdateUserMobileNumber(user.Uid, mobileNumber.Text);
            }
            
        }

        protected void updateHomeNumber_Click(object sender, EventArgs e)
        {
            User user = repository.GetUser(Authentication.GetUid());
            if (homeNumber.Text == "")
            {

            }
            else
            {
                Repository.UpdateUserHomeNumber(user.Uid, homeNumber.Text);
            }
            
        }

        protected void updatePassword_Click(object sender, EventArgs e)
        {
            User user = repository.GetUser(Authentication.GetUid());
            if (currentPassword.Text == "" || newPassword.Text == "")
            {

            }
            else
            {
                if(repository.UpdateUserPassword(user.Uid, user.Email, currentPassword.Text, newPassword.Text) == true)
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Change password successful');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "alert('Fail to change passowrd');", true);
                }
                
            }
        }
    }
}