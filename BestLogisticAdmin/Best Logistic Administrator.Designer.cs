namespace BestLogisticAdmin
{
    partial class Best_Logistic_Administrator
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
            this.add = new System.Windows.Forms.Button();
            this.changeStatus = new System.Windows.Forms.Button();
            this.changeRoute = new System.Windows.Forms.Button();
            this.deleteParcel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.add.AutoSize = true;
            this.add.Location = new System.Drawing.Point(87, 12);
            this.add.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.add.MaximumSize = new System.Drawing.Size(150, 25);
            this.add.MinimumSize = new System.Drawing.Size(100, 25);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(100, 25);
            this.add.TabIndex = 0;
            this.add.Text = "Add new parcel";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // changeStatus
            // 
            this.changeStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.changeStatus.AutoSize = true;
            this.changeStatus.Location = new System.Drawing.Point(290, 12);
            this.changeStatus.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.changeStatus.MaximumSize = new System.Drawing.Size(150, 25);
            this.changeStatus.MinimumSize = new System.Drawing.Size(100, 25);
            this.changeStatus.Name = "changeStatus";
            this.changeStatus.Size = new System.Drawing.Size(100, 25);
            this.changeStatus.TabIndex = 1;
            this.changeStatus.Text = "Change status";
            this.changeStatus.UseVisualStyleBackColor = true;
            this.changeStatus.Click += new System.EventHandler(this.ChangeStatus_Click);
            // 
            // changeRoute
            // 
            this.changeRoute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.changeRoute.AutoSize = true;
            this.changeRoute.Location = new System.Drawing.Point(493, 12);
            this.changeRoute.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.changeRoute.MaximumSize = new System.Drawing.Size(150, 25);
            this.changeRoute.MinimumSize = new System.Drawing.Size(100, 25);
            this.changeRoute.Name = "changeRoute";
            this.changeRoute.Size = new System.Drawing.Size(100, 25);
            this.changeRoute.TabIndex = 2;
            this.changeRoute.Text = "Change Route";
            this.changeRoute.UseVisualStyleBackColor = true;
            this.changeRoute.Click += new System.EventHandler(this.changeRoute_Click);
            // 
            // deleteParcel
            // 
            this.deleteParcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deleteParcel.AutoSize = true;
            this.deleteParcel.Location = new System.Drawing.Point(696, 12);
            this.deleteParcel.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
            this.deleteParcel.MaximumSize = new System.Drawing.Size(150, 25);
            this.deleteParcel.MinimumSize = new System.Drawing.Size(100, 25);
            this.deleteParcel.Name = "deleteParcel";
            this.deleteParcel.Size = new System.Drawing.Size(100, 25);
            this.deleteParcel.TabIndex = 3;
            this.deleteParcel.Text = "Delete Parcel";
            this.deleteParcel.UseVisualStyleBackColor = true;
            this.deleteParcel.Click += new System.EventHandler(this.DeleteParcel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(860, 363);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Pending",
            "Pick Up",
            "Transiting",
            "Coming In",
            "Delivering",
            "Delivered"});
            this.checkedListBox1.Location = new System.Drawing.Point(12, 463);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(860, 23);
            this.checkedListBox1.TabIndex = 5;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox1_SelectedIndexChanged);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "Home",
            "Route 1",
            "Route 2",
            "Route 3",
            "Route 4"});
            this.checkedListBox2.Location = new System.Drawing.Point(12, 501);
            this.checkedListBox2.MultiColumn = true;
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(860, 23);
            this.checkedListBox2.TabIndex = 6;
            this.checkedListBox2.SelectedIndexChanged += new System.EventHandler(this.CheckedListBox2_SelectedIndexChanged);
            // 
            // Best_Logistic_Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 536);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deleteParcel);
            this.Controls.Add(this.changeRoute);
            this.Controls.Add(this.changeStatus);
            this.Controls.Add(this.add);
            this.MinimumSize = new System.Drawing.Size(900, 575);
            this.Name = "Best_Logistic_Administrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Best_Logistic_Administrator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button changeStatus;
        private System.Windows.Forms.Button changeRoute;
        private System.Windows.Forms.Button deleteParcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
    }
}