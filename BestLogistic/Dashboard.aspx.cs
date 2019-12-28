using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BestLogistic.Controllers;
using BestLogistic.Models;

namespace BestLogistic
{
    public partial class Dashboard : System.Web.UI.Page
    {
        Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {
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

            User user = repository.GetUser(Authentication.GetUid());
            Username.Text = user.Name;

            pendingNum.Text = Convert.ToString(ParcelController.CalculatePendingParcels(user.Uid));
            pickUpNum.Text = Convert.ToString(ParcelController.CalculatePickUpParcels(user.Uid));
            inTransitNum.Text = Convert.ToString(ParcelController.CalculateInTransitParcels(user.Uid));
            outOfDeliveryNum.Text = Convert.ToString(ParcelController.CalculateDeliveringParcels(user.Uid));
            deliveredNum.Text = Convert.ToString(ParcelController.CalculateDeliveredParcels(user.Uid));

            List<ShipmentRecord> list = repository.GetShipmentHistory(user.Uid);
            Debug.WriteLine(list.Count);
            ShipmentHistory.DataSource = list;
            ShipmentHistory.DataBind();
        }
    }
}