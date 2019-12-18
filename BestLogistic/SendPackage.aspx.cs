using BestLogistic.Controllers;
using BestLogistic.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            
            decimal PickupPrice=0,deliveryfee;
            bool serviceType = true;
            if (LodgeUpBtn.Checked)
            {
                serviceType = false;
                PickupPrice = 0;
            }
            else if(PickUpBtn.Checked)
            {
                serviceType = true;
                PickupPrice = 5;
            }
                

            bool parcelType = true;
            if (TypeofParcel.SelectedItem.ToString() == "Parcel")
                parcelType = false;
            else
                parcelType = true;

            ParcelInfo parcelInfo = new ParcelInfo(serviceType,parcelType,Convert.ToByte(Pieces.Text),Content.Text,Convert.ToDecimal(ValueofContent.Text),
                Convert.ToSingle(Weight.Text), 0, PickupPrice);
            PickUpInfo pickupInfo = new PickUpInfo(Convert.ToDateTime(dbPickUpDate.Text), Convert.ToDateTime(ParcelRTime.Text), remarksNote.Text, true);
            if (LodgeUpBtn.Checked)
            {
                deliveryfee= ParcelController.Quote(SenderLocation.Text, SenderPostal.Text, ReceiverLocation.Text, ReceiverPostal.Text, parcelInfo, null);
            }
            else
            {
                
                deliveryfee= ParcelController.Quote(SenderLocation.Text, SenderPostal.Text, ReceiverLocation.Text, ReceiverPostal.Text, parcelInfo, pickupInfo);
            }


            //Response.Redirect("Checkout.aspx");
            HttpContext.Current.Items.Add("DeliveryFee", deliveryfee);
            HttpContext.Current.Items.Add("PickUpFee", PickupPrice);
            HttpContext.Current.Items.Add("SenderName", SenderName.Text);
            HttpContext.Current.Items.Add("SenderContactNo", SenderContactNo.Text);
            HttpContext.Current.Items.Add("SenderAddress", SenderAdd.Text);
            HttpContext.Current.Items.Add("SenderPostal", SenderPostal.Text);
            HttpContext.Current.Items.Add("SenderLocation", SenderLocation.Text);
            HttpContext.Current.Items.Add("SenderCity", SenderCity.Text);
            HttpContext.Current.Items.Add("SenderState", SenderState.Text);
            HttpContext.Current.Items.Add("SenderEmail", SenderEmail.Text);

            HttpContext.Current.Items.Add("ServiceType", serviceType);
            if (serviceType == true)
            {
                HttpContext.Current.Items.Add("PickUpDate", dbPickUpDate.Text);
                HttpContext.Current.Items.Add("PickUpTime", ParcelRTime.Text);
                HttpContext.Current.Items.Add("Remarks", remarksNote.Text);
            }

            HttpContext.Current.Items.Add("ReceiverName", ReceiverName.Text);
            HttpContext.Current.Items.Add("ReceiverContactNo", ReceiverContactNo.Text);
            HttpContext.Current.Items.Add("ReceiverAddress", ReceiverAdd.Text);
            HttpContext.Current.Items.Add("ReceiverPostal", ReceiverPostal.Text);
            HttpContext.Current.Items.Add("ReceiverLocation", ReceiverLocation.Text);
            HttpContext.Current.Items.Add("ReceiverCity", ReceiverCity.Text);
            HttpContext.Current.Items.Add("ReceiverState", ReceiverState.Text);
            HttpContext.Current.Items.Add("ReceiverEmail", ReceiverEmail.Text);

            HttpContext.Current.Items.Add("ParcelType", parcelType);
            HttpContext.Current.Items.Add("Pieces", Pieces.Text);
            HttpContext.Current.Items.Add("Content", Content.Text);
            HttpContext.Current.Items.Add("ValueofContent", ValueofContent.Text);
            HttpContext.Current.Items.Add("Weight", Weight.Text);

            try
            {
                Server.Transfer("Checkout.aspx", true);
            }
            catch (ThreadAbortException)
            {
                // Exception ignored: Thread Abort = discontinue processing on the current page
            }
        }

     

       
    }
}