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
            this.checkAll = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.registerOnline = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // add
            // 
            this.add.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.add.AutoSize = true;
            this.add.Location = new System.Drawing.Point(115, 12);
            this.add.Margin = new System.Windows.Forms.Padding(3, 3, 75, 3);
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
            this.changeStatus.Enabled = false;
            this.changeStatus.Location = new System.Drawing.Point(293, 43);
            this.changeStatus.Margin = new System.Windows.Forms.Padding(3, 3, 75, 3);
            this.changeStatus.MaximumSize = new System.Drawing.Size(150, 25);
            this.changeStatus.MinimumSize = new System.Drawing.Size(100, 25);
            this.changeStatus.Name = "changeStatus";
            this.changeStatus.Size = new System.Drawing.Size(127, 25);
            this.changeStatus.TabIndex = 1;
            this.changeStatus.Text = "Start trip";
            this.changeStatus.UseVisualStyleBackColor = true;
            this.changeStatus.Click += new System.EventHandler(this.ChangeStatus_Click);
            // 
            // changeRoute
            // 
            this.changeRoute.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.changeRoute.AutoSize = true;
            this.changeRoute.Enabled = false;
            this.changeRoute.Location = new System.Drawing.Point(115, 43);
            this.changeRoute.Margin = new System.Windows.Forms.Padding(3, 3, 75, 3);
            this.changeRoute.MaximumSize = new System.Drawing.Size(150, 25);
            this.changeRoute.MinimumSize = new System.Drawing.Size(100, 25);
            this.changeRoute.Name = "changeRoute";
            this.changeRoute.Size = new System.Drawing.Size(100, 25);
            this.changeRoute.TabIndex = 2;
            this.changeRoute.Text = "Assign Route";
            this.changeRoute.UseVisualStyleBackColor = true;
            this.changeRoute.Click += new System.EventHandler(this.changeRoute_Click);
            // 
            // deleteParcel
            // 
            this.deleteParcel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.deleteParcel.AutoSize = true;
            this.deleteParcel.Enabled = false;
            this.deleteParcel.Location = new System.Drawing.Point(695, 12);
            this.deleteParcel.Margin = new System.Windows.Forms.Padding(3, 3, 75, 3);
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
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkAll});
            this.dataGridView1.Location = new System.Drawing.Point(12, 178);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(860, 363);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseDoubleClick);
            // 
            // checkAll
            // 
            this.checkAll.HeaderText = " ";
            this.checkAll.Name = "checkAll";
            // 
            // registerOnline
            // 
            this.registerOnline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.registerOnline.AutoSize = true;
            this.registerOnline.Location = new System.Drawing.Point(293, 12);
            this.registerOnline.Margin = new System.Windows.Forms.Padding(3, 3, 75, 3);
            this.registerOnline.MaximumSize = new System.Drawing.Size(150, 25);
            this.registerOnline.MinimumSize = new System.Drawing.Size(100, 25);
            this.registerOnline.Name = "registerOnline";
            this.registerOnline.Size = new System.Drawing.Size(127, 25);
            this.registerOnline.TabIndex = 7;
            this.registerOnline.Text = "Register online lodge in";
            this.registerOnline.UseVisualStyleBackColor = true;
            this.registerOnline.Click += new System.EventHandler(this.RegisterOnline_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.AutoSize = true;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(498, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 75, 3);
            this.button1.MaximumSize = new System.Drawing.Size(150, 25);
            this.button1.MinimumSize = new System.Drawing.Size(100, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 25);
            this.button1.TabIndex = 8;
            this.button1.Text = "Register pick up";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.AutoSize = true;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(498, 43);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 3, 75, 3);
            this.button2.MaximumSize = new System.Drawing.Size(150, 25);
            this.button2.MinimumSize = new System.Drawing.Size(100, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "End trip";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(17, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(855, 98);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(120, 30);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(100, 17);
            this.radioButton6.TabIndex = 8;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Registered here";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.RadioButton6_CheckedChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Home",
            "Route 1",
            "Route 2",
            "Route 3"});
            this.comboBox3.Location = new System.Drawing.Point(603, 53);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(127, 21);
            this.comboBox3.TabIndex = 7;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(432, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(127, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(265, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(754, 30);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(70, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "Delivered";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.RadioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(603, 30);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(68, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Outgoing";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.RadioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(432, 30);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(68, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Incoming";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(265, 30);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(70, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "In branch";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(28, 30);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 3, 50, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Pick up";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
            // 
            // Best_Logistic_Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.registerOnline);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.deleteParcel);
            this.Controls.Add(this.changeRoute);
            this.Controls.Add(this.changeStatus);
            this.Controls.Add(this.add);
            this.MinimumSize = new System.Drawing.Size(900, 575);
            this.Name = "Best_Logistic_Administrator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Best_Logistic_Administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Best_Logistic_Administrator_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Best_Logistic_Administrator_FormClosed);
            this.Load += new System.EventHandler(this.Best_Logistic_Administrator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button changeStatus;
        private System.Windows.Forms.Button changeRoute;
        private System.Windows.Forms.Button deleteParcel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkAll;
        private System.Windows.Forms.Button registerOnline;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
    }
}