using BestLogisticAdmin.Controllers;
using BestLogisticAdmin.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BestLogisticAdmin
{
    public partial class UpdateParcelDetails : Form
    {
        int trackNo;
        Best_Logistic_Administrator admin;
        public UpdateParcelDetails(Best_Logistic_Administrator admin, int trackingNo)
        {
            InitializeComponent();
            trackNo = trackingNo;
            this.admin = admin;   
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
                PersonInfo senderUpdated = new PersonInfo(tbSenderName.Text,tbSenderEmail.Text,tbSenderContactNo.Text,tbSenderAddress.Text,
                    tbSenderPosCode.Text,cbSenderLocation.Text,tbSenderCity.Text,tbSenderState.Text);
                PersonInfo receiverUpdated = new PersonInfo(tbReceiverName.Text,tbReceiverEmail.Text,tbReceiverContactNo.Text,tbReceiverAddress.Text,
                    tbReceiverPosCode.Text,cbReceiverLocation.Text,tbReceiverCity.Text,tbReceiverState.Text);
                ParcelController.Update(trackNo,Convert.ToByte((cbIdtype.SelectedIndex)+1),idNumber.Text,senderUpdated,receiverUpdated);
                MessageBox.Show("Update Success!");
                // cancel the closure of the form.
                this.Close();
                admin.registerHereLoad();
            }


        }

        private void UpdateParcelDetails_Load(object sender, EventArgs e)
        {
            DataTable result = ParcelController.Get(trackNo);
            tbSenderName.Text = result.Rows[0].Field<string>(11);
            tbSenderContactNo.Text = result.Rows[0].Field<string>(14);
            cbIdtype.SelectedIndex = result.Rows[0].Field<byte>(12) - 1;
            idNumber.Text = result.Rows[0].Field<string>(13);
            tbSenderEmail.Text = result.Rows[0].Field<string>(15);
            tbSenderAddress.Text = result.Rows[0].Field<string>(16);
            tbSenderPosCode.Text = result.Rows[0].Field<string>(18);
            cbSenderLocation.Text = result.Rows[0].Field<string>(17);


            tbReceiverName.Text = result.Rows[0].Field<string>(19);
            tbReceiverContactNo.Text = result.Rows[0].Field<string>(20);
            tbReceiverEmail.Text = result.Rows[0].Field<string>(21);
            tbReceiverAddress.Text = result.Rows[0].Field<string>(22);
            tbReceiverPosCode.Text = result.Rows[0].Field<string>(24);
            cbReceiverLocation.Text = result.Rows[0].Field<string>(23);

            if (result.Rows[0].Field<bool>(2) == false)
            {
                rbParcel.Checked = true;
            }
            else
                rbDocument.Checked = true;

            tbPieces.Text = result.Rows[0].Field<byte>(3).ToString();
            tbContent.Text = result.Rows[0].Field<string>(4);
            tbValueofContent.Text = result.Rows[0].Field<decimal>(5).ToString();
            tbWeight.Text = result.Rows[0].Field<float>(6).ToString();
        }

        private void TbSenderPosCode_TextChanged(object sender, EventArgs e)
        {
            tbSenderCity.Text = "";
            tbSenderState.Text = "";
            System.Windows.Forms.TextBox textbox = sender as System.Windows.Forms.TextBox;
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
            System.Windows.Forms.TextBox textbox = sender as System.Windows.Forms.TextBox;
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



    }
}
