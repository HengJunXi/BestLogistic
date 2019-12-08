using BestLogisticAdmin.Controllers;
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
        public Best_Logistic_Administrator()
        {
            InitializeComponent();
        }

        private void changeRoute_Click(object sender, EventArgs e)
        {
            changeRoute routePage = new changeRoute();
            routePage.ShowDialog();
        }

        private void add_Click(object sender, EventArgs e)
        {
            CreateNewParcel addPage = new CreateNewParcel();
            addPage.ShowDialog();
        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            ChangeStatus statusPage = new ChangeStatus();
            statusPage.ShowDialog();
        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.ClearSelected();
        }

        private void CheckedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox2.ClearSelected();
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
                // cancel the closure of the form.
                this.Close();
            }
            else
            {
                this.Close();
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
            //dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn());
        }
    }
}
