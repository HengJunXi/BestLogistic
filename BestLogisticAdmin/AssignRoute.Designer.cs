namespace BestLogisticAdmin
{
    partial class AssignRoute
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
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.dbroute = new System.Windows.Forms.ComboBox();
            this.route = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBtn.Location = new System.Drawing.Point(361, 273);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(2);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(70, 30);
            this.ConfirmBtn.TabIndex = 17;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // dbroute
            // 
            this.dbroute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbroute.Enabled = false;
            this.dbroute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbroute.FormattingEnabled = true;
            this.dbroute.ItemHeight = 25;
            this.dbroute.Location = new System.Drawing.Point(138, 163);
            this.dbroute.Margin = new System.Windows.Forms.Padding(2);
            this.dbroute.Name = "dbroute";
            this.dbroute.Size = new System.Drawing.Size(221, 33);
            this.dbroute.TabIndex = 16;
            // 
            // route
            // 
            this.route.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.route.AutoSize = true;
            this.route.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.route.Location = new System.Drawing.Point(133, 98);
            this.route.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.route.Name = "route";
            this.route.Size = new System.Drawing.Size(223, 31);
            this.route.TabIndex = 15;
            this.route.Text = "Assign Route To:";
            // 
            // AssignRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(504, 361);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.dbroute);
            this.Controls.Add(this.route);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(520, 400);
            this.Name = "AssignRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "changeRoute";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.ComboBox dbroute;
        private System.Windows.Forms.Label route;
    }
}