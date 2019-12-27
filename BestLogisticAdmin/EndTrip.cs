using BestLogisticAdmin.Controllers;
using BestLogisticAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestLogisticAdmin
{
    public partial class EndTrip : Form
    {
        String branchId;
        Staff staff = Authentication.CurrentStaff;
        List<int> trackingNumList;
        string route;
        public EndTrip(string branchName, string route, List<int> trackingNumList)
        {
            InitializeComponent();
            branchId = staff.BranchId;
                    
            label1.Text = branchName;
            this.trackingNumList = trackingNumList;
            this.route = route;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            const string message = "Confirm end trip? ";
            const string caption = "End Trip";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                this.Close();
            }
            else
            {
                string carNumber = carNo.Text;
                ParcelController.EndTransit(branchId, route, carNumber, trackingNumList);
                this.Close();
            }
        }

        private void Dbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Status_Click(object sender, EventArgs e)
        {

        }
    }
}
