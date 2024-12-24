namespace HTQLMKT1
{
    partial class RQLTK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RQLTK));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRMaTK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRMaKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRTenDN = new System.Windows.Forms.TextBox();
            this.txtRMatKhau = new System.Windows.Forms.TextBox();
            this.txtRMaNV = new System.Windows.Forms.TextBox();
            this.taiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hTQLYMKTDataSet = new HTQLMKT1.HTQLYMKTDataSet();
            this.btnRHuy = new System.Windows.Forms.Button();
            this.btnRXem = new System.Windows.Forms.Button();
            this.taiKhoanTableAdapter = new HTQLMKT1.HTQLYMKTDataSetTableAdapters.TaiKhoanTableAdapter();
            this.hTQLYMKTDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Tài Khoản ";
            // 
            // txtRMaTK
            // 
            this.txtRMaTK.Location = new System.Drawing.Point(274, 58);
            this.txtRMaTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRMaTK.Name = "txtRMaTK";
            this.txtRMaTK.Size = new System.Drawing.Size(215, 22);
            this.txtRMaTK.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Khách Hàng ";
            // 
            // txtRMaKH
            // 
            this.txtRMaKH.Location = new System.Drawing.Point(176, 144);
            this.txtRMaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRMaKH.Name = "txtRMaKH";
            this.txtRMaKH.Size = new System.Drawing.Size(159, 22);
            this.txtRMaKH.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(369, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên Đăng Nhập ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(380, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mật Khẩu ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Mã Nhân Viên ";
            // 
            // txtRTenDN
            // 
            this.txtRTenDN.Location = new System.Drawing.Point(516, 140);
            this.txtRTenDN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRTenDN.Name = "txtRTenDN";
            this.txtRTenDN.Size = new System.Drawing.Size(170, 22);
            this.txtRTenDN.TabIndex = 7;
            // 
            // txtRMatKhau
            // 
            this.txtRMatKhau.Location = new System.Drawing.Point(516, 238);
            this.txtRMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRMatKhau.Name = "txtRMatKhau";
            this.txtRMatKhau.Size = new System.Drawing.Size(170, 22);
            this.txtRMatKhau.TabIndex = 8;
            // 
            // txtRMaNV
            // 
            this.txtRMaNV.Location = new System.Drawing.Point(176, 242);
            this.txtRMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRMaNV.Name = "txtRMaNV";
            this.txtRMaNV.Size = new System.Drawing.Size(159, 22);
            this.txtRMaNV.TabIndex = 9;
            // 
            // taiKhoanBindingSource
            // 
            this.taiKhoanBindingSource.DataMember = "TaiKhoan";
            this.taiKhoanBindingSource.DataSource = this.hTQLYMKTDataSet;
            // 
            // hTQLYMKTDataSet
            // 
            this.hTQLYMKTDataSet.DataSetName = "HTQLYMKTDataSet";
            this.hTQLYMKTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRHuy
            // 
            this.btnRHuy.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRHuy.Location = new System.Drawing.Point(595, 304);
            this.btnRHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRHuy.Name = "btnRHuy";
            this.btnRHuy.Size = new System.Drawing.Size(91, 27);
            this.btnRHuy.TabIndex = 11;
            this.btnRHuy.Text = "Hủy";
            this.btnRHuy.UseVisualStyleBackColor = false;
            this.btnRHuy.Click += new System.EventHandler(this.btnRHuy_Click);
            // 
            // btnRXem
            // 
            this.btnRXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnRXem.Location = new System.Drawing.Point(327, 101);
            this.btnRXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRXem.Name = "btnRXem";
            this.btnRXem.Size = new System.Drawing.Size(91, 26);
            this.btnRXem.TabIndex = 12;
            this.btnRXem.Text = "Xem";
            this.btnRXem.UseVisualStyleBackColor = false;
            this.btnRXem.Click += new System.EventHandler(this.btnRXem_Click);
            // 
            // taiKhoanTableAdapter
            // 
            this.taiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // hTQLYMKTDataSetBindingSource
            // 
            this.hTQLYMKTDataSetBindingSource.DataSource = this.hTQLYMKTDataSet;
            this.hTQLYMKTDataSetBindingSource.Position = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.LightCoral;
            this.label6.Location = new System.Drawing.Point(184, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(370, 29);
            this.label6.TabIndex = 13;
            this.label6.Text = "XEM THÔNG TIN TÀI KHOẢN ";
            // 
            // RQLTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HTQLMKT1.Properties.Resources.imapmo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnRXem);
            this.Controls.Add(this.btnRHuy);
            this.Controls.Add(this.txtRMaNV);
            this.Controls.Add(this.txtRMatKhau);
            this.Controls.Add(this.txtRTenDN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRMaKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRMaTK);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RQLTK";
            this.Text = "RQLTK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RQLTK_FormClosing);
            this.Load += new System.EventHandler(this.RQLTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRMaTK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRMaKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRTenDN;
        private System.Windows.Forms.TextBox txtRMatKhau;
        private System.Windows.Forms.TextBox txtRMaNV;
        private System.Windows.Forms.Button btnRHuy;
        private System.Windows.Forms.Button btnRXem;
        private HTQLYMKTDataSet hTQLYMKTDataSet;
        private System.Windows.Forms.BindingSource taiKhoanBindingSource;
        private HTQLYMKTDataSetTableAdapters.TaiKhoanTableAdapter taiKhoanTableAdapter;
        private System.Windows.Forms.BindingSource hTQLYMKTDataSetBindingSource;
        private System.Windows.Forms.Label label6;
    }
}