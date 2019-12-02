using BestLogistic.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestLogistic
{
    public partial class SendPackage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SenderPostal_TextChanged(object sender, EventArgs e)
        {
            SCity.Text = "";
            SState.Text = "";
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Repository repository = new Repository();
                ArrayList arr = repository.GetAreaFromPostCode(textbox.Text);
                SenderLocation.Items.Clear();
                SenderLocation.DataSource = arr;
                SenderLocation.DataBind();
                SenderLocation.Items.Insert(0, new ListItem(""));
            }
        }

        protected void SenderLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;
            if (list != null)
            {
                if (list.Items[0].Value == "")
                    list.Items.Remove("");
                Repository repository = new Repository();
                string[] arr = repository.GetCityAndStateFromPostCodeAndLocation(SenderPostal.Text, list.Text);
                SCity.Text = arr[0];
                SState.Text = arr[1];
            }
        }

        protected void ReceiverPostal_TextChanged(object sender, EventArgs e)
        {
            RCity.Text = "";
            RState.Text = "";
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Repository repository = new Repository();
                ArrayList arr = repository.GetAreaFromPostCode(textbox.Text);
                ReceiverLocation.Items.Clear();
                ReceiverLocation.DataSource = arr;
                ReceiverLocation.DataBind();
                ReceiverLocation.Items.Insert(0, new ListItem(""));
            }
        }

        protected void ReceiverLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;
            if (list != null)
            {
                if (list.Items[0].Value == "")
                    list.Items.Remove("");
                Repository repository = new Repository();
                string[] arr = repository.GetCityAndStateFromPostCodeAndLocation(ReceiverPostal.Text, list.Text);
                RCity.Text = arr[0];
                RState.Text = arr[1];
            }
        }
    }
}