using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BestLogistic.Controllers;

namespace BestLogistic
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FromPostCode_TextChanged(object sender, EventArgs e)
        {
            FromCity.Text = "";
            FromState.Text = "";
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Repository repository = new Repository();
                ArrayList arr = repository.GetAreaFromPostCode(textbox.Text);
                FromLocation.Items.Clear();
                FromLocation.DataSource = arr;
                FromLocation.DataBind();
                FromLocation.Items.Insert(0, new ListItem(""));
            }
        }

        protected void ToPostCode_TextChanged(object sender, EventArgs e)
        {
            ToCity.Text = "";
            ToState.Text = "";
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Repository repository = new Repository();
                ArrayList arr = repository.GetAreaFromPostCode(textbox.Text);
                ToLocation.Items.Clear();
                ToLocation.DataSource = arr;
                ToLocation.DataBind();
                ToLocation.Items.Insert(0, new ListItem(""));
            }
        }

        protected void FromLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;
            if (list != null)
            {
                if (list.Items[0].Value == "")
                    list.Items.Remove("");
                Repository repository = new Repository();
                string[] arr = repository.GetCityAndStateFromPostCodeAndLocation(FromPostCode.Text, list.Text);
                FromCity.Text = arr[0];
                FromState.Text = arr[1];
            }
        }

        protected void ToLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = sender as DropDownList;
            if (list != null)
            {
                if (list.Items[0].Value == "")
                    list.Items.Remove("");
                Repository repository = new Repository();
                string[] arr = repository.GetCityAndStateFromPostCodeAndLocation(ToPostCode.Text, list.Text);
                ToCity.Text = arr[0];
                ToState.Text = arr[1];
            }
        }

        protected void QuoteBtn_Click(object sender, EventArgs e)
        {
            string senderPostcode = FromPostCode.Text;
            string senderLocation = FromLocation.SelectedValue;
            string receiverPostcode = ToPostCode.Text;
            string receiverLocation = ToLocation.SelectedValue;
            float parcelWeight = Convert.ToSingle(Weight.Text);
            Decimal quotedPrice = ParcelController.Quote(senderLocation, senderPostcode, receiverLocation, receiverPostcode,
                new Models.ParcelInfo(false, false, 1, "", 0, parcelWeight, 0, 0), null);

            QuotedPrice.Text = "RM " + quotedPrice.ToString("N2");
            QuotedPrice.Visible = true;
        }
    }
}