using BestLogistic.Controllers;
using BestLogistic.Models;
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
            SenderCity.Text = "";
            SenderState.Text = "";
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
                SenderCity.Text = arr[0];
                SenderState.Text = arr[1];
            }
        }

        protected void ReceiverPostal_TextChanged(object sender, EventArgs e)
        {
            ReceiverCity.Text = "";
            ReceiverState.Text = "";
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
                ReceiverCity.Text = arr[0];
                ReceiverState.Text = arr[1];
            }
        }


        protected void dbPickUpDate_Init(object sender, EventArgs e)
        {
            List<DateTime> arrList = new List<DateTime>();
            for (int i = 0, j = 1; j < 5; i++, j++)
            {
                arrList.Add(DateTime.Today.AddDays(j));
                ListItem newitem = new ListItem(arrList[i].Date.ToString("yyyy-MM-dd"));
                dbPickUpDate.Items.Add(newitem);
            };
        }


        protected void ParcelRTime_Load(object sender, EventArgs e)
        {
            
            ParcelRTime.Text = DateTime.Now.ToString("HH:mm");
        }

        
        protected void QuoteBtn_Click(object sender, EventArgs e)
        {
            
           

            decimal PickupPrice,deliveryfee;
            bool serviceType = true;
            if (LodgeUpBtn.Checked)
            {
                serviceType = true;
                PickupPrice = 0;
            }
            else
            {
                serviceType = false;
                PickupPrice = 5;
            }
                

            bool parcelType = true;
            if (TypeofParcel.SelectedItem.ToString() == "Parcel")
                parcelType = true;
            else
                parcelType = false;

            ParcelInfo parcelInfo = new ParcelInfo(serviceType,parcelType,Convert.ToByte(Pieces.Text),Content.Text,Convert.ToDecimal(ValueofContent.Text),
                Convert.ToSingle(Weight.Text), 0, PickupPrice);
            PickUpInfo pickupInfo = new PickUpInfo(Convert.ToDateTime(dbPickUpDate.Text), Convert.ToDateTime(ParcelRTime.Text), remarks.ToString(), true);
            if (LodgeUpBtn.Checked)
            {
                deliveryfee= ParcelController.Quote(SenderLocation.Text, SenderPostal.Text, ReceiverLocation.Text, ReceiverPostal.Text, parcelInfo, null);
            }
            else
            {
                
                deliveryfee= ParcelController.Quote(SenderLocation.Text, SenderPostal.Text, ReceiverLocation.Text, ReceiverPostal.Text, parcelInfo, pickupInfo);
            }

           // PersonInfo senderInfo = new PersonInfo(SenderName.Text, SenderEmail.Text, SenderContactNo.Text, SenderAdd.Text, SenderPostal.Text, SenderLocation.Text,
           //    SenderCity.Text, SenderState.Text);
            //PersonInfo receiverInfo = new PersonInfo(ReceiverName.Text, ReceiverEmail.Text, ReceiverContactNo.Text, ReceiverAdd.Text, ReceiverPostal.Text,
            //    ReceiverLocation.Text, ReceiverCity.Text, ReceiverState.Text);
            // ParcelController.Create(Authentication.GetUid,User.IdType,User.IdNumber,senderInfo,receiverInfo,);
            Response.Redirect("Checkout.aspx");
           
        }

       
    }
}