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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Staff staff = Authentication.SignInStaff(Convert.ToInt32(tbUsername.Text), tbPassword.Text);

            if(staff == null)
            {
                MessageBox.Show("Username and Password are incorrent");
            }
            else
            {
                this.Hide();
                Best_Logistic_Administrator main_form = new Best_Logistic_Administrator();
                main_form.ShowDialog();
                this.Close();
            }

            
            
        }
    }
}
