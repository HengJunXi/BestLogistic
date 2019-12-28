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
    public partial class Tracking : System.Web.UI.Page
    {
        static List<ParcelStatus> statusList = new List<ParcelStatus>();
        readonly int limit = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("Page Load");
        }

        protected void ShowMoreBtn_Click(object sender, EventArgs e)
        {
            List<ParcelStatus> resultList;

            if (ShowMoreBtn.Text == "Show more")
            {
                resultList = statusList;
                ShowMoreBtn.Text = "Show less";
            }
            else
            {
                resultList = new List<ParcelStatus>();
                int count = (statusList.Count < limit ? statusList.Count : limit);

                for (int i = 0; i < count; i++)
                    resultList.Add(statusList[i]);

                ShowMoreBtn.Text = "Show more";
            }

            ParcelStatusRepeater.DataSource = resultList;
            ParcelStatusRepeater.DataBind();
        }

        protected void TrackBtn_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Track!");
            ErrorMessage.Visible = false;
            statusList.Clear();

            TrackResult tr = ParcelController.Track(TrackingNumber.Text);
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
                        if (i == 0 && tr.Status != 4)
                        {
                            string status = string.Empty;
                            if (tr.Status == 2 || tr.Status == 3 || tr.Status == 5)
                            {
                                switch (tr.Status)
                                {
                                    case 2:
                                        status = "Pending in " + records[i].Departure;
                                        DepBranch.Text = records[i].DeparturePoint;
                                        DepBranchName.Text = records[i].Departure + " Branch";
                                        ArrBranch.Text = "";
                                        ArrBranchName.Text = "";
                                        break;
                                    case 3:
                                        status = "Pending transit from " + records[i].Departure + " to " + records[i].Arrival;
                                        DepBranch.Text = records[i].DeparturePoint;
                                        DepBranchName.Text = records[i].Departure + " Branch";
                                        ArrBranch.Text = records[i].ArrivalPoint;
                                        ArrBranchName.Text = records[i].Arrival + " Branch";
                                        break;
                                    case 5:
                                        status = "Pending delivery from " + records[i].Departure + " to receiver address";
                                        DepBranch.Text = records[i].DeparturePoint;
                                        DepBranchName.Text = records[i].Departure + " Branch";
                                        ArrBranch.Text = "";
                                        ArrBranchName.Text = "";
                                        break;
                                }
                                parcelStatus = new ParcelStatus("...", "...", status);
                            } 
                            else if (tr.Status == 6)
                            {
                                status = "Delivering from " + records[i].Departure + " to receiver address";
                                DepBranch.Text = records[i].DeparturePoint;
                                DepBranchName.Text = records[i].Departure + " Branch";
                                ArrBranch.Text = "";
                                ArrBranchName.Text = "";
                                parcelStatus = new ParcelStatus(
                                    records[i].DepartureDateTime?.ToShortDateString(), 
                                    records[i].DepartureDateTime?.ToShortTimeString(), 
                                    status);
                            }
                            else    // 7
                            {
                                status = "Delivered to receiver address";
                                DepBranch.Text = "";
                                DepBranchName.Text = "";
                                ArrBranch.Text = "";
                                ArrBranchName.Text = "";
                                parcelStatus = new ParcelStatus(
                                    records[i].ArrivalDateTime?.ToShortDateString(),
                                    records[i].ArrivalDateTime?.ToShortTimeString(),
                                    status);
                            }
                        }
                        else        // 4 & previous transit
                        {
                            parcelStatus = new ParcelStatus(
                                records[i].ArrivalDateTime?.ToShortDateString(),
                                records[i].ArrivalDateTime?.ToShortTimeString(),
                                "Transited from " + records[i].Departure + " to " + records[i].Arrival);
                        }
                        statusList.Add(parcelStatus);
                    }
                } 
                else
                {
                    ErrorMessage.ForeColor = System.Drawing.Color.Red;
                    ErrorMessage.Text = "Parcel is pending";
                    ErrorMessage.Visible = true;
                }
            } 
            else
            {
                ParcelStatusRepeater.Visible = false;
                ShowMoreBtn.Visible = false;
                MapPanel.Visible = false;
                ErrorMessage.ForeColor = System.Drawing.Color.Red;
                ErrorMessage.Text = "Parcel not found";
                ErrorMessage.Visible = true;
            }

            List<ParcelStatus> resultList = new List<ParcelStatus>();
            int count = (statusList.Count < limit ? statusList.Count : limit);            

            for (int i = 0; i < count; i++)
                resultList.Add(statusList[i]);

            ShowMoreBtn.Visible = (statusList.Count > limit);

            ParcelStatusRepeater.DataSource = resultList;
            ParcelStatusRepeater.DataBind();
        }
    }
}