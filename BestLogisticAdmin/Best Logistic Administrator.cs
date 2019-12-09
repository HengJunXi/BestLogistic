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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            Staff staff = Authentication.CurrentStaff;
            branchId = staff.BranchId;

            DataTable dt = Parcel.GetParcelsFromBranch(branchId);
            DataTable dt1 = new DataTable();

            dt1 = dt.DefaultView.ToTable(true, "tracking_number", "receiver_address");
            
            dataGridView1.DataSource = dt1;
            //dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn());
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateParcelDetails update = new UpdateParcelDetails();
            update.ShowDialog();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox3.Enabled = false;
            }
        }

        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
                
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                comboBox3.Enabled = true;
            }
            
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

        private void Button1_Click(object sender, EventArgs e)
        {
            OnlinePickUpRequest pickUpRequest = new OnlinePickUpRequest();
            pickUpRequest.ShowDialog();
        }
    }
}
