namespace SmartDeviceProject1
{
    partial class PriceChecker
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
            this.Barcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.ItemCode = new System.Windows.Forms.TextBox();
            this.Description = new System.Windows.Forms.TextBox();
            this.ComboBoxUnit = new System.Windows.Forms.ComboBox();
            this.Vendor = new System.Windows.Forms.TextBox();
            this.SalePrice = new System.Windows.Forms.TextBox();
            this.CostPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Barcode
            // 
            this.Barcode.Location = new System.Drawing.Point(97, 25);
            this.Barcode.Name = "Barcode";
            this.Barcode.Size = new System.Drawing.Size(135, 21);
            this.Barcode.TabIndex = 0;
            this.Barcode.TextChanged += new System.EventHandler(this.Barcode_TextChanged);
            this.Barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.Barcode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnPaste);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.Text = "Barcode";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(10, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.Text = "Item Code";
            // 
            // label9
            // 

            

            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(11, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.Text = "Description";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(13, 127);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 17);
            this.label11.Text = "U.O.M.";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(13, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 17);
            this.label12.Text = "Vendor";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(11, 185);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 16);
            this.label13.Text = "Price";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItem1);
            this.mainMenu1.MenuItems.Add(this.menuItem3);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Back";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Text = "Reset";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // ItemCode
            // 
            this.ItemCode.Location = new System.Drawing.Point(96, 54);
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.Size = new System.Drawing.Size(135, 21);
            this.ItemCode.TabIndex = 42;
            this.ItemCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandlerItemCode);
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(96, 81);
            this.Description.Multiline = true;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Size = new System.Drawing.Size(135, 36);
            this.Description.TabIndex = 43;
            // 
            // ComboBoxUnit
            // 
            this.ComboBoxUnit.Location = new System.Drawing.Point(97, 124);
            this.ComboBoxUnit.Name = "ComboBoxUnit";
            this.ComboBoxUnit.Size = new System.Drawing.Size(100, 22);
            this.ComboBoxUnit.TabIndex = 44;
            this.ComboBoxUnit.GotFocus += new System.EventHandler(this.cmbUOM_Click);
            // 
            // Vendor
            // 
            this.Vendor.Location = new System.Drawing.Point(97, 154);
            this.Vendor.Name = "Vendor";
            this.Vendor.ReadOnly = true;
            this.Vendor.Size = new System.Drawing.Size(135, 21);
            this.Vendor.TabIndex = 45;
            // 
            // SalePrice
            // 
            this.SalePrice.Location = new System.Drawing.Point(96, 183);
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.ReadOnly = true;
            this.SalePrice.Size = new System.Drawing.Size(65, 21);
            this.SalePrice.TabIndex = 46;
            // 
            // CostPrice
            // 
            this.CostPrice.Location = new System.Drawing.Point(167, 183);
            this.CostPrice.Name = "CostPrice";
            this.CostPrice.ReadOnly = true;
            this.CostPrice.Size = new System.Drawing.Size(64, 21);
            this.CostPrice.TabIndex = 47;
            // 
            // PriceChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.CostPrice);
            this.Controls.Add(this.SalePrice);
            this.Controls.Add(this.Vendor);
            this.Controls.Add(this.ComboBoxUnit);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.ItemCode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Barcode);
            this.Menu = this.mainMenu1;
            this.Name = "PriceChecker";
            this.Text = "PriceChecker";
            this.Load += new System.EventHandler(this.PriceChecker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox Barcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.TextBox ItemCode;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.ComboBox ComboBoxUnit;
        private System.Windows.Forms.TextBox Vendor;
        private System.Windows.Forms.TextBox SalePrice;
        private System.Windows.Forms.TextBox CostPrice;

    }
}