namespace AutoCoin
{
    partial class Coin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCheck = new System.Windows.Forms.RadioButton();
            this.edtURL = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.edtUsername = new System.Windows.Forms.TextBox();
            this.edtPassword = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLink = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRestart = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.edtLastPrice = new System.Windows.Forms.TextBox();
            this.btnUseAddress = new System.Windows.Forms.CheckBox();
            this.chkUsemaxdiff = new System.Windows.Forms.CheckBox();
            this.edtMaxReject = new System.Windows.Forms.NumericUpDown();
            this.edtMaxLastAccept = new System.Windows.Forms.NumericUpDown();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.remarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cyanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkDarkGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkOrgaranceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkSalmonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkSeaGreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkGoldenrodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsCurrentColor = new System.Windows.Forms.ToolStripMenuItem();
            this.chkX11 = new System.Windows.Forms.CheckBox();
            this.chkX13 = new System.Windows.Forms.CheckBox();
            this.chkGRO = new System.Windows.Forms.CheckBox();
            this.chkVERT = new System.Windows.Forms.CheckBox();
            this.edtMaxDiff = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panColor = new System.Windows.Forms.Panel();
            this.chkTALK = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxReject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxLastAccept)).BeginInit();
            this.cms.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.AutoSize = true;
            this.btnCheck.Location = new System.Drawing.Point(9, 8);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(45, 17);
            this.btnCheck.TabIndex = 0;
            this.btnCheck.TabStop = true;
            this.btnCheck.Text = "LTC";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // edtURL
            // 
            this.edtURL.Location = new System.Drawing.Point(71, 7);
            this.edtURL.Name = "edtURL";
            this.edtURL.Size = new System.Drawing.Size(195, 20);
            this.edtURL.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Honeydew;
            this.btnSave.Location = new System.Drawing.Point(562, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(48, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // edtUsername
            // 
            this.edtUsername.Location = new System.Drawing.Point(267, 7);
            this.edtUsername.Name = "edtUsername";
            this.edtUsername.Size = new System.Drawing.Size(89, 20);
            this.edtUsername.TabIndex = 1;
            this.edtUsername.Text = "tramphuochuy";
            // 
            // edtPassword
            // 
            this.edtPassword.Location = new System.Drawing.Point(358, 7);
            this.edtPassword.Name = "edtPassword";
            this.edtPassword.Size = new System.Drawing.Size(37, 20);
            this.edtPassword.TabIndex = 2;
            this.edtPassword.Text = "x";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LavenderBlush;
            this.btnDelete.Location = new System.Drawing.Point(613, 6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.DELETE);
            // 
            // btnLink
            // 
            this.btnLink.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLink.ContextMenuStrip = this.contextMenuStrip1;
            this.btnLink.Location = new System.Drawing.Point(664, 6);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(55, 23);
            this.btnLink.TabIndex = 8;
            this.btnLink.Text = "Link";
            this.btnLink.UseVisualStyleBackColor = false;
            this.btnLink.Click += new System.EventHandler(this.LINK);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editLinkToolStripMenuItem,
            this.aPIToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 48);
            // 
            // editLinkToolStripMenuItem
            // 
            this.editLinkToolStripMenuItem.Name = "editLinkToolStripMenuItem";
            this.editLinkToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.editLinkToolStripMenuItem.Text = "Edit Link";
            this.editLinkToolStripMenuItem.Click += new System.EventHandler(this.EditLink);
            // 
            // aPIToolStripMenuItem
            // 
            this.aPIToolStripMenuItem.Name = "aPIToolStripMenuItem";
            this.aPIToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.aPIToolStripMenuItem.Text = "API";
            this.aPIToolStripMenuItem.Click += new System.EventHandler(this.EDIT_API);
            // 
            // btnRestart
            // 
            this.btnRestart.AutoSize = true;
            this.btnRestart.Location = new System.Drawing.Point(640, 8);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(76, 17);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "AutoReset";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Beige;
            this.button2.Location = new System.Drawing.Point(663, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(46, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Test only";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.RUNTEST);
            // 
            // edtLastPrice
            // 
            this.edtLastPrice.BackColor = System.Drawing.Color.LemonChiffon;
            this.edtLastPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtLastPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.edtLastPrice.Location = new System.Drawing.Point(613, 5);
            this.edtLastPrice.Name = "edtLastPrice";
            this.edtLastPrice.ReadOnly = true;
            this.edtLastPrice.Size = new System.Drawing.Size(100, 19);
            this.edtLastPrice.TabIndex = 8;
            this.edtLastPrice.Visible = false;
            // 
            // btnUseAddress
            // 
            this.btnUseAddress.AutoSize = true;
            this.btnUseAddress.Location = new System.Drawing.Point(834, 7);
            this.btnUseAddress.Name = "btnUseAddress";
            this.btnUseAddress.Size = new System.Drawing.Size(46, 17);
            this.btnUseAddress.TabIndex = 4;
            this.btnUseAddress.Text = "P2P";
            this.btnUseAddress.UseVisualStyleBackColor = false;
            // 
            // chkUsemaxdiff
            // 
            this.chkUsemaxdiff.AutoSize = true;
            this.chkUsemaxdiff.Location = new System.Drawing.Point(400, 11);
            this.chkUsemaxdiff.Name = "chkUsemaxdiff";
            this.chkUsemaxdiff.Size = new System.Drawing.Size(15, 14);
            this.chkUsemaxdiff.TabIndex = 3;
            this.chkUsemaxdiff.UseVisualStyleBackColor = true;
            // 
            // edtMaxReject
            // 
            this.edtMaxReject.BackColor = System.Drawing.Color.Honeydew;
            this.edtMaxReject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.edtMaxReject.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.edtMaxReject.Location = new System.Drawing.Point(472, 7);
            this.edtMaxReject.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.edtMaxReject.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtMaxReject.Name = "edtMaxReject";
            this.edtMaxReject.Size = new System.Drawing.Size(41, 20);
            this.edtMaxReject.TabIndex = 10;
            this.edtMaxReject.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtMaxReject.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // edtMaxLastAccept
            // 
            this.edtMaxLastAccept.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMaxLastAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.edtMaxLastAccept.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.edtMaxLastAccept.Location = new System.Drawing.Point(514, 7);
            this.edtMaxLastAccept.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.edtMaxLastAccept.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edtMaxLastAccept.Name = "edtMaxLastAccept";
            this.edtMaxLastAccept.Size = new System.Drawing.Size(43, 20);
            this.edtMaxLastAccept.TabIndex = 11;
            this.edtMaxLastAccept.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtMaxLastAccept.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remarkToolStripMenuItem,
            this.cmsCurrentColor});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(115, 48);
            // 
            // remarkToolStripMenuItem
            // 
            this.remarkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greenToolStripMenuItem,
            this.redToolStripMenuItem,
            this.blueToolStripMenuItem,
            this.yellowToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.pinkToolStripMenuItem,
            this.cyanToolStripMenuItem,
            this.darkDarkGrayToolStripMenuItem,
            this.darkOrgaranceToolStripMenuItem,
            this.darkSalmonToolStripMenuItem,
            this.darkSeaGreenToolStripMenuItem,
            this.darkGoldenrodToolStripMenuItem});
            this.remarkToolStripMenuItem.Name = "remarkToolStripMenuItem";
            this.remarkToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.remarkToolStripMenuItem.Text = "Remark";
            // 
            // greenToolStripMenuItem
            // 
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.greenToolStripMenuItem.Text = "LightGreen";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.RemarkColor_Click);
            // 
            // redToolStripMenuItem
            // 
            this.redToolStripMenuItem.Name = "redToolStripMenuItem";
            this.redToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.redToolStripMenuItem.Text = "Red";
            this.redToolStripMenuItem.Click += new System.EventHandler(this.RemarkColor_Click);
            // 
            // blueToolStripMenuItem
            // 
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.blueToolStripMenuItem.Text = "LightBlue";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.RemarkColor_Click);
            // 
            // yellowToolStripMenuItem
            // 
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.yellowToolStripMenuItem.Text = "LightYellow";
            this.yellowToolStripMenuItem.Click += new System.EventHandler(this.RemarkColor_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.RemarkColor_Click);
            // 
            // pinkToolStripMenuItem
            // 
            this.pinkToolStripMenuItem.Name = "pinkToolStripMenuItem";
            this.pinkToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.pinkToolStripMenuItem.Text = "Pink";
            this.pinkToolStripMenuItem.Click += new System.EventHandler(this.RemarkColor_Click);
            // 
            // cyanToolStripMenuItem
            // 
            this.cyanToolStripMenuItem.Name = "cyanToolStripMenuItem";
            this.cyanToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.cyanToolStripMenuItem.Text = "Cyan";
            // 
            // darkDarkGrayToolStripMenuItem
            // 
            this.darkDarkGrayToolStripMenuItem.Name = "darkDarkGrayToolStripMenuItem";
            this.darkDarkGrayToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.darkDarkGrayToolStripMenuItem.Text = "DarkGray";
            // 
            // darkOrgaranceToolStripMenuItem
            // 
            this.darkOrgaranceToolStripMenuItem.Name = "darkOrgaranceToolStripMenuItem";
            this.darkOrgaranceToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.darkOrgaranceToolStripMenuItem.Text = "DarkOrange";
            // 
            // darkSalmonToolStripMenuItem
            // 
            this.darkSalmonToolStripMenuItem.Name = "darkSalmonToolStripMenuItem";
            this.darkSalmonToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.darkSalmonToolStripMenuItem.Text = "DarkSalmon";
            // 
            // darkSeaGreenToolStripMenuItem
            // 
            this.darkSeaGreenToolStripMenuItem.Name = "darkSeaGreenToolStripMenuItem";
            this.darkSeaGreenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.darkSeaGreenToolStripMenuItem.Text = "DarkSeaGreen";
            // 
            // darkGoldenrodToolStripMenuItem
            // 
            this.darkGoldenrodToolStripMenuItem.Name = "darkGoldenrodToolStripMenuItem";
            this.darkGoldenrodToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.darkGoldenrodToolStripMenuItem.Text = "DarkGoldenrod";
            // 
            // cmsCurrentColor
            // 
            this.cmsCurrentColor.Name = "cmsCurrentColor";
            this.cmsCurrentColor.Size = new System.Drawing.Size(114, 22);
            this.cmsCurrentColor.Text = "Color";
            // 
            // chkX11
            // 
            this.chkX11.AutoSize = true;
            this.chkX11.BackColor = System.Drawing.Color.DarkBlue;
            this.chkX11.Location = new System.Drawing.Point(728, 8);
            this.chkX11.Name = "chkX11";
            this.chkX11.Size = new System.Drawing.Size(15, 14);
            this.chkX11.TabIndex = 12;
            this.chkX11.UseVisualStyleBackColor = false;
            this.chkX11.Click += new System.EventHandler(this.chkSJ4_Click);
            // 
            // chkX13
            // 
            this.chkX13.AutoSize = true;
            this.chkX13.BackColor = System.Drawing.Color.DarkGreen;
            this.chkX13.Location = new System.Drawing.Point(749, 8);
            this.chkX13.Name = "chkX13";
            this.chkX13.Size = new System.Drawing.Size(15, 14);
            this.chkX13.TabIndex = 12;
            this.chkX13.UseVisualStyleBackColor = false;
            this.chkX13.Click += new System.EventHandler(this.chkSJ4_Click);
            // 
            // chkGRO
            // 
            this.chkGRO.AutoSize = true;
            this.chkGRO.BackColor = System.Drawing.Color.MediumVioletRed;
            this.chkGRO.Location = new System.Drawing.Point(770, 8);
            this.chkGRO.Name = "chkGRO";
            this.chkGRO.Size = new System.Drawing.Size(15, 14);
            this.chkGRO.TabIndex = 12;
            this.chkGRO.UseVisualStyleBackColor = false;
            this.chkGRO.Click += new System.EventHandler(this.chkSJ4_Click);
            // 
            // chkVERT
            // 
            this.chkVERT.AutoSize = true;
            this.chkVERT.BackColor = System.Drawing.Color.Chocolate;
            this.chkVERT.Location = new System.Drawing.Point(791, 8);
            this.chkVERT.Name = "chkVERT";
            this.chkVERT.Size = new System.Drawing.Size(15, 14);
            this.chkVERT.TabIndex = 12;
            this.chkVERT.UseVisualStyleBackColor = false;
            this.chkVERT.Click += new System.EventHandler(this.chkSJ4_Click);
            // 
            // edtMaxDiff
            // 
            this.edtMaxDiff.BackColor = System.Drawing.Color.LavenderBlush;
            this.edtMaxDiff.Location = new System.Drawing.Point(421, 7);
            this.edtMaxDiff.Name = "edtMaxDiff";
            this.edtMaxDiff.Size = new System.Drawing.Size(50, 20);
            this.edtMaxDiff.TabIndex = 2;
            this.edtMaxDiff.Text = "16";
            this.edtMaxDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(726, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 7);
            this.label1.TabIndex = 14;
            this.label1.Text = "X11";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(747, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 7);
            this.label2.TabIndex = 14;
            this.label2.Text = "X13";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.label3.Location = new System.Drawing.Point(768, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 7);
            this.label3.TabIndex = 14;
            this.label3.Text = "Gro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(789, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 7);
            this.label4.TabIndex = 14;
            this.label4.Text = "Vert";
            // 
            // panColor
            // 
            this.panColor.Location = new System.Drawing.Point(0, 30);
            this.panColor.Name = "panColor";
            this.panColor.Size = new System.Drawing.Size(719, 5);
            this.panColor.TabIndex = 15;
            // 
            // chkTALK
            // 
            this.chkTALK.AutoSize = true;
            this.chkTALK.BackColor = System.Drawing.Color.PaleTurquoise;
            this.chkTALK.Location = new System.Drawing.Point(812, 8);
            this.chkTALK.Name = "chkTALK";
            this.chkTALK.Size = new System.Drawing.Size(15, 14);
            this.chkTALK.TabIndex = 12;
            this.chkTALK.UseVisualStyleBackColor = false;
            this.chkTALK.Click += new System.EventHandler(this.chkSJ4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Location = new System.Drawing.Point(810, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 7);
            this.label5.TabIndex = 14;
            this.label5.Text = "Talk";
            // 
            // Coin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cms;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.chkTALK);
            this.Controls.Add(this.chkVERT);
            this.Controls.Add(this.chkGRO);
            this.Controls.Add(this.chkX13);
            this.Controls.Add(this.chkX11);
            this.Controls.Add(this.edtMaxLastAccept);
            this.Controls.Add(this.edtMaxReject);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.edtLastPrice);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnUseAddress);
            this.Controls.Add(this.chkUsemaxdiff);
            this.Controls.Add(this.edtMaxDiff);
            this.Controls.Add(this.edtPassword);
            this.Controls.Add(this.edtUsername);
            this.Controls.Add(this.edtURL);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.panColor);
            this.Name = "Coin";
            this.Size = new System.Drawing.Size(1054, 35);
            this.Load += new System.EventHandler(this.Coin_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxReject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxLastAccept)).EndInit();
            this.cms.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.RadioButton btnCheck;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLink;
        public System.Windows.Forms.CheckBox btnRestart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editLinkToolStripMenuItem;
        public System.Windows.Forms.TextBox edtURL;
        public System.Windows.Forms.TextBox edtUsername;
        public System.Windows.Forms.TextBox edtPassword;
        public System.Windows.Forms.TextBox edtLastPrice;
        public System.Windows.Forms.CheckBox btnUseAddress;
        public System.Windows.Forms.CheckBox chkUsemaxdiff;
        private System.Windows.Forms.NumericUpDown edtMaxReject;
        private System.Windows.Forms.NumericUpDown edtMaxLastAccept;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem remarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem cmsCurrentColor;
        private System.Windows.Forms.ToolStripMenuItem cyanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkDarkGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkOrgaranceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkSalmonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkSeaGreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkGoldenrodToolStripMenuItem;
        public System.Windows.Forms.CheckBox chkX11;
        public System.Windows.Forms.CheckBox chkX13;
        public System.Windows.Forms.CheckBox chkGRO;
        public System.Windows.Forms.CheckBox chkVERT;
        public System.Windows.Forms.TextBox edtMaxDiff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panColor;
        public System.Windows.Forms.CheckBox chkTALK;
        private System.Windows.Forms.Label label5;
    }
}
