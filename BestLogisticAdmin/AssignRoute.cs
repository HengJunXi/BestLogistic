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
        public AssignRoute()
        {
            InitializeComponent();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            const string message = "Confirm change route? ";
            const string caption = "Change Route";
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
    }
}
