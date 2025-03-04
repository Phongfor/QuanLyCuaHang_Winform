namespace QuanLyCuaHang
{
    partial class FoodItem
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
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lbGia = new System.Windows.Forms.Label();
            this.pbImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.BackColor = System.Drawing.Color.Transparent;
            this.lblTenMon.Location = new System.Drawing.Point(3, 15);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(75, 16);
            this.lblTenMon.TabIndex = 0;
            this.lblTenMon.Text = "Hamburger";
            // 
            // lbGia
            // 
            this.lbGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbGia.AutoSize = true;
            this.lbGia.BackColor = System.Drawing.Color.Transparent;
            this.lbGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGia.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbGia.Location = new System.Drawing.Point(3, 73);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(78, 25);
            this.lbGia.TabIndex = 1;
            this.lbGia.Text = "50.000đ";
            // 
            // pbImg
            // 
            this.pbImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbImg.Location = new System.Drawing.Point(93, 15);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(101, 74);
            this.pbImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImg.TabIndex = 2;
            this.pbImg.TabStop = false;
            // 
            // FoodItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbGia);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.pbImg);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "FoodItem";
            this.Size = new System.Drawing.Size(198, 98);
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lbGia;
        private System.Windows.Forms.PictureBox pbImg;
    }
}
