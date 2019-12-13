namespace BestLogisticAdmin
{
    partial class CreateNewParcel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewParcel));
            this.SenderDetails = new System.Windows.Forms.GroupBox();
            this.cbSenderLocation = new System.Windows.Forms.ComboBox();
            this.tbSenderidNumber = new System.Windows.Forms.TextBox();
            this.IdNo = new System.Windows.Forms.Label();
            this.cbIdtype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSenderState = new System.Windows.Forms.TextBox();
            this.SenderPosCode = new System.Windows.Forms.Label();
            this.tbSenderAddress = new System.Windows.Forms.TextBox();
            this.tbSenderContactNo = new System.Windows.Forms.TextBox();
            this.SenderState = new System.Windows.Forms.Label();
            this.SenderCity = new System.Windows.Forms.Label();
            this.SenderLocation = new System.Windows.Forms.Label();
            this.tbSenderCity = new System.Windows.Forms.TextBox();
            this.tbSenderPosCode = new System.Windows.Forms.TextBox();
            this.tbSenderEmail = new System.Windows.Forms.TextBox();
            this.tbSenderName = new System.Windows.Forms.TextBox();
            this.SenderAddress = new System.Windows.Forms.Label();
            this.SenderEmail = new System.Windows.Forms.Label();
            this.SenderContactNo = new System.Windows.Forms.Label();
            this.SenderName = new System.Windows.Forms.Label();
            this.ReceiverDetails = new System.Windows.Forms.GroupBox();
            this.cbReceiverLocation = new System.Windows.Forms.ComboBox();
            this.tbReceiverState = new System.Windows.Forms.TextBox();
            this.ReceiverPosCode = new System.Windows.Forms.Label();
            this.tbReceiverAddress = new System.Windows.Forms.TextBox();
            this.tbReceiverContactNo = new System.Windows.Forms.TextBox();
            this.ReceiverState = new System.Windows.Forms.Label();
            this.ReceiverCity = new System.Windows.Forms.Label();
            this.ReceiverLocation = new System.Windows.Forms.Label();
            this.tbReceiverCity = new System.Windows.Forms.TextBox();
            this.tbReceiverPosCode = new System.Windows.Forms.TextBox();
            this.tbReceiverEmail = new System.Windows.Forms.TextBox();
            this.tbReceiverName = new System.Windows.Forms.TextBox();
            this.ReceiverAddress = new System.Windows.Forms.Label();
            this.ReceiverEmail = new System.Windows.Forms.Label();
            this.ReceiverContactNo = new System.Windows.Forms.Label();
            this.ReceiverName = new System.Windows.Forms.Label();
            this.ParcelDetails = new System.Windows.Forms.GroupBox();
            this.rbDocument = new System.Windows.Forms.RadioButton();
            this.rbParcel = new System.Windows.Forms.RadioButton();
            this.tbWeight = new System.Windows.Forms.TextBox();
            this.ValueofContent = new System.Windows.Forms.Label();
            this.tbContent = new System.Windows.Forms.TextBox();
            this.weight = new System.Windows.Forms.Label();
            this.tbValueofContent = new System.Windows.Forms.TextBox();
            this.tbPieces = new System.Windows.Forms.TextBox();
            this.Content = new System.Windows.Forms.Label();
            this.Pieces = new System.Windows.Forms.Label();
            this.ParcelType = new System.Windows.Forms.Label();
            this.QuoteBtn = new System.Windows.Forms.Button();
            this.totalPrice = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.Label();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.warningEP = new System.Windows.Forms.ErrorProvider(this.components);
            this.invalidEP = new System.Windows.Forms.ErrorProvider(this.components);
            this.SenderDetails.SuspendLayout();
            this.ReceiverDetails.SuspendLayout();
            this.ParcelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningEP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invalidEP)).BeginInit();
            this.SuspendLayout();
            // 
            // SenderDetails
            // 
            this.SenderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SenderDetails.Controls.Add(this.cbSenderLocation);
            this.SenderDetails.Controls.Add(this.tbSenderidNumber);
            this.SenderDetails.Controls.Add(this.IdNo);
            this.SenderDetails.Controls.Add(this.cbIdtype);
            this.SenderDetails.Controls.Add(this.label1);
            this.SenderDetails.Controls.Add(this.tbSenderState);
            this.SenderDetails.Controls.Add(this.SenderPosCode);
            this.SenderDetails.Controls.Add(this.tbSenderAddress);
            this.SenderDetails.Controls.Add(this.tbSenderContactNo);
            this.SenderDetails.Controls.Add(this.SenderState);
            this.SenderDetails.Controls.Add(this.SenderCity);
            this.SenderDetails.Controls.Add(this.SenderLocation);
            this.SenderDetails.Controls.Add(this.tbSenderCity);
            this.SenderDetails.Controls.Add(this.tbSenderPosCode);
            this.SenderDetails.Controls.Add(this.tbSenderEmail);
            this.SenderDetails.Controls.Add(this.tbSenderName);
            this.SenderDetails.Controls.Add(this.SenderAddress);
            this.SenderDetails.Controls.Add(this.SenderEmail);
            this.SenderDetails.Controls.Add(this.SenderContactNo);
            this.SenderDetails.Controls.Add(this.SenderName);
            this.SenderDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderDetails.Location = new System.Drawing.Point(39, 28);
            this.SenderDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SenderDetails.Name = "SenderDetails";
            this.SenderDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SenderDetails.Size = new System.Drawing.Size(1211, 302);
            this.SenderDetails.TabIndex = 6;
            this.SenderDetails.TabStop = false;
            this.SenderDetails.Text = "Sender Details";
            // 
            // cbSenderLocation
            // 
            this.cbSenderLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSenderLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSenderLocation.FormattingEnabled = true;
            this.cbSenderLocation.Location = new System.Drawing.Point(712, 197);
            this.cbSenderLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSenderLocation.MaximumSize = new System.Drawing.Size(425, 0);
            this.cbSenderLocation.MinimumSize = new System.Drawing.Size(425, 0);
            this.cbSenderLocation.Name = "cbSenderLocation";
            this.cbSenderLocation.Size = new System.Drawing.Size(425, 24);
            this.cbSenderLocation.TabIndex = 20;
            this.cbSenderLocation.Text = "Postal Code is required";
            // 
            // tbSenderidNumber
            // 
            this.tbSenderidNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderidNumber.Location = new System.Drawing.Point(746, 97);
            this.tbSenderidNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderidNumber.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderidNumber.Name = "tbSenderidNumber";
            this.tbSenderidNumber.Size = new System.Drawing.Size(425, 23);
            this.tbSenderidNumber.TabIndex = 19;
            // 
            // IdNo
            // 
            this.IdNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.IdNo.AutoSize = true;
            this.IdNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdNo.Location = new System.Drawing.Point(610, 100);
            this.IdNo.MaximumSize = new System.Drawing.Size(425, 23);
            this.IdNo.Name = "IdNo";
            this.IdNo.Size = new System.Drawing.Size(56, 20);
            this.IdNo.TabIndex = 18;
            this.IdNo.Text = "ID No.";
            // 
            // cbIdtype
            // 
            this.cbIdtype.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbIdtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdtype.FormattingEnabled = true;
            this.cbIdtype.Items.AddRange(new object[] {
            "IC Number",
            "Old IC Number",
            "Passport"});
            this.cbIdtype.Location = new System.Drawing.Point(157, 96);
            this.cbIdtype.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIdtype.MaximumSize = new System.Drawing.Size(425, 0);
            this.cbIdtype.Name = "cbIdtype";
            this.cbIdtype.Size = new System.Drawing.Size(378, 24);
            this.cbIdtype.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "ID Type";
            // 
            // tbSenderState
            // 
            this.tbSenderState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderState.Location = new System.Drawing.Point(746, 244);
            this.tbSenderState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderState.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderState.Name = "tbSenderState";
            this.tbSenderState.Size = new System.Drawing.Size(425, 23);
            this.tbSenderState.TabIndex = 15;
            // 
            // SenderPosCode
            // 
            this.SenderPosCode.AutoSize = true;
            this.SenderPosCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderPosCode.Location = new System.Drawing.Point(21, 198);
            this.SenderPosCode.Name = "SenderPosCode";
            this.SenderPosCode.Size = new System.Drawing.Size(100, 20);
            this.SenderPosCode.TabIndex = 8;
            this.SenderPosCode.Text = "Postal Code";
            // 
            // tbSenderAddress
            // 
            this.tbSenderAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderAddress.Location = new System.Drawing.Point(746, 148);
            this.tbSenderAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderAddress.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderAddress.Name = "tbSenderAddress";
            this.tbSenderAddress.Size = new System.Drawing.Size(425, 23);
            this.tbSenderAddress.TabIndex = 13;
            // 
            // tbSenderContactNo
            // 
            this.tbSenderContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderContactNo.Location = new System.Drawing.Point(746, 52);
            this.tbSenderContactNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderContactNo.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderContactNo.Name = "tbSenderContactNo";
            this.tbSenderContactNo.Size = new System.Drawing.Size(425, 23);
            this.tbSenderContactNo.TabIndex = 12;
            // 
            // SenderState
            // 
            this.SenderState.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SenderState.AutoSize = true;
            this.SenderState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderState.Location = new System.Drawing.Point(610, 247);
            this.SenderState.MaximumSize = new System.Drawing.Size(425, 23);
            this.SenderState.Name = "SenderState";
            this.SenderState.Size = new System.Drawing.Size(48, 20);
            this.SenderState.TabIndex = 11;
            this.SenderState.Text = "State";
            // 
            // SenderCity
            // 
            this.SenderCity.AutoSize = true;
            this.SenderCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderCity.Location = new System.Drawing.Point(21, 247);
            this.SenderCity.Name = "SenderCity";
            this.SenderCity.Size = new System.Drawing.Size(38, 20);
            this.SenderCity.TabIndex = 10;
            this.SenderCity.Text = "City";
            // 
            // SenderLocation
            // 
            this.SenderLocation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SenderLocation.AutoSize = true;
            this.SenderLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderLocation.Location = new System.Drawing.Point(610, 201);
            this.SenderLocation.MaximumSize = new System.Drawing.Size(425, 23);
            this.SenderLocation.Name = "SenderLocation";
            this.SenderLocation.Size = new System.Drawing.Size(73, 20);
            this.SenderLocation.TabIndex = 9;
            this.SenderLocation.Text = "Location";
            // 
            // tbSenderCity
            // 
            this.tbSenderCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderCity.Location = new System.Drawing.Point(157, 244);
            this.tbSenderCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderCity.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderCity.Name = "tbSenderCity";
            this.tbSenderCity.Size = new System.Drawing.Size(378, 23);
            this.tbSenderCity.TabIndex = 7;
            // 
            // tbSenderPosCode
            // 
            this.tbSenderPosCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderPosCode.Location = new System.Drawing.Point(157, 198);
            this.tbSenderPosCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderPosCode.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderPosCode.Name = "tbSenderPosCode";
            this.tbSenderPosCode.Size = new System.Drawing.Size(378, 23);
            this.tbSenderPosCode.TabIndex = 6;
            this.tbSenderPosCode.TextChanged += new System.EventHandler(this.TbSenderPosCode_TextChanged);
            // 
            // tbSenderEmail
            // 
            this.tbSenderEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderEmail.Location = new System.Drawing.Point(157, 148);
            this.tbSenderEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderEmail.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderEmail.Name = "tbSenderEmail";
            this.tbSenderEmail.Size = new System.Drawing.Size(378, 23);
            this.tbSenderEmail.TabIndex = 5;
            // 
            // tbSenderName
            // 
            this.tbSenderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSenderName.Location = new System.Drawing.Point(157, 52);
            this.tbSenderName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSenderName.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbSenderName.Name = "tbSenderName";
            this.tbSenderName.Size = new System.Drawing.Size(378, 23);
            this.tbSenderName.TabIndex = 4;
            // 
            // SenderAddress
            // 
            this.SenderAddress.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SenderAddress.AutoSize = true;
            this.SenderAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderAddress.Location = new System.Drawing.Point(610, 154);
            this.SenderAddress.MaximumSize = new System.Drawing.Size(425, 23);
            this.SenderAddress.Name = "SenderAddress";
            this.SenderAddress.Size = new System.Drawing.Size(71, 20);
            this.SenderAddress.TabIndex = 3;
            this.SenderAddress.Text = "Address";
            // 
            // SenderEmail
            // 
            this.SenderEmail.AutoSize = true;
            this.SenderEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderEmail.Location = new System.Drawing.Point(21, 148);
            this.SenderEmail.Name = "SenderEmail";
            this.SenderEmail.Size = new System.Drawing.Size(51, 20);
            this.SenderEmail.TabIndex = 2;
            this.SenderEmail.Text = "Email";
            // 
            // SenderContactNo
            // 
            this.SenderContactNo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SenderContactNo.AutoSize = true;
            this.SenderContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderContactNo.Location = new System.Drawing.Point(610, 55);
            this.SenderContactNo.MaximumSize = new System.Drawing.Size(425, 23);
            this.SenderContactNo.Name = "SenderContactNo";
            this.SenderContactNo.Size = new System.Drawing.Size(97, 20);
            this.SenderContactNo.TabIndex = 1;
            this.SenderContactNo.Text = "Contact No.";
            this.SenderContactNo.LocationChanged += new System.EventHandler(this.SenderContactNo_LocationChanged);
            // 
            // SenderName
            // 
            this.SenderName.AutoSize = true;
            this.SenderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderName.Location = new System.Drawing.Point(21, 52);
            this.SenderName.Name = "SenderName";
            this.SenderName.Size = new System.Drawing.Size(53, 20);
            this.SenderName.TabIndex = 0;
            this.SenderName.Text = "Name";
            // 
            // ReceiverDetails
            // 
            this.ReceiverDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiverDetails.Controls.Add(this.cbReceiverLocation);
            this.ReceiverDetails.Controls.Add(this.tbReceiverState);
            this.ReceiverDetails.Controls.Add(this.ReceiverPosCode);
            this.ReceiverDetails.Controls.Add(this.tbReceiverAddress);
            this.ReceiverDetails.Controls.Add(this.tbReceiverContactNo);
            this.ReceiverDetails.Controls.Add(this.ReceiverState);
            this.ReceiverDetails.Controls.Add(this.ReceiverCity);
            this.ReceiverDetails.Controls.Add(this.ReceiverLocation);
            this.ReceiverDetails.Controls.Add(this.tbReceiverCity);
            this.ReceiverDetails.Controls.Add(this.tbReceiverPosCode);
            this.ReceiverDetails.Controls.Add(this.tbReceiverEmail);
            this.ReceiverDetails.Controls.Add(this.tbReceiverName);
            this.ReceiverDetails.Controls.Add(this.ReceiverAddress);
            this.ReceiverDetails.Controls.Add(this.ReceiverEmail);
            this.ReceiverDetails.Controls.Add(this.ReceiverContactNo);
            this.ReceiverDetails.Controls.Add(this.ReceiverName);
            this.ReceiverDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverDetails.Location = new System.Drawing.Point(39, 353);
            this.ReceiverDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReceiverDetails.Name = "ReceiverDetails";
            this.ReceiverDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReceiverDetails.Size = new System.Drawing.Size(1211, 254);
            this.ReceiverDetails.TabIndex = 7;
            this.ReceiverDetails.TabStop = false;
            this.ReceiverDetails.Text = "Receiver Details";
            // 
            // cbReceiverLocation
            // 
            this.cbReceiverLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReceiverLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbReceiverLocation.FormattingEnabled = true;
            this.cbReceiverLocation.Location = new System.Drawing.Point(712, 149);
            this.cbReceiverLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbReceiverLocation.MaximumSize = new System.Drawing.Size(425, 0);
            this.cbReceiverLocation.MinimumSize = new System.Drawing.Size(425, 0);
            this.cbReceiverLocation.Name = "cbReceiverLocation";
            this.cbReceiverLocation.Size = new System.Drawing.Size(425, 24);
            this.cbReceiverLocation.TabIndex = 21;
            this.cbReceiverLocation.Text = "Postal Code is required";
            // 
            // tbReceiverState
            // 
            this.tbReceiverState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverState.Location = new System.Drawing.Point(746, 204);
            this.tbReceiverState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReceiverState.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbReceiverState.Name = "tbReceiverState";
            this.tbReceiverState.Size = new System.Drawing.Size(425, 23);
            this.tbReceiverState.TabIndex = 15;
            // 
            // ReceiverPosCode
            // 
            this.ReceiverPosCode.AutoSize = true;
            this.ReceiverPosCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverPosCode.Location = new System.Drawing.Point(21, 156);
            this.ReceiverPosCode.Name = "ReceiverPosCode";
            this.ReceiverPosCode.Size = new System.Drawing.Size(100, 20);
            this.ReceiverPosCode.TabIndex = 8;
            this.ReceiverPosCode.Text = "Postal Code";
            // 
            // tbReceiverAddress
            // 
            this.tbReceiverAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverAddress.Location = new System.Drawing.Point(746, 100);
            this.tbReceiverAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReceiverAddress.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbReceiverAddress.Name = "tbReceiverAddress";
            this.tbReceiverAddress.Size = new System.Drawing.Size(425, 23);
            this.tbReceiverAddress.TabIndex = 13;
            // 
            // tbReceiverContactNo
            // 
            this.tbReceiverContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverContactNo.Location = new System.Drawing.Point(746, 52);
            this.tbReceiverContactNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReceiverContactNo.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbReceiverContactNo.Name = "tbReceiverContactNo";
            this.tbReceiverContactNo.Size = new System.Drawing.Size(425, 23);
            this.tbReceiverContactNo.TabIndex = 12;
            // 
            // ReceiverState
            // 
            this.ReceiverState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiverState.AutoSize = true;
            this.ReceiverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverState.Location = new System.Drawing.Point(610, 207);
            this.ReceiverState.Name = "ReceiverState";
            this.ReceiverState.Size = new System.Drawing.Size(48, 20);
            this.ReceiverState.TabIndex = 11;
            this.ReceiverState.Text = "State";
            // 
            // ReceiverCity
            // 
            this.ReceiverCity.AutoSize = true;
            this.ReceiverCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverCity.Location = new System.Drawing.Point(21, 207);
            this.ReceiverCity.Name = "ReceiverCity";
            this.ReceiverCity.Size = new System.Drawing.Size(38, 20);
            this.ReceiverCity.TabIndex = 10;
            this.ReceiverCity.Text = "City";
            // 
            // ReceiverLocation
            // 
            this.ReceiverLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiverLocation.AutoSize = true;
            this.ReceiverLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverLocation.Location = new System.Drawing.Point(610, 153);
            this.ReceiverLocation.Name = "ReceiverLocation";
            this.ReceiverLocation.Size = new System.Drawing.Size(73, 20);
            this.ReceiverLocation.TabIndex = 9;
            this.ReceiverLocation.Text = "Location";
            // 
            // tbReceiverCity
            // 
            this.tbReceiverCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverCity.Location = new System.Drawing.Point(157, 204);
            this.tbReceiverCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReceiverCity.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbReceiverCity.Name = "tbReceiverCity";
            this.tbReceiverCity.Size = new System.Drawing.Size(378, 23);
            this.tbReceiverCity.TabIndex = 7;
            // 
            // tbReceiverPosCode
            // 
            this.tbReceiverPosCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverPosCode.Location = new System.Drawing.Point(157, 153);
            this.tbReceiverPosCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReceiverPosCode.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbReceiverPosCode.Name = "tbReceiverPosCode";
            this.tbReceiverPosCode.Size = new System.Drawing.Size(378, 23);
            this.tbReceiverPosCode.TabIndex = 6;
            this.tbReceiverPosCode.TextChanged += new System.EventHandler(this.TbReceiverPosCode_TextChanged);
            // 
            // tbReceiverEmail
            // 
            this.tbReceiverEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverEmail.Location = new System.Drawing.Point(157, 100);
            this.tbReceiverEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReceiverEmail.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbReceiverEmail.Name = "tbReceiverEmail";
            this.tbReceiverEmail.Size = new System.Drawing.Size(378, 23);
            this.tbReceiverEmail.TabIndex = 5;
            // 
            // tbReceiverName
            // 
            this.tbReceiverName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiverName.Location = new System.Drawing.Point(157, 52);
            this.tbReceiverName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbReceiverName.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbReceiverName.Name = "tbReceiverName";
            this.tbReceiverName.Size = new System.Drawing.Size(378, 23);
            this.tbReceiverName.TabIndex = 4;
            // 
            // ReceiverAddress
            // 
            this.ReceiverAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiverAddress.AutoSize = true;
            this.ReceiverAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverAddress.Location = new System.Drawing.Point(610, 106);
            this.ReceiverAddress.Name = "ReceiverAddress";
            this.ReceiverAddress.Size = new System.Drawing.Size(71, 20);
            this.ReceiverAddress.TabIndex = 3;
            this.ReceiverAddress.Text = "Address";
            // 
            // ReceiverEmail
            // 
            this.ReceiverEmail.AutoSize = true;
            this.ReceiverEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverEmail.Location = new System.Drawing.Point(21, 100);
            this.ReceiverEmail.Name = "ReceiverEmail";
            this.ReceiverEmail.Size = new System.Drawing.Size(51, 20);
            this.ReceiverEmail.TabIndex = 2;
            this.ReceiverEmail.Text = "Email";
            // 
            // ReceiverContactNo
            // 
            this.ReceiverContactNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiverContactNo.AutoSize = true;
            this.ReceiverContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverContactNo.Location = new System.Drawing.Point(610, 55);
            this.ReceiverContactNo.Name = "ReceiverContactNo";
            this.ReceiverContactNo.Size = new System.Drawing.Size(97, 20);
            this.ReceiverContactNo.TabIndex = 1;
            this.ReceiverContactNo.Text = "Contact No.";
            // 
            // ReceiverName
            // 
            this.ReceiverName.AutoSize = true;
            this.ReceiverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReceiverName.Location = new System.Drawing.Point(21, 52);
            this.ReceiverName.Name = "ReceiverName";
            this.ReceiverName.Size = new System.Drawing.Size(53, 20);
            this.ReceiverName.TabIndex = 0;
            this.ReceiverName.Text = "Name";
            // 
            // ParcelDetails
            // 
            this.ParcelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParcelDetails.Controls.Add(this.rbDocument);
            this.ParcelDetails.Controls.Add(this.rbParcel);
            this.ParcelDetails.Controls.Add(this.tbWeight);
            this.ParcelDetails.Controls.Add(this.ValueofContent);
            this.ParcelDetails.Controls.Add(this.tbContent);
            this.ParcelDetails.Controls.Add(this.weight);
            this.ParcelDetails.Controls.Add(this.tbValueofContent);
            this.ParcelDetails.Controls.Add(this.tbPieces);
            this.ParcelDetails.Controls.Add(this.Content);
            this.ParcelDetails.Controls.Add(this.Pieces);
            this.ParcelDetails.Controls.Add(this.ParcelType);
            this.ParcelDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParcelDetails.Location = new System.Drawing.Point(39, 639);
            this.ParcelDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ParcelDetails.Name = "ParcelDetails";
            this.ParcelDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ParcelDetails.Size = new System.Drawing.Size(1211, 214);
            this.ParcelDetails.TabIndex = 8;
            this.ParcelDetails.TabStop = false;
            this.ParcelDetails.Text = "Parcel Details";
            // 
            // rbDocument
            // 
            this.rbDocument.AutoSize = true;
            this.rbDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDocument.Location = new System.Drawing.Point(284, 52);
            this.rbDocument.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDocument.Name = "rbDocument";
            this.rbDocument.Size = new System.Drawing.Size(107, 24);
            this.rbDocument.TabIndex = 16;
            this.rbDocument.TabStop = true;
            this.rbDocument.Text = "Document";
            this.rbDocument.UseVisualStyleBackColor = true;
            // 
            // rbParcel
            // 
            this.rbParcel.AutoSize = true;
            this.rbParcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbParcel.Location = new System.Drawing.Point(161, 52);
            this.rbParcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbParcel.Name = "rbParcel";
            this.rbParcel.Size = new System.Drawing.Size(78, 24);
            this.rbParcel.TabIndex = 15;
            this.rbParcel.TabStop = true;
            this.rbParcel.Text = "Parcel";
            this.rbParcel.UseVisualStyleBackColor = true;
            // 
            // tbWeight
            // 
            this.tbWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWeight.Location = new System.Drawing.Point(746, 150);
            this.tbWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbWeight.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbWeight.Name = "tbWeight";
            this.tbWeight.Size = new System.Drawing.Size(425, 23);
            this.tbWeight.TabIndex = 14;
            this.tbWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbWeight_KeyPress);
            // 
            // ValueofContent
            // 
            this.ValueofContent.AutoSize = true;
            this.ValueofContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValueofContent.Location = new System.Drawing.Point(21, 156);
            this.ValueofContent.Name = "ValueofContent";
            this.ValueofContent.Size = new System.Drawing.Size(117, 18);
            this.ValueofContent.TabIndex = 8;
            this.ValueofContent.Text = "Value of Content";
            // 
            // tbContent
            // 
            this.tbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContent.Location = new System.Drawing.Point(746, 97);
            this.tbContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbContent.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(425, 23);
            this.tbContent.TabIndex = 13;
            this.tbContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbContent_KeyPress);
            // 
            // weight
            // 
            this.weight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.weight.AutoSize = true;
            this.weight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weight.Location = new System.Drawing.Point(610, 150);
            this.weight.Name = "weight";
            this.weight.Size = new System.Drawing.Size(90, 20);
            this.weight.TabIndex = 9;
            this.weight.Text = "Weight(kg)";
            // 
            // tbValueofContent
            // 
            this.tbValueofContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValueofContent.Location = new System.Drawing.Point(157, 153);
            this.tbValueofContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbValueofContent.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbValueofContent.Name = "tbValueofContent";
            this.tbValueofContent.Size = new System.Drawing.Size(378, 23);
            this.tbValueofContent.TabIndex = 6;
            this.tbValueofContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbValueofContent_KeyPress);
            // 
            // tbPieces
            // 
            this.tbPieces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPieces.Location = new System.Drawing.Point(157, 100);
            this.tbPieces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPieces.MaximumSize = new System.Drawing.Size(425, 23);
            this.tbPieces.Name = "tbPieces";
            this.tbPieces.Size = new System.Drawing.Size(378, 23);
            this.tbPieces.TabIndex = 5;
            this.tbPieces.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbPieces_KeyPress);
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Content.AutoSize = true;
            this.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Content.Location = new System.Drawing.Point(610, 103);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(67, 20);
            this.Content.TabIndex = 3;
            this.Content.Text = "Content";
            // 
            // Pieces
            // 
            this.Pieces.AutoSize = true;
            this.Pieces.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pieces.Location = new System.Drawing.Point(21, 100);
            this.Pieces.Name = "Pieces";
            this.Pieces.Size = new System.Drawing.Size(60, 20);
            this.Pieces.TabIndex = 2;
            this.Pieces.Text = "Pieces";
            // 
            // ParcelType
            // 
            this.ParcelType.AutoSize = true;
            this.ParcelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParcelType.Location = new System.Drawing.Point(21, 52);
            this.ParcelType.Name = "ParcelType";
            this.ParcelType.Size = new System.Drawing.Size(98, 20);
            this.ParcelType.TabIndex = 0;
            this.ParcelType.Text = "Parcel Type";
            // 
            // QuoteBtn
            // 
            this.QuoteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuoteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuoteBtn.Location = new System.Drawing.Point(428, 878);
            this.QuoteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.QuoteBtn.Name = "QuoteBtn";
            this.QuoteBtn.Size = new System.Drawing.Size(117, 57);
            this.QuoteBtn.TabIndex = 10;
            this.QuoteBtn.Text = "Quote";
            this.QuoteBtn.UseVisualStyleBackColor = true;
            this.QuoteBtn.Click += new System.EventHandler(this.QuoteBtn_Click);
            // 
            // totalPrice
            // 
            this.totalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPrice.AutoSize = true;
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(318, 967);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Padding = new System.Windows.Forms.Padding(0, 0, 0, 62);
            this.totalPrice.Size = new System.Drawing.Size(130, 88);
            this.totalPrice.TabIndex = 11;
            this.totalPrice.Text = "Total (RM):";
            // 
            // price
            // 
            this.price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.price.AutoSize = true;
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.ForeColor = System.Drawing.Color.Red;
            this.price.Location = new System.Drawing.Point(503, 967);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(71, 26);
            this.price.TabIndex = 12;
            this.price.Text = "14.00";
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfirmBtn.Enabled = false;
            this.ConfirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfirmBtn.Location = new System.Drawing.Point(798, 878);
            this.ConfirmBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(116, 67);
            this.ConfirmBtn.TabIndex = 13;
            this.ConfirmBtn.Text = "Confirm";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // warningEP
            // 
            this.warningEP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.warningEP.ContainerControl = this;
            // 
            // invalidEP
            // 
            this.invalidEP.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.invalidEP.ContainerControl = this;
            this.invalidEP.Icon = ((System.Drawing.Icon)(resources.GetObject("invalidEP.Icon")));
            // 
            // CreateNewParcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1308, 731);
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.price);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.QuoteBtn);
            this.Controls.Add(this.ParcelDetails);
            this.Controls.Add(this.ReceiverDetails);
            this.Controls.Add(this.SenderDetails);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1326, 1318);
            this.MinimumSize = new System.Drawing.Size(1326, 605);
            this.Name = "CreateNewParcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewParcel";
            this.SenderDetails.ResumeLayout(false);
            this.SenderDetails.PerformLayout();
            this.ReceiverDetails.ResumeLayout(false);
            this.ReceiverDetails.PerformLayout();
            this.ParcelDetails.ResumeLayout(false);
            this.ParcelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningEP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invalidEP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox SenderDetails;
        private System.Windows.Forms.TextBox tbSenderState;
        private System.Windows.Forms.Label SenderPosCode;
        private System.Windows.Forms.TextBox tbSenderAddress;
        private System.Windows.Forms.TextBox tbSenderContactNo;
        private System.Windows.Forms.Label SenderState;
        private System.Windows.Forms.Label SenderCity;
        private System.Windows.Forms.Label SenderLocation;
        private System.Windows.Forms.TextBox tbSenderCity;
        private System.Windows.Forms.TextBox tbSenderPosCode;
        private System.Windows.Forms.TextBox tbSenderEmail;
        private System.Windows.Forms.TextBox tbSenderName;
        private System.Windows.Forms.Label SenderAddress;
        private System.Windows.Forms.Label SenderEmail;
        private System.Windows.Forms.Label SenderContactNo;
        private System.Windows.Forms.Label SenderName;
        private System.Windows.Forms.GroupBox ReceiverDetails;
        private System.Windows.Forms.TextBox tbReceiverState;
        private System.Windows.Forms.Label ReceiverPosCode;
        private System.Windows.Forms.TextBox tbReceiverAddress;
        private System.Windows.Forms.TextBox tbReceiverContactNo;
        private System.Windows.Forms.Label ReceiverState;
        private System.Windows.Forms.Label ReceiverCity;
        private System.Windows.Forms.Label ReceiverLocation;
        private System.Windows.Forms.TextBox tbReceiverCity;
        private System.Windows.Forms.TextBox tbReceiverPosCode;
        private System.Windows.Forms.TextBox tbReceiverEmail;
        private System.Windows.Forms.TextBox tbReceiverName;
        private System.Windows.Forms.Label ReceiverAddress;
        private System.Windows.Forms.Label ReceiverEmail;
        private System.Windows.Forms.Label ReceiverContactNo;
        private System.Windows.Forms.Label ReceiverName;
        private System.Windows.Forms.GroupBox ParcelDetails;
        private System.Windows.Forms.RadioButton rbDocument;
        private System.Windows.Forms.RadioButton rbParcel;
        private System.Windows.Forms.TextBox tbWeight;
        private System.Windows.Forms.Label ValueofContent;
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.Label weight;
        private System.Windows.Forms.TextBox tbValueofContent;
        private System.Windows.Forms.TextBox tbPieces;
        private System.Windows.Forms.Label Content;
        private System.Windows.Forms.Label Pieces;
        private System.Windows.Forms.Label ParcelType;
        private System.Windows.Forms.Button QuoteBtn;
        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.Button ConfirmBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSenderidNumber;
        private System.Windows.Forms.Label IdNo;
        private System.Windows.Forms.ComboBox cbIdtype;
        private System.Windows.Forms.ErrorProvider warningEP;
        private System.Windows.Forms.ErrorProvider invalidEP;
        private System.Windows.Forms.ComboBox cbSenderLocation;
        private System.Windows.Forms.ComboBox cbReceiverLocation;
    }
}