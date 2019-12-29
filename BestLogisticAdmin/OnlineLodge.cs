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
        Best_Logistic_Administrator home;
        public OnlineLodge(Best_Logistic_Administrator home)
        {
            InitializeComponent();
            this.home = home;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            branchId = staff.BranchId;
            int trackingNum = Convert.ToInt32(textBox1.Text);

            if (ParcelController.RegisterOnlineLodgeIn(trackingNum, branchId) == true)
            {
                MessageBox.Show("Successful Added");
                textBox1.Text = "";
                home.registerHereLoad();
            }
            else
            {
                MessageBox.Show("Fail to add, please check again the tracking number");
                textBox1.Text = "";
            }

            
            
        }
    }
}
