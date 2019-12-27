using BestLogistic.Controllers;
using BestLogistic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestLogistic
{
    public partial class OrderSummary : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
                string trackingNo = Request.QueryString["trackNo"];
                PopulateData(trackingNo);

        }

        private void PopulateData(string trackingNo)
        {
            try
            {
               DataTable result =  ParcelController.Get(Convert.ToInt32(trackingNo));
                tNo.Text = result.Rows[0].Field<Int32>("tracking_number").ToString();
                decimal deliveryFee= result.Rows[0].Field<decimal>("delivery_fee");
                priceOrder.Text = deliveryFee.ToString();
                decimal pickUpfee = result.Rows[0].Field<decimal>("pick_up_fee");
                pickUpPriceOrder.Text = pickUpfee.ToString();
                totalPayment.Text = (deliveryFee + pickUpfee).ToString();
                SenderName.Text = result.Rows[0].Field<string>(11);
                SenderPhoneNo.Text = result.Rows[0].Field<string>(14);
                addressCheckout.Text = result.Rows[0].Field<string>(16);
                postcodeCheckout.Text = result.Rows[0].Field<string>(18);
                locationCheckout.Text = result.Rows[0].Field<string>(17);

                Repository repository = new Repository();
                string[] arr = repository.GetCityAndStateFromPostCodeAndLocation(postcodeCheckout.Text, locationCheckout.Text);
                cityCheckout.Text = arr[0];
                stateCheckout.Text = arr[1];

                if (result.Rows[0].Field<bool>(1) == false)
                {
                    ServiceType.Text = "Lodge In";
                    PickUpDateTitle.Visible = false;
                    PickUpTimeTitle.Visible = false;
                    RemarksTitle.Visible = false;

                }
                else
                {
                    ServiceType.Text = "Pick Up";
                    DataTable result2 = ParcelController.GetPickUpInfo(Convert.ToInt32(trackingNo));
                    PickUpDate.Text= result2.Rows[0].Field<DateTime>(2).ToString();
                    PickUpTime.Text = result2.Rows[0].Field<DateTime>(3).ToString();
                    Remarks.Text = result2.Rows[0].Field<string>(4);
                }
                   

                ReceiverName.Text = result.Rows[0].Field<string>(19);
                ReceiverPhoneNo.Text = result.Rows[0].Field<string>(20);
                ReceiverAddress.Text = result.Rows[0].Field<string>(22);
                ReceiverPostal.Text = result.Rows[0].Field<string>(24);
                ReceiverLocation.Text = result.Rows[0].Field<string>(23);
                string[] arr2 = repository.GetCityAndStateFromPostCodeAndLocation(ReceiverPostal.Text, ReceiverLocation.Text);
                ReceiverCity.Text = arr2[0];
                ReceiverState.Text = arr2[1];


                if (result.Rows[0].Field<bool>(2) == false)
                {
                    ParcelType.Text = "Parcel";
                }
                else
                    ParcelType.Text = "Document";

                Piece.Text = result.Rows[0].Field<byte>(3).ToString();
                Content.Text = result.Rows[0].Field<string>(4);
                Value.Text = result.Rows[0].Field<decimal>(5).ToString();
                Weight.Text = result.Rows[0].Field<float>(6).ToString();


            }
            catch (NullReferenceException)
            {
                Response.Write("Payment Not Successfully!");
            }
        }

        protected void btnNextSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendPackage.aspx");
        }
    }
}