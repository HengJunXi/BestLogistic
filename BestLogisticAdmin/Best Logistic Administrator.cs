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
    public partial class Best_Logistic_Administrator : Form
    {
        public String branchId;
        Staff staff = Authentication.CurrentStaff;

        public Best_Logistic_Administrator()
        {
            InitializeComponent();
        }

        private void changeRoute_Click(object sender, EventArgs e)
        {
            AssignRoute routePage = new AssignRoute();
            routePage.ShowDialog();
        }

        private void add_Click(object sender, EventArgs e)
        {
            CreateNewParcel addPage = new CreateNewParcel();
            addPage.ShowDialog();
        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            StartTrip statusPage = new StartTrip();
            statusPage.ShowDialog();
        }

        private void DeleteParcel_Click(object sender, EventArgs e)
        {
            const string message = "Are you confirm to delete the parcel infomation? ";
            const string caption = "Delete";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // will auto close

            }
            else
            {

            }
        }

        private void Best_Logistic_Administrator_FormClosing(object sender, FormClosingEventArgs e)
        {

            const string message = "Are you sure that you want to logout?";
            const string caption = "Form Closing";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void Best_Logistic_Administrator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Authentication.SignOutStaff();
            Login login = new Login();
            login.Show();
        }

        private void Best_Logistic_Administrator_Load(object sender, EventArgs e)
        {
            branchId = staff.BranchId;
            radioButton6.Checked = true;

            List<string> list = new List<string>();
            list = RouteController.GetRoutesForBranch(branchId);
            
            for(int i=0; i< list.Count + 2; i++)
            {

            }

            
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateParcelDetails update = new UpdateParcelDetails();
            update.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            EndTrip endTripForm = new EndTrip();
            endTripForm.ShowDialog();
        }

        private void RegisterOnline_Click(object sender, EventArgs e)
        {
            OnlineLodge lodge = new OnlineLodge();
            lodge.ShowDialog();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Enabled = true;

            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                comboBox3.Enabled = true;
            }
            else
            {
                comboBox3.Enabled = false;
            }
        }

        

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                branchId = staff.BranchId;

                DataTable dt = ParcelController.GetAllParcelsToPickUp();
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;
                //dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            }
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                branchId = staff.BranchId;

                DataTable dt = ParcelController.GetAllRegisteredParcels(branchId);
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchId = staff.BranchId;

            if (comboBox1.SelectedIndex == 0)
            {
                DataTable dt = ParcelController.GetAllInBranchParcels(branchId, branchId);
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DataTable dt = ParcelController.GetAllInBranchParcels(branchId, null);
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                DataTable dt = ParcelController.GetAllInBranchParcels(branchId, branchId);
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;
            }
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchId = staff.BranchId;

            if (comboBox3.SelectedIndex == 0)
            {
                DataTable dt = ParcelController.GetAllOutgoingParcels(branchId, null);
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchId = staff.BranchId;

            if (comboBox2.SelectedIndex == 0)
            {
                DataTable dt = ParcelController.GetAllIncomingParcels(branchId, branchId);
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;
            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                branchId = staff.BranchId;

                DataTable dt = ParcelController.GetAllDeliveredParcels(branchId);
                DataTable dt1 = new DataTable();

                //dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");

                dataGridView1.DataSource = dt;

            }
        }

    }
}
