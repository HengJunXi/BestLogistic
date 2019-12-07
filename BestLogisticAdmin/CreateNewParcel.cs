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
    public partial class CreateNewParcel : Form
    {
        public CreateNewParcel()
        {
            InitializeComponent();
        }

        private void SenderContactNo_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("Add Success!");
        }

        private void QuoteBtn_Click(object sender, EventArgs e)
        {
            if (tbSenderName.Text.Length == 0)
            {
                // Initializes the variables to pass to the MessageBox.Show method.
                string message = "Some information is missing. Please check again the form.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    // Closes the parent form.
                    this.Close();
                }
            }
            else
            {
                
                ConfirmBtn.Enabled = true;
            }
        }
    }
}
