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
    public partial class OnlineLodge : Form
    {
        public String branchId;
        Staff staff = Authentication.CurrentStaff;
        public OnlineLodge()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            branchId = staff.BranchId;
            int trackingNum = Convert.ToInt32(textBox1.Text);

            ParcelController.RegisterOnlineLodgeIn(trackingNum, branchId);

            MessageBox.Show("Successful Added");
            textBox1.Text = "";
        }
    }
}
