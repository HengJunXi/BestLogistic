﻿using BestLogisticAdmin.Controllers;
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
        DataGridView dataGridView;
        string route;
        Best_Logistic_Administrator admin;
        public EndTrip(Best_Logistic_Administrator admin, string branchName, string route, DataGridView dataGridView)
        {
            InitializeComponent();
            branchId = staff.BranchId;
                    
            this.dataGridView = dataGridView;
            this.route = route;
            this.admin = admin;
            if (route == null)
            {
                status.Text = "End trip to " + branchName;
            }
            else
            {
                status.Text = "End trip from " + branchName;
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            const string message = "Confirm end trip? ";
            const string caption = "End Trip";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            List<int> list = new List<int>();
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Cells[2].Value.ToString() == carNo.Text)
                {
                    list.Add(Convert.ToInt32(dataGridView.Rows[i].Cells[1].Value));
                }
            }

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                this.Close();
            }
            else if (route == null)
            {
                string carNumber = carNo.Text;
                ParcelController.EndTransit(branchId, route, carNumber, list);
                this.Close();
                admin.ViewOutGoingParcel();
            }
            else
            {
                string carNumber = carNo.Text;
                ParcelController.EndTransit(branchId, route, carNumber, list);
                this.Close();
                admin.ViewIncomingParcel();
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
