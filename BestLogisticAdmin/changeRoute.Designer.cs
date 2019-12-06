namespace BestLogisticAdmin
{
    partial class changeRoute
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
            this.ConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBtn.Location = new System.Drawing.Point(481, 336);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(93, 37);
            this.ConfirmBtn.TabIndex = 17;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            // 
            // dbroute
            // 
            this.dbroute.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbroute.FormattingEnabled = true;
            this.dbroute.ItemHeight = 29;
            this.dbroute.Location = new System.Drawing.Point(184, 201);
            this.dbroute.Name = "dbroute";
            this.dbroute.Size = new System.Drawing.Size(293, 37);
            this.dbroute.TabIndex = 16;
            // 
            // route
            // 
            this.route.AutoSize = true;
            this.route.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.route.Location = new System.Drawing.Point(177, 121);
            this.route.Name = "route";
            this.route.Size = new System.Drawing.Size(295, 39);
            this.route.TabIndex = 15;
            this.route.Text = "Change Route To:";
            // 
            // changeRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(676, 450);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.dbroute);
            this.Controls.Add(this.route);
            this.Name = "changeRoute";
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