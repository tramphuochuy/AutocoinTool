namespace AutoCoin
{
    partial class APIWatcher_Item
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
            this.edtCoinName = new System.Windows.Forms.TextBox();
            this.edtPrice = new System.Windows.Forms.TextBox();
            this.edtTrigerPrice = new System.Windows.Forms.TextBox();
            this.edtEnable = new System.Windows.Forms.CheckBox();
            this.edtPeriod = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // edtCoinName
            // 
            this.edtCoinName.BackColor = System.Drawing.SystemColors.Control;
            this.edtCoinName.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.edtCoinName.Location = new System.Drawing.Point(3, 3);
            this.edtCoinName.Name = "edtCoinName";
            this.edtCoinName.Size = new System.Drawing.Size(130, 50);
            this.edtCoinName.TabIndex = 2;
            // 
            // edtPrice
            // 
            this.edtPrice.BackColor = System.Drawing.SystemColors.Control;
            this.edtPrice.Location = new System.Drawing.Point(135, 3);
            this.edtPrice.Name = "edtPrice";
            this.edtPrice.Size = new System.Drawing.Size(149, 20);
            this.edtPrice.TabIndex = 3;
            // 
            // edtTrigerPrice
            // 
            this.edtTrigerPrice.BackColor = System.Drawing.Color.Honeydew;
            this.edtTrigerPrice.Location = new System.Drawing.Point(135, 24);
            this.edtTrigerPrice.Name = "edtTrigerPrice";
            this.edtTrigerPrice.Size = new System.Drawing.Size(149, 20);
            this.edtTrigerPrice.TabIndex = 3;
            // 
            // edtEnable
            // 
            this.edtEnable.AutoSize = true;
            this.edtEnable.Location = new System.Drawing.Point(3, 56);
            this.edtEnable.Name = "edtEnable";
            this.edtEnable.Size = new System.Drawing.Size(59, 17);
            this.edtEnable.TabIndex = 4;
            this.edtEnable.Text = "Enable";
            this.edtEnable.UseVisualStyleBackColor = true;
            // 
            // edtPeriod
            // 
            this.edtPeriod.BackColor = System.Drawing.Color.LavenderBlush;
            this.edtPeriod.Location = new System.Drawing.Point(135, 45);
            this.edtPeriod.Name = "edtPeriod";
            this.edtPeriod.Size = new System.Drawing.Size(149, 20);
            this.edtPeriod.TabIndex = 3;
            // 
            // APIWatcher_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.edtEnable);
            this.Controls.Add(this.edtPeriod);
            this.Controls.Add(this.edtTrigerPrice);
            this.Controls.Add(this.edtPrice);
            this.Controls.Add(this.edtCoinName);
            this.Name = "APIWatcher_Item";
            this.Size = new System.Drawing.Size(287, 76);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox edtCoinName;
        public System.Windows.Forms.TextBox edtPrice;
        public System.Windows.Forms.TextBox edtTrigerPrice;
        public System.Windows.Forms.CheckBox edtEnable;
        public System.Windows.Forms.TextBox edtPeriod;


    }
}
