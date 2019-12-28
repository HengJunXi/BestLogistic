using BestLogistic.Controllers;
using BestLogistic.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BestLogistic
{
    public partial class Checkout : System.Web.UI.Page
    {
        bool serType;
        bool parType;
        byte idNo;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack && PreviousPage is SendPackage)
                    GetData();
                //Response.Write(serType);

            }
            catch (ThreadAbortException)
            {
                // Exception ignored: Thread Abort = discontinue processing on the current page
            }


            
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
                SenderIDType.Text = HttpContext.Current.Items["IDType"].ToString();
                SenderIDNumber.Text = HttpContext.Current.Items["SenderIDNo"].ToString();
                SenderMail.Text = HttpContext.Current.Items["SenderEmail"].ToString();
                addressCheckout.Text = HttpContext.Current.Items["SenderAddress"].ToString();
                postcodeCheckout.Text = HttpContext.Current.Items["SenderPostal"].ToString();
                locationCheckout.Text = HttpContext.Current.Items["SenderLocation"].ToString();
                cityCheckout.Text = HttpContext.Current.Items["SenderCity"].ToString();
                stateCheckout.Text = HttpContext.Current.Items["SenderState"].ToString();


                string Stype = HttpContext.Current.Items["ServiceType"].ToString();
                if (Stype == "False")
                {
                    ServiceType.Text = "Lodge In";
                    serType = false;
                    PickUpDateTitle.Visible = false;
                    PickUpTimeTitle.Visible = false;
                    RemarksTitle.Visible = false;
                }
                else if (Stype == "True")
                {
                    ServiceType.Text = "Pick Up";
                    serType = true;
                    PickUpDate.Text = HttpContext.Current.Items["PickUpDate"].ToString();
                    PickUpTime.Text = HttpContext.Current.Items["PickUpTime"].ToString();
                    Remarks.Text = HttpContext.Current.Items["Remarks"].ToString();
                }
                //Response.Write(serType);
                ReceiverName.Text = HttpContext.Current.Items["ReceiverName"].ToString();
                ReceiverPhoneNo.Text = HttpContext.Current.Items["ReceiverContactNo"].ToString();
                ReceiverMail.Text = HttpContext.Current.Items["ReceiverEmail"].ToString();
                ReceiverAddress.Text = HttpContext.Current.Items["ReceiverAddress"].ToString();
                ReceiverPostal.Text = HttpContext.Current.Items["ReceiverPostal"].ToString();
                ReceiverLocation.Text = HttpContext.Current.Items["ReceiverLocation"].ToString();
                ReceiverCity.Text = HttpContext.Current.Items["ReceiverCity"].ToString();
                ReceiverState.Text = HttpContext.Current.Items["ReceiverState"].ToString();

                string Ptype = HttpContext.Current.Items["ParcelType"].ToString();
                if (Ptype == "False")
                {
                    ParcelType.Text = "Parcel";
                    parType = false;
                }
                else
                {
                    ParcelType.Text = "Document";
                    parType = true;
                }


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
            try
            {
                
                if (ServiceType.Text == "Lodge In")
                {
                    serType = false;
                }
                else
                {
                    serType = true;
                }
                    
               if (ParcelType.Text == "Parcel")
                {
                    parType = false;
                }
                else
                {
                    parType = true;
                }

               if (SenderIDType.Text =="IC Number")
                {
                    idNo = 1;
                }
               else if (SenderIDType.Text =="Old IC Number")
                {
                    idNo = 2;
                }
                else
                {
                    idNo = 3;
                }

                PersonInfo senderInfo = new PersonInfo(SenderName.Text, SenderMail.Text, SenderPhoneNo.Text, addressCheckout.Text,
                    postcodeCheckout.Text, locationCheckout.Text, cityCheckout.Text, stateCheckout.Text);
               
                PersonInfo receiverInfo = new PersonInfo(ReceiverName.Text, ReceiverMail.Text, ReceiverPhoneNo.Text, ReceiverAddress.Text, ReceiverPostal.Text,
                    ReceiverLocation.Text, ReceiverCity.Text, ReceiverState.Text);
                
                ParcelInfo parcelInfo = new ParcelInfo(serType,parType,Convert.ToByte(Piece.Text),Content.Text,Convert.ToDecimal(Value.Text),Convert.ToSingle(Weight.Text),
                    Convert.ToDecimal(price.Text),Convert.ToDecimal(pickUpPrice.Text));
              
                string uid = Authentication.GetUid();
                //byte userIDType = Repository.GetUserIDType(uid);
               // string userIDNo = Convert.ToString(Repository.GetUserIDNumber(uid));
                

                if (serType == false)
                {
                    int trackingNo = ParcelController.Create(uid, idNo, SenderIDNumber.Text, senderInfo, receiverInfo,parcelInfo,null);
                    Response.Redirect("OrderSummary.aspx?trackNo="+trackingNo);
                }
                else if (serType == true)
                {
                    DateTime pud;


                    if (!DateTime.TryParseExact(PickUpDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out pud))
                    {
                        Response.Write("Problem with date");
                        return;
                    }

                    DateTime put;

                    if (!DateTime.TryParseExact(PickUpTime.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out put))
                    {
                        Response.Write("Problem with time");
                        return;
                    }
                    PickUpInfo pickInfo = new PickUpInfo(pud, put, Remarks.Text, false);
                    int trackingNo= ParcelController.Create(uid, idNo, SenderIDNumber.Text, senderInfo, receiverInfo, parcelInfo, pickInfo);
                    Response.Redirect("OrderSummary.aspx?trackNo="+trackingNo);
                    
                }
  
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {

                    Response.Write("Payment Not Successfully!");
                }

                //if (ex is ThreadAbortException)
                //{
                //    //ignore
                    
                //}

            }
           
        }
    }
}