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
    public partial class StartTrip : Form
    {
        String branchId;
        Staff staff = Authentication.CurrentStaff;
        string nextBranch;
        List<int> trackingNumList;
        Best_Logistic_Administrator admin;
        public StartTrip(Best_Logistic_Administrator admin, string route, string nextBranch, List<int> trackingNumList)
        {
            InitializeComponent();
            branchId = staff.BranchId;
            if (route == "Pending Delivery")
            {
                route = "Home";
            }
            if (nextBranch == "2")
            {
                nextBranch = null;
            }
            this.nextBranch = nextBranch;
            this.trackingNumList = trackingNumList;
            this.admin = admin;
            status.Text = "Start trip to " + route;

        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            const string message = "Confirm start trip? ";
            const string caption = "Start Trip";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                
            }
            else
            {
                string carNumber = carNo.Text;
                ParcelController.StartTransit(branchId, nextBranch, carNumber, trackingNumList);
                this.Close();
                admin.ViewParcelInBranch();

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
