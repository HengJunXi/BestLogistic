using BestLogisticAdmin.Controllers;
using BestLogisticAdmin.Models;
using BestLogisticAdmin.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TextBox = System.Windows.Forms.TextBox;

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
            
            string message = "Do you want to confirm the parcel details?";
            string caption = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                // Closes the parent form.
                this.Close();
            }
            else
            {
                int senderIDType = 0;
                if (cbIdtype.Text == "IC Number")
                {
                    senderIDType = 1;
                }
                else if (cbIdtype.Text == " Old IC Number")
                {
                    senderIDType = 2;
                }
                else
                    senderIDType = 3;

                bool parcelTypeResult;
                if (rbParcel.Checked)
                {
                    parcelTypeResult = true;
                }
                else
                    parcelTypeResult = false;

                PersonInfo sender1 = new PersonInfo(tbSenderName.Text, tbSenderEmail.Text, tbSenderContactNo.Text, tbSenderAddress.Text,
                    tbSenderPosCode.Text,cbSenderLocation.Text,tbSenderCity.Text,tbSenderState.Text);
                PersonInfo receiver1 = new PersonInfo(tbReceiverName.Text, tbReceiverEmail.Text, tbReceiverContactNo.Text, tbReceiverAddress.Text,
                    tbReceiverPosCode.Text, cbReceiverLocation.Text, tbReceiverCity.Text, tbReceiverState.Text);
                ParcelInfo parcelInfo = new ParcelInfo(false,parcelTypeResult,Convert.ToByte(tbPieces.Text),tbContent.Text,Convert.ToDecimal(tbValueofContent.Text),
                    Convert.ToSingle(tbWeight.Text),Convert.ToDecimal(price.Text),0);
                
                ParcelController.Create(Convert.ToByte(senderIDType),tbSenderidNumber.Text,sender1,receiver1,parcelInfo,Authentication.CurrentStaff.BranchId);
                MessageBox.Show("Add Success!");
            }
            
        }

        private void QuoteBtn_Click(object sender, EventArgs e)
        {

            if (!(is_tbValidate()))
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
                if (!(formatValidate()))
                {
                    string message = "Some information is in invalid format. Please check again.";
                    string caption = "Invalid Format";
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
                    ConfirmBtn.Enabled = true;
            }
        }

       private bool is_tbValidate()
        {
            bool result = true;
            var controls = new[] {
                tbSenderName,tbSenderContactNo,tbSenderEmail,tbSenderidNumber,tbSenderAddress,tbSenderCity,tbSenderPosCode,tbSenderState,
                tbReceiverName,tbReceiverContactNo,tbReceiverEmail,tbReceiverAddress,tbReceiverCity,tbReceiverState,tbReceiverPosCode,
                tbPieces,tbWeight,tbValueofContent,tbContent};

            foreach (var control in controls)
            {
                if (string.IsNullOrWhiteSpace(control.Text))
                {
                    warningEP.SetError(control, "Required");
                    result = false;
                }
                else
                {
                    warningEP.SetError(control, "");
                    result = true;

                }

                if (!(rbParcel.Checked) && !(rbDocument.Checked))
                {
                    warningEP.SetError(ParcelType, "Required");
                    result = false;
                }
                else
                {
                    warningEP.SetError(ParcelType, "");
                    result = true;
                }

                if (cbIdtype.SelectedItem == null)
                {
                    warningEP.SetError(cbIdtype, "Required");
                    result = false;
                }
                else
                {
                    warningEP.SetError(cbIdtype, "");
                    result = true;
                }

               
            }

            return result;
        }


        private bool Regexp (string re,TextBox tb)
        {
            Regex regex = new Regex(re);
            bool result;
            if (regex.IsMatch(tb.Text))
            {
                result = true;
            }
            else
            {
                //invalidEP.SetError(tb.Text, "");
                result = false;
            }
            return result;
        }

        private bool formatValidate()
        {
            bool result = true;
            var Emailcontrols = new[] { tbSenderEmail, tbReceiverEmail };
            foreach (var control in Emailcontrols)
            {
                if (Regexp(@"^[\w]+@([\w]+)\.([\w]+)$", control))
                {
                    invalidEP.SetError(control, "");
                    result = true;
                }
                else
                {
                    invalidEP.SetError(control, "Invalid");
                    result = false;
                }
               
            }
            return result;
           
        }

        //private bool PhoneValidate()
        //{
        //    bool result = true;
        //    var Phonecontrols = new[] { tbSenderContactNo, tbReceiverContactNo };
            

        //    foreach (var control in Phonecontrols)
        //    {
        //        if (Regexp(@"^([0-9]{10})$", control))
        //        {
        //            invalidEP.SetError(control, "");
        //            result = true;
        //        }
        //        else
        //        {
        //            invalidEP.SetError(control, "Invalid");
        //            result = false;
        //        }

        //    }
        //    return result;

        //}
        private void TbSenderPosCode_TextChanged(object sender, EventArgs e)
        {
            tbSenderCity.Text = "";
            tbSenderState.Text = "";
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Repository repository = new Repository();
                ArrayList arr = repository.GetAreaFromPostCode(textbox.Text);
                cbSenderLocation.DataSource = null;
                cbSenderLocation.Items.Clear();
                cbSenderLocation.Items.Insert(0, new ListItem(""));
                cbSenderLocation.DisplayMember = "FromPosCode";
                cbSenderLocation.ValueMember = "FromPosCode";
                cbSenderLocation.DataSource = arr;

                if (cbSenderLocation.SelectedValue != null)
                {
                    string[] arr1 = repository.GetCityAndStateFromPostCodeAndLocation(tbSenderPosCode.Text);
                    tbSenderCity.Text = arr1[0];
                    tbSenderState.Text = arr1[1];
                }
                
            }

        }

        
  

        private void TbReceiverPosCode_TextChanged(object sender, EventArgs e)
        {

            tbReceiverCity.Text = "";
            tbReceiverState.Text = "";
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                Repository repository = new Repository();
                ArrayList arr = repository.GetAreaFromPostCode(textbox.Text);
                cbReceiverLocation.DataSource = null;
                cbReceiverLocation.Items.Clear();
                cbReceiverLocation.Items.Insert(0, new ListItem(""));
                cbReceiverLocation.DisplayMember = "ToPosCode";
                cbReceiverLocation.ValueMember = "ToPosCode";
                cbReceiverLocation.DataSource = arr;

                if (cbReceiverLocation.SelectedValue != null)
                {
                    string[] arr1 = repository.GetCityAndStateFromPostCodeAndLocation(tbReceiverPosCode.Text);
                    tbReceiverCity.Text = arr1[0];
                    tbReceiverState.Text = arr1[1];
                }

            }
            
        }

        private void TbPieces_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void TbWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TbValueofContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void TbContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }
    }
}
