namespace QuanLyCuaHang
{
    partial class TrangChu
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
            this.SidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuTimer1 = new System.Windows.Forms.Timer(this.components);
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbRole = new System.Windows.Forms.Label();
            this.sidebarMenu = new System.Windows.Forms.PictureBox();
            this.LbMenu = new System.Windows.Forms.Label();
            this.btnQLNV = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnQLDH = new System.Windows.Forms.Button();
            this.btnQLDDH = new System.Windows.Forms.Button();
            this.btnQLGH = new System.Windows.Forms.Button();
            this.btnQLKH = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btnQLHH = new System.Windows.Forms.Button();
            this.btnQLLM = new System.Windows.Forms.Button();
            this.btnQLMA = new System.Windows.Forms.Button();
            this.btnTK = new System.Windows.Forms.Button();
            this.btnTTCN = new System.Windows.Forms.Button();
            this.MenuTimer2 = new System.Windows.Forms.Timer(this.components);
            this.panelContainer = new System.Windows.Forms.Panel();
            this.sidebar.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarMenu)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // SidebarTimer
            // 
            this.SidebarTimer.Interval = 30;
            this.SidebarTimer.Tick += new System.EventHandler(this.SidebarTimer_Tick);
            // 
            // MenuTimer1
            // 
            this.MenuTimer1.Interval = 30;
            this.MenuTimer1.Tick += new System.EventHandler(this.MenuTimer1_Tick);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.btnQLNV);
            this.sidebar.Controls.Add(this.flowLayoutPanel1);
            this.sidebar.Controls.Add(this.flowLayoutPanel2);
            this.sidebar.Controls.Add(this.btnTK);
            this.sidebar.Controls.Add(this.btnTTCN);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Margin = new System.Windows.Forms.Padding(0);
            this.sidebar.MaximumSize = new System.Drawing.Size(323, 0);
            this.sidebar.MinimumSize = new System.Drawing.Size(87, 650);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(323, 680);
            this.sidebar.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbRole);
            this.panel3.Controls.Add(this.sidebarMenu);
            this.panel3.Controls.Add(this.LbMenu);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 69);
            this.panel3.TabIndex = 2;
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbRole.ForeColor = System.Drawing.Color.White;
            this.lbRole.Location = new System.Drawing.Point(197, 22);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(44, 23);
            this.lbRole.TabIndex = 2;
            this.lbRole.Text = "Role";
            // 
            // sidebarMenu
            // 
            this.sidebarMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sidebarMenu.Image = global::QuanLyCuaHang.Properties.Resources.menu_bar;
            this.sidebarMenu.Location = new System.Drawing.Point(24, 16);
            this.sidebarMenu.Name = "sidebarMenu";
            this.sidebarMenu.Size = new System.Drawing.Size(40, 40);
            this.sidebarMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.sidebarMenu.TabIndex = 0;
            this.sidebarMenu.TabStop = false;
            this.sidebarMenu.Click += new System.EventHandler(this.Menu_Click);
            // 
            // LbMenu
            // 
            this.LbMenu.AutoSize = true;
            this.LbMenu.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LbMenu.ForeColor = System.Drawing.Color.White;
            this.LbMenu.Location = new System.Drawing.Point(79, 20);
            this.LbMenu.Name = "LbMenu";
            this.LbMenu.Size = new System.Drawing.Size(61, 25);
            this.LbMenu.TabIndex = 1;
            this.LbMenu.Text = "Menu";
            // 
            // btnQLNV
            // 
            this.btnQLNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLNV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLNV.ForeColor = System.Drawing.Color.White;
            this.btnQLNV.Image = global::QuanLyCuaHang.Properties.Resources.multiple_users_silhouette;
            this.btnQLNV.Location = new System.Drawing.Point(0, 75);
            this.btnQLNV.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLNV.Name = "btnQLNV";
            this.btnQLNV.Size = new System.Drawing.Size(323, 63);
            this.btnQLNV.TabIndex = 5;
            this.btnQLNV.Text = "                 Quản lý nhân viên";
            this.btnQLNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLNV.UseVisualStyleBackColor = false;
            this.btnQLNV.Click += new System.EventHandler(this.btnQLNV_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.btnQLDDH);
            this.flowLayoutPanel2.Controls.Add(this.btnQLGH);
            this.flowLayoutPanel2.Controls.Add(this.btnQLKH);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 210);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.MaximumSize = new System.Drawing.Size(323, 265);
            this.flowLayoutPanel2.MinimumSize = new System.Drawing.Size(323, 64);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(323, 64);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btnQLDH);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 61);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::QuanLyCuaHang.Properties.Resources.down;
            this.pictureBox2.Location = new System.Drawing.Point(278, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // btnQLDH
            // 
            this.btnQLDH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQLDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLDH.ForeColor = System.Drawing.Color.White;
            this.btnQLDH.Image = global::QuanLyCuaHang.Properties.Resources.shopping_cart;
            this.btnQLDH.Location = new System.Drawing.Point(0, 0);
            this.btnQLDH.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLDH.Name = "btnQLDH";
            this.btnQLDH.Size = new System.Drawing.Size(323, 61);
            this.btnQLDH.TabIndex = 3;
            this.btnQLDH.Text = "                 Quản lý đặt hàng";
            this.btnQLDH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLDH.UseVisualStyleBackColor = false;
            this.btnQLDH.Click += new System.EventHandler(this.btnQLDH_Click);
            this.btnQLDH.Leave += new System.EventHandler(this.btnQLDH_Leave);
            // 
            // btnQLDDH
            // 
            this.btnQLDDH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLDDH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLDDH.ForeColor = System.Drawing.Color.White;
            this.btnQLDDH.Image = global::QuanLyCuaHang.Properties.Resources.box;
            this.btnQLDDH.Location = new System.Drawing.Point(0, 67);
            this.btnQLDDH.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLDDH.Name = "btnQLDDH";
            this.btnQLDDH.Size = new System.Drawing.Size(323, 66);
            this.btnQLDDH.TabIndex = 0;
            this.btnQLDDH.Text = "                 Quản lý đơn đặt hàng";
            this.btnQLDDH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLDDH.UseVisualStyleBackColor = false;
            this.btnQLDDH.Click += new System.EventHandler(this.btnQLDDH_Click);
            // 
            // btnQLGH
            // 
            this.btnQLGH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLGH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLGH.ForeColor = System.Drawing.Color.White;
            this.btnQLGH.Image = global::QuanLyCuaHang.Properties.Resources.fast_delivery;
            this.btnQLGH.Location = new System.Drawing.Point(0, 133);
            this.btnQLGH.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLGH.MaximumSize = new System.Drawing.Size(323, 61);
            this.btnQLGH.Name = "btnQLGH";
            this.btnQLGH.Size = new System.Drawing.Size(323, 61);
            this.btnQLGH.TabIndex = 1;
            this.btnQLGH.Text = "                 Quản lý giao hàng";
            this.btnQLGH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLGH.UseVisualStyleBackColor = false;
            // 
            // btnQLKH
            // 
            this.btnQLKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLKH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLKH.ForeColor = System.Drawing.Color.White;
            this.btnQLKH.Image = global::QuanLyCuaHang.Properties.Resources.id_card;
            this.btnQLKH.Location = new System.Drawing.Point(0, 194);
            this.btnQLKH.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLKH.MaximumSize = new System.Drawing.Size(323, 61);
            this.btnQLKH.Name = "btnQLKH";
            this.btnQLKH.Size = new System.Drawing.Size(323, 61);
            this.btnQLKH.TabIndex = 4;
            this.btnQLKH.Text = "                 Quản lý khách hàng";
            this.btnQLKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLKH.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.btnQLLM);
            this.flowLayoutPanel1.Controls.Add(this.btnQLMA);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 138);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(323, 198);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(323, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(323, 72);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.btnQLHH);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(323, 66);
            this.panel4.TabIndex = 8;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::QuanLyCuaHang.Properties.Resources.down;
            this.pictureBox4.Location = new System.Drawing.Point(277, 19);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // btnQLHH
            // 
            this.btnQLHH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLHH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQLHH.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLHH.ForeColor = System.Drawing.Color.White;
            this.btnQLHH.Image = global::QuanLyCuaHang.Properties.Resources.checklists;
            this.btnQLHH.Location = new System.Drawing.Point(0, 0);
            this.btnQLHH.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLHH.Name = "btnQLHH";
            this.btnQLHH.Size = new System.Drawing.Size(323, 66);
            this.btnQLHH.TabIndex = 0;
            this.btnQLHH.Text = "                 Quản lý hàng hóa";
            this.btnQLHH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLHH.UseVisualStyleBackColor = false;
            this.btnQLHH.Click += new System.EventHandler(this.btnQLHH_Click);
            this.btnQLHH.Leave += new System.EventHandler(this.btnQLHH_Leave);
            // 
            // btnQLLM
            // 
            this.btnQLLM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLLM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLLM.ForeColor = System.Drawing.Color.White;
            this.btnQLLM.Image = global::QuanLyCuaHang.Properties.Resources.price_list;
            this.btnQLLM.Location = new System.Drawing.Point(0, 72);
            this.btnQLLM.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLLM.MaximumSize = new System.Drawing.Size(323, 61);
            this.btnQLLM.Name = "btnQLLM";
            this.btnQLLM.Size = new System.Drawing.Size(323, 61);
            this.btnQLLM.TabIndex = 1;
            this.btnQLLM.Text = "                 Quản lý loại món";
            this.btnQLLM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLLM.UseVisualStyleBackColor = false;
            // 
            // btnQLMA
            // 
            this.btnQLMA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQLMA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQLMA.ForeColor = System.Drawing.Color.White;
            this.btnQLMA.Image = global::QuanLyCuaHang.Properties.Resources.dish;
            this.btnQLMA.Location = new System.Drawing.Point(0, 133);
            this.btnQLMA.Margin = new System.Windows.Forms.Padding(0);
            this.btnQLMA.Name = "btnQLMA";
            this.btnQLMA.Size = new System.Drawing.Size(323, 65);
            this.btnQLMA.TabIndex = 2;
            this.btnQLMA.Text = "                 Quản lý Món ăn";
            this.btnQLMA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLMA.UseVisualStyleBackColor = false;
            // 
            // btnTK
            // 
            this.btnTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTK.ForeColor = System.Drawing.Color.White;
            this.btnTK.Image = global::QuanLyCuaHang.Properties.Resources.diagram;
            this.btnTK.Location = new System.Drawing.Point(0, 274);
            this.btnTK.Margin = new System.Windows.Forms.Padding(0);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(323, 63);
            this.btnTK.TabIndex = 6;
            this.btnTK.Text = "                        Thống kê";
            this.btnTK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTK.UseVisualStyleBackColor = false;
            // 
            // btnTTCN
            // 
            this.btnTTCN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTTCN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTTCN.ForeColor = System.Drawing.Color.White;
            this.btnTTCN.Image = global::QuanLyCuaHang.Properties.Resources.profile;
            this.btnTTCN.Location = new System.Drawing.Point(0, 337);
            this.btnTTCN.Margin = new System.Windows.Forms.Padding(0);
            this.btnTTCN.Name = "btnTTCN";
            this.btnTTCN.Size = new System.Drawing.Size(323, 63);
            this.btnTTCN.TabIndex = 7;
            this.btnTTCN.Text = "                 Thông tin cá nhân";
            this.btnTTCN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTTCN.UseVisualStyleBackColor = false;
            // 
            // MenuTimer2
            // 
            this.MenuTimer2.Interval = 30;
            this.MenuTimer2.Tick += new System.EventHandler(this.MenuTimer2_Tick);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(323, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1159, 680);
            this.panelContainer.TabIndex = 2;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 680);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.sidebar);
            this.HelpButton = true;
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.sidebar.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarMenu)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer SidebarTimer;
        private System.Windows.Forms.Timer MenuTimer1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.PictureBox sidebarMenu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LbMenu;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnQLHH;
        private System.Windows.Forms.Button btnQLLM;
        private System.Windows.Forms.Button btnQLDH;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnQLNV;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnQLDDH;
        private System.Windows.Forms.Button btnQLGH;
        private System.Windows.Forms.Button btnQLKH;
        private System.Windows.Forms.Button btnQLMA;
        private System.Windows.Forms.Timer MenuTimer2;
        private System.Windows.Forms.Button btnTTCN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label lbRole;
    }
}