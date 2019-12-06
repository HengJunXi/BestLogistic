namespace BestLogisticAdmin
{
    partial class ChangeStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.status = new System.Windows.Forms.Label();
            this.dbstatus = new System.Windows.Forms.ComboBox();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.Location = new System.Drawing.Point(178, 120);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(300, 39);
            this.status.TabIndex = 0;
            this.status.Text = "Change Status To:";
            // 
            // dbstatus
            // 
            this.dbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbstatus.FormattingEnabled = true;
            this.dbstatus.ItemHeight = 29;
            this.dbstatus.Location = new System.Drawing.Point(185, 200);
            this.dbstatus.Name = "dbstatus";
            this.dbstatus.Size = new System.Drawing.Size(293, 37);
            this.dbstatus.TabIndex = 1;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBtn.Location = new System.Drawing.Point(482, 335);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(93, 37);
            this.ConfirmBtn.TabIndex = 14;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            // 
            // ChangeStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(676, 450);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.dbstatus);
            this.Controls.Add(this.status);
            this.Name = "ChangeStatus";
            this.Text = "ChangeStatus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label status;
        private System.Windows.Forms.ComboBox dbstatus;
        private System.Windows.Forms.Button ConfirmBtn;
    }
}