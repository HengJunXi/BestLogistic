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
    public partial class UpdateParcelDetails : Form
    {
        public UpdateParcelDetails()
        {
            InitializeComponent();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            const string message = "Are you confirm to update the parcel infomation? ";
            const string caption = "Update Information";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Update Success!");
                // cancel the closure of the form.
                this.Close();
            }
            
            
        }
    }
}
