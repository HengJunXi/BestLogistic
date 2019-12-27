using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BestLogistic.Controllers;
using BestLogistic.Models;

namespace BestLogistic
{
    public partial class Tracking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowMoreBtn_Click(object sender, EventArgs e)
        {
            //ParcelStatus status = new ParcelStatus(
            //    DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");

            //List<ParcelStatus> statusList = new List<ParcelStatus>();
            //statusList.Add(status);
            //status = new ParcelStatus(
            //    DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");
            //statusList.Add(status);
            //status = new ParcelStatus(
            //    DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");
            //statusList.Add(status);
            //status = new ParcelStatus(
            //    DateTime.Today, DateTime.Now, "Delivering to Kota Kinabalu");
            //statusList.Add(status);

            //ParcelStatusRepeater.DataSource = statusList;
            //ParcelStatusRepeater.DataBind();
        }

        protected void TrackBtn_Click(object sender, EventArgs e)
        {
            TrackResult tr = ParcelController.Track(TrackingNumber.Text);
            List<ParcelStatus> statusList = new List<ParcelStatus>();
            if (tr != null)
            {
                List<TrackRecord> records = tr.Records;

                ParcelStatusRepeater.Visible = (tr.Status != 0 && tr.Status != 1);
                ShowMoreBtn.Visible = (tr.Status != 0 && tr.Status != 1);
                MapPanel.Visible = (tr.Status != 0 && tr.Status != 1);

                ParcelStatus.Text = tr.Status.ToString();

                if (tr.Status != 0 && tr.Status != 1)
                {
                    for (int i = 0; i < records.Count; i++)
                    {
                        ParcelStatus parcelStatus;
                        if (i == 0)
                        {
                            string status = string.Empty;
                            switch (tr.Status)
                            {
                                case 2:
                                    status = "Pending in " + records[i].Departure;
                                    DepBranch.Text = records[i].DeparturePoint;
                                    ArrBranch.Text = "";
                                    break;
                                case 3:
                                    status = "Pending transit from " + records[i].Departure + " to " + records[i].Arrival;
                                    DepBranch.Text = records[i].DeparturePoint;
                                    ArrBranch.Text = records[i].ArrivalPoint;
                                    break;
                                case 5:
                                    status = "Pending delivery from " + records[i].Departure + " to receiver address";
                                    DepBranch.Text = records[i].DeparturePoint;
                                    ArrBranch.Text = "";
                                    break;
                            }
                            parcelStatus = new ParcelStatus("...", "...", status);
                        }
                        else
                        {
                            parcelStatus = new ParcelStatus(
                                records[i].ArrivalDateTime?.ToShortDateString(),
                                records[i].ArrivalDateTime?.ToShortTimeString(),
                                "Transited from " + records[i].Departure + " to " + records[i].Arrival);
                        }
                        statusList.Add(parcelStatus);
                    }
                }
            } 
            else
            {
                ParcelStatusRepeater.Visible = false;
                ShowMoreBtn.Visible = false;
                MapPanel.Visible = false;
            }
            ParcelStatusRepeater.DataSource = statusList;
            ParcelStatusRepeater.DataBind();
        }
    }
}