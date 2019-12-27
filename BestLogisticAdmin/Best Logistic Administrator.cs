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
        List<Branch> list = new List<Branch>();
        

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
            List<int> list = new List<int>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    list.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value));
                }
            }
            
            StartTrip statusPage = new StartTrip(comboBox1.Text, comboBox1.SelectedValue.ToString(), list);
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
                List<int> list = new List<int>();
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                    {
                        list.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value));
                    }
                }
                ParcelController.Delete(list);

                MessageBox.Show("Deleted Successful");

                registerHereLoad();
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

        public void registerHereLoad()
        {
            branchId = staff.BranchId;
            DataTable dt = ParcelController.GetAllRegisteredParcels(branchId);
            DataTable dt1 = new DataTable();

            dt1 = dt.DefaultView.ToTable(
                true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                "receiver_location", "receiver_postcode");

            dataGridView1.DataSource = dt1;
        }

        private void Best_Logistic_Administrator_Load(object sender, EventArgs e)
        {
            branchId = staff.BranchId;
            radioButton6.Checked = true;
 
            list = RouteController.GetRoutesForBranch(branchId);

            Dictionary <string, string> comboSource1 = new Dictionary<string, string>();
            comboSource1.Add("1", "Not Assigned");
            comboSource1.Add("2", "Pending Delivery");        
            for (int i=0; i< list.Count; i++)
            {
                comboSource1.Add(list[i].Id, list[i].Name);
            }
            comboBox1.DataSource = new BindingSource(comboSource1, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";


            Dictionary<string, string> comboSource2 = new Dictionary<string, string>();
            for (int i = 0; i < list.Count; i++)
            {
                comboSource2.Add(list[i].Id, list[i].Name);
            }
            comboBox2.DataSource = new BindingSource(comboSource2, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";


            Dictionary<string, string> comboSource3 = new Dictionary<string, string>();
            comboSource3.Add("1", "Home");
            for (int i = 0; i < list.Count; i++)
            {
                comboSource3.Add(list[i].Id, list[i].Name);
            }
            comboBox3.DataSource = new BindingSource(comboSource3, null);
            comboBox3.DisplayMember = "Value";
            comboBox3.ValueMember = "Key";

            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            comboBox3.SelectedItem = null;


            registerHereLoad();
        }

        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateParcelDetails update = new UpdateParcelDetails();
            update.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    list.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value));
                }
            }

            EndTrip endTripForm = new EndTrip(comboBox2.Text,comboBox2.SelectedValue.ToString(), list);
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
                changeRoute.Enabled = true;

            }
            else
            {
                comboBox1.Enabled = false;
                changeRoute.Enabled = false;
                changeStatus.Enabled = false;
            }
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox2.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
                button2.Enabled = false;
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
                button1.Enabled = true;

                DataTable dt = ParcelController.GetAllParcelsToPickUp();
                DataTable dt1 = new DataTable();

                dt1 = dt.DefaultView.ToTable(
                    true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                    "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                    "receiver_location", "receiver_postcode");

                dataGridView1.DataSource = dt1;
                //dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            }
            else
            {
                button1.Enabled = false;
            }
            
        }

        private void RadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                registerHereLoad();
                deleteParcel.Enabled = true;
            }
            else
            {
                deleteParcel.Enabled = false;
            }
            
        }

        //view all parcels in branch(not assigned, each route, pending delivery)
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchId = staff.BranchId;
            list = RouteController.GetRoutesForBranch(branchId);


            if (comboBox1.SelectedIndex == 0)
            {
                DataTable dt = ParcelController.GetAllInBranchParcels(branchId, branchId);
                DataTable dt1 = new DataTable();

                dt1 = dt.DefaultView.ToTable(
                    true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                    "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                    "receiver_location", "receiver_postcode");

                dataGridView1.DataSource = dt1;
                changeStatus.Enabled = false;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DataTable dt = ParcelController.GetAllInBranchParcels(branchId, null);
                DataTable dt1 = new DataTable();

                dt1 = dt.DefaultView.ToTable(
                    true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                    "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                    "receiver_location", "receiver_postcode");

                dataGridView1.DataSource = dt1;
                changeStatus.Enabled = true;
            }
            else
            {
                changeStatus.Enabled = false;
            }

            for(int i = 0; i < list.Count; i++)
            {
                int j = 2;
                if (comboBox1.SelectedIndex == j)
                {
                    
                    changeStatus.Enabled = true;
                    DataTable dt = ParcelController.GetAllInBranchParcels(branchId, list[i].Id);
                    DataTable dt1 = new DataTable();

                    dt1 = dt.DefaultView.ToTable(
                        true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                        "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                        "receiver_location", "receiver_postcode");

                    dataGridView1.DataSource = dt1;
                    
                }
                
                j++;
            }
            
        }

        //view all outgoing parcels(each route, delivery)
        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchId = staff.BranchId;
            list = RouteController.GetRoutesForBranch(branchId);

            if(comboBox3.SelectedIndex == 0)
            {
                DataTable dt = ParcelController.GetAllOutgoingParcels(branchId, null);
                DataTable dt1 = new DataTable();

                dt1 = dt.DefaultView.ToTable(
                    true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                    "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                    "receiver_location", "receiver_postcode", "plate_number");
                dataGridView1.DataSource = dt1;
            }

            for (int i = 0; i < list.Count; i++)
            {
                int j = 1;
                if (comboBox3.SelectedIndex == j)
                {
                    DataTable dt = ParcelController.GetAllOutgoingParcels(branchId, list[i].Id);
                    DataTable dt1 = new DataTable();

                    dt1 = dt.DefaultView.ToTable(
                        true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                        "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                        "receiver_location", "receiver_postcode");

                    dataGridView1.DataSource = dt1;
                   
                }
                j++;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchId = staff.BranchId;
            list = RouteController.GetRoutesForBranch(branchId);

            for (int i = 0; i < list.Count; i++)
            {
                if (comboBox2.SelectedIndex == i)
                {
                    DataTable dt = ParcelController.GetAllIncomingParcels(branchId, list[i].Id);
                    DataTable dt1 = new DataTable();

                    dt1 = dt.DefaultView.ToTable(
                        true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                        "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                        "receiver_location", "receiver_postcode");

                    dataGridView1.DataSource = dt1;
                }
                
            }
        }

        private void RadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                branchId = staff.BranchId;

                DataTable dt = ParcelController.GetAllDeliveredParcels(branchId);
                DataTable dt1 = new DataTable();

                dt1 = dt.DefaultView.ToTable(
                    true, "tracking_number", "type", "pieces", "weight", "date_created", "sender_name",
                    "sender_phone", "receiver_name", "receiver_phone", "receiver_address",
                    "receiver_location", "receiver_postcode");

                dataGridView1.DataSource = dt1;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
