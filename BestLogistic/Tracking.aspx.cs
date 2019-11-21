using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BestLogistic.Models;

namespace BestLogistic
{
    public partial class Tracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ParcelStatus status = new ParcelStatus(
                DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");

            List<ParcelStatus> statusList = new List<ParcelStatus>();
            statusList.Add(status);

            ParcelStatusRepeater.DataSource = statusList;
            ParcelStatusRepeater.DataBind();
        }

        protected void ShowMoreBtn_Click(object sender, EventArgs e)
        {
            ParcelStatus status = new ParcelStatus(
                DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");

            List<ParcelStatus> statusList = new List<ParcelStatus>();
            statusList.Add(status);
            status = new ParcelStatus(
                DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");
            statusList.Add(status);
            status = new ParcelStatus(
                DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");
            statusList.Add(status);
            status = new ParcelStatus(
                DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");
            statusList.Add(status);

            ParcelStatusRepeater.DataSource = statusList;
            ParcelStatusRepeater.DataBind();
        }
    }
}