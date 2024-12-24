namespace HTQLMKT1
{
    partial class CQLTK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CQLTK));
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTaoTK = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.TenDNKH = new System.Windows.Forms.Label();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelTB = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(538, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật Khẩu ";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(677, 122);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(195, 24);
            this.txtMatKhau.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 367);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 18);
            this.label5.TabIndex = 8;
            // 
            // btnTaoTK
            // 
            this.btnTaoTK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnTaoTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaoTK.Location = new System.Drawing.Point(766, 405);
            this.btnTaoTK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTaoTK.Name = "btnTaoTK";
            this.btnTaoTK.Size = new System.Drawing.Size(142, 37);
            this.btnTaoTK.TabIndex = 5;
            this.btnTaoTK.Text = "Tạo ";
            this.btnTaoTK.UseVisualStyleBackColor = false;
            this.btnTaoTK.Click += new System.EventHandler(this.btnTaoTK_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.DarkGray;
            this.btnHuy.Location = new System.Drawing.Point(766, 449);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(142, 37);
            this.btnHuy.TabIndex = 11;
            this.btnHuy.Text = "Hủy ";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // TenDNKH
            // 
            this.TenDNKH.AutoSize = true;
            this.TenDNKH.BackColor = System.Drawing.Color.Transparent;
            this.TenDNKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenDNKH.Location = new System.Drawing.Point(86, 128);
            this.TenDNKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TenDNKH.Name = "TenDNKH";
            this.TenDNKH.Size = new System.Drawing.Size(129, 18);
            this.TenDNKH.TabIndex = 12;
            this.TenDNKH.Text = "Tên Đăng Nhập ";
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(241, 122);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(192, 24);
            this.txtTenDN.TabIndex = 13;
            this.txtTenDN.TextChanged += new System.EventHandler(this.txtTenDN_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(188, 271);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(541, 192);
            this.dataGridView1.TabIndex = 14;
            // 
            // labelTB
            // 
            this.labelTB.AutoSize = true;
            this.labelTB.Location = new System.Drawing.Point(781, 284);
            this.labelTB.Name = "labelTB";
            this.labelTB.Size = new System.Drawing.Size(0, 18);
            this.labelTB.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(86, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Mã Khách Hàng";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(241, 200);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(192, 24);
            this.txtMaKH.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(538, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Mã Nhân Viên ";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(677, 203);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(195, 24);
            this.txtMaNV.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Coral;
            this.label4.Location = new System.Drawing.Point(390, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 29);
            this.label4.TabIndex = 20;
            this.label4.Text = "TẠO TÀI KHOẢN MỚI ";
            // 
            // CQLTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HTQLMKT1.Properties.Resources.imapmo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(978, 495);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaKH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.TenDNKH);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnTaoTK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CQLTK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CQLTK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CQLTK_FormClosing);
            this.Load += new System.EventHandler(this.CQLTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTaoTK;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Label TenDNKH;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label4;
    }
}