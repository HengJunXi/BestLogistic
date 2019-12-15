using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestLogistic
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GetData();
          
        }

        private void GetData()
        {

            try
            {
                
                price.Text = HttpContext.Current.Items["DeliveryFee"].ToString();
                pickUpPrice.Text = HttpContext.Current.Items["PickUpFee"].ToString();

                priceOrder.Text = HttpContext.Current.Items["DeliveryFee"].ToString();
                pickUpPriceOrder.Text = HttpContext.Current.Items["PickUpFee"].ToString();
                SenderName.Text = HttpContext.Current.Items["SenderName"].ToString();
                SenderPhoneNo.Text = HttpContext.Current.Items["SenderContactNo"].ToString();
                addressCheckout.Text = HttpContext.Current.Items["SenderAddress"].ToString();
                postcodeCheckout.Text = HttpContext.Current.Items["SenderPostal"].ToString();
                locationCheckout.Text = HttpContext.Current.Items["SenderLocation"].ToString();
                cityCheckout.Text = HttpContext.Current.Items["SenderCity"].ToString();
                stateCheckout.Text = HttpContext.Current.Items["SenderState"].ToString();


                string Stype = HttpContext.Current.Items["ServiceType"].ToString();
                if (Stype == "True")
                {
                    ServiceType.Text = "Lodge In";
                    PickUpDateTitle.Visible = false;
                    PickUpTimeTitle.Visible = false;
                    RemarksTitle.Visible = false;
                }
                else if (Stype == "False")
                {
                    ServiceType.Text = "Pick Up";
                    PickUpDate.Text = HttpContext.Current.Items["PickUpDate"].ToString();
                    PickUpTime.Text = HttpContext.Current.Items["PickUpTime"].ToString();
                    Remarks.Text = HttpContext.Current.Items["Remarks"].ToString();
                }

                ReceiverName.Text = HttpContext.Current.Items["ReceiverName"].ToString();
                ReceiverPhoneNo.Text = HttpContext.Current.Items["ReceiverContactNo"].ToString();
                ReceiverAddress.Text = HttpContext.Current.Items["ReceiverAddress"].ToString();
                ReceiverPostal.Text = HttpContext.Current.Items["ReceiverPostal"].ToString();
                ReceiverLocation.Text = HttpContext.Current.Items["ReceiverLocation"].ToString();
                ReceiverCity.Text = HttpContext.Current.Items["ReceiverCity"].ToString();
                ReceiverState.Text = HttpContext.Current.Items["ReceiverState"].ToString();

                string Ptype = HttpContext.Current.Items["ParcelType"].ToString();
                if (Ptype == "True")
                {
                    ParcelType.Text = "Parcel";
                }
                else
                    ParcelType.Text = "Document";

                Piece.Text = HttpContext.Current.Items["Pieces"].ToString();
                Content.Text = HttpContext.Current.Items["Content"].ToString();
                Value.Text = HttpContext.Current.Items["ValueofContent"].ToString();
                Weight.Text = HttpContext.Current.Items["Weight"].ToString();

            }
            catch (NullReferenceException){

                {
                    Response.Write("No data provided");
                }
            }
          
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Server.Transfer("OrderSummary.aspx",true);
        }
    }
}