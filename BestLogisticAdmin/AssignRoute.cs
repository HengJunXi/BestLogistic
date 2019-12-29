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
    public partial class AssignRoute : Form
    {
        List<int> trackingNum;
        Best_Logistic_Administrator admin;
        public AssignRoute(Best_Logistic_Administrator admin, List<Branch> list, List<int> trackingNum)
        {
            InitializeComponent();
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            for (int i = 0; i < list.Count; i++)
            {
                comboSource.Add(list[i].Id, list[i].Name);
            }
            comboSource.Add("NULL", "Home");
            comboSource.Add("NA", "Not Assigned");
            dbroute.DataSource = new BindingSource(comboSource, null);
            dbroute.DisplayMember = "Value";
            dbroute.ValueMember = "Key";
            dbroute.Enabled = true;
            this.trackingNum = trackingNum;
            this.admin = admin;
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            const string message = "Confirm assign route? ";
            const string caption = "Assign Route";
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
                string nextBranchId = dbroute.SelectedValue.ToString();
                bool notAssigned = false;
                if (dbroute.SelectedValue.ToString() == "NULL")
                {
                    nextBranchId = null;
                }
                else if (dbroute.SelectedValue.ToString() == "NA")
                {
                    nextBranchId = null;
                    notAssigned = true;
                }
                ParcelController.ChangeRoute(trackingNum, nextBranchId, notAssigned); 
                this.Close();
                admin.ViewParcelInBranch();
            }
        }
    }
}
