namespace HTQLMKT1
{
    partial class UQLTK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UQLTK));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUMaTK = new System.Windows.Forms.TextBox();
            this.txtUMaKH = new System.Windows.Forms.TextBox();
            this.txtUTenDNKH = new System.Windows.Forms.TextBox();
            this.txtUMatKhau = new System.Windows.Forms.TextBox();
            this.txtUMaNV = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mATKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tENDANGNHAPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATKHAUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mAKHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mANVDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taiKhoanBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.hTQLYMKTDataSet1 = new HTQLMKT1.HTQLYMKTDataSet1();
            this.btnUSua = new System.Windows.Forms.Button();
            this.btnUHuy = new System.Windows.Forms.Button();
            this.hTQLYMKTDataSet = new HTQLMKT1.HTQLYMKTDataSet();
            this.taiKhoanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taiKhoanTableAdapter = new HTQLMKT1.HTQLYMKTDataSetTableAdapters.TaiKhoanTableAdapter();
            this.taiKhoanTableAdapter1 = new HTQLMKT1.HTQLYMKTDataSet1TableAdapters.TaiKhoanTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Tài Khoản ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Khách Hàng ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Đăng Nhập ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(390, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mật Khẩu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã Nhân Viên";
            // 
            // txtUMaTK
            // 
            this.txtUMaTK.Location = new System.Drawing.Point(193, 34);
            this.txtUMaTK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUMaTK.Name = "txtUMaTK";
            this.txtUMaTK.Size = new System.Drawing.Size(156, 22);
            this.txtUMaTK.TabIndex = 5;
            // 
            // txtUMaKH
            // 
            this.txtUMaKH.Location = new System.Drawing.Point(528, 86);
            this.txtUMaKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUMaKH.Name = "txtUMaKH";
            this.txtUMaKH.Size = new System.Drawing.Size(156, 22);
            this.txtUMaKH.TabIndex = 6;
            // 
            // txtUTenDNKH
            // 
            this.txtUTenDNKH.Location = new System.Drawing.Point(193, 90);
            this.txtUTenDNKH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUTenDNKH.Name = "txtUTenDNKH";
            this.txtUTenDNKH.Size = new System.Drawing.Size(156, 22);
            this.txtUTenDNKH.TabIndex = 7;
            // 
            // txtUMatKhau
            // 
            this.txtUMatKhau.Location = new System.Drawing.Point(529, 146);
            this.txtUMatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUMatKhau.Name = "txtUMatKhau";
            this.txtUMatKhau.Size = new System.Drawing.Size(156, 22);
            this.txtUMatKhau.TabIndex = 8;
            // 
            // txtUMaNV
            // 
            this.txtUMaNV.Location = new System.Drawing.Point(193, 146);
            this.txtUMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUMaNV.Name = "txtUMaNV";
            this.txtUMaNV.Size = new System.Drawing.Size(156, 22);
            this.txtUMaNV.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mATKDataGridViewTextBoxColumn,
            this.tENDANGNHAPDataGridViewTextBoxColumn,
            this.mATKHAUDataGridViewTextBoxColumn,
            this.mAKHDataGridViewTextBoxColumn,
            this.mANVDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.taiKhoanBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(53, 210);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(498, 120);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // mATKDataGridViewTextBoxColumn
            // 
            this.mATKDataGridViewTextBoxColumn.DataPropertyName = "MATK";
            this.mATKDataGridViewTextBoxColumn.HeaderText = "MATK";
            this.mATKDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mATKDataGridViewTextBoxColumn.Name = "mATKDataGridViewTextBoxColumn";
            this.mATKDataGridViewTextBoxColumn.Width = 125;
            // 
            // tENDANGNHAPDataGridViewTextBoxColumn
            // 
            this.tENDANGNHAPDataGridViewTextBoxColumn.DataPropertyName = "TENDANGNHAP";
            this.tENDANGNHAPDataGridViewTextBoxColumn.HeaderText = "TENDANGNHAP";
            this.tENDANGNHAPDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tENDANGNHAPDataGridViewTextBoxColumn.Name = "tENDANGNHAPDataGridViewTextBoxColumn";
            this.tENDANGNHAPDataGridViewTextBoxColumn.Width = 125;
            // 
            // mATKHAUDataGridViewTextBoxColumn
            // 
            this.mATKHAUDataGridViewTextBoxColumn.DataPropertyName = "MATKHAU";
            this.mATKHAUDataGridViewTextBoxColumn.HeaderText = "MATKHAU";
            this.mATKHAUDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mATKHAUDataGridViewTextBoxColumn.Name = "mATKHAUDataGridViewTextBoxColumn";
            this.mATKHAUDataGridViewTextBoxColumn.Width = 125;
            // 
            // mAKHDataGridViewTextBoxColumn
            // 
            this.mAKHDataGridViewTextBoxColumn.DataPropertyName = "MAKH";
            this.mAKHDataGridViewTextBoxColumn.HeaderText = "MAKH";
            this.mAKHDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mAKHDataGridViewTextBoxColumn.Name = "mAKHDataGridViewTextBoxColumn";
            this.mAKHDataGridViewTextBoxColumn.Width = 125;
            // 
            // mANVDataGridViewTextBoxColumn
            // 
            this.mANVDataGridViewTextBoxColumn.DataPropertyName = "MANV";
            this.mANVDataGridViewTextBoxColumn.HeaderText = "MANV";
            this.mANVDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mANVDataGridViewTextBoxColumn.Name = "mANVDataGridViewTextBoxColumn";
            this.mANVDataGridViewTextBoxColumn.Width = 125;
            // 
            // taiKhoanBindingSource1
            // 
            this.taiKhoanBindingSource1.DataMember = "TaiKhoan";
            this.taiKhoanBindingSource1.DataSource = this.hTQLYMKTDataSet1;
            // 
            // hTQLYMKTDataSet1
            // 
            this.hTQLYMKTDataSet1.DataSetName = "HTQLYMKTDataSet1";
            this.hTQLYMKTDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUSua
            // 
            this.btnUSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnUSua.Location = new System.Drawing.Point(605, 264);
            this.btnUSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUSua.Name = "btnUSua";
            this.btnUSua.Size = new System.Drawing.Size(92, 26);
            this.btnUSua.TabIndex = 11;
            this.btnUSua.Text = "Sửa";
            this.btnUSua.UseVisualStyleBackColor = false;
            this.btnUSua.Click += new System.EventHandler(this.btnUSua_Click);
            // 
            // btnUHuy
            // 
            this.btnUHuy.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnUHuy.Location = new System.Drawing.Point(605, 303);
            this.btnUHuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUHuy.Name = "btnUHuy";
            this.btnUHuy.Size = new System.Drawing.Size(92, 26);
            this.btnUHuy.TabIndex = 12;
            this.btnUHuy.Text = "Hủy";
            this.btnUHuy.UseVisualStyleBackColor = false;
            this.btnUHuy.Click += new System.EventHandler(this.btnUHuy_Click);
            // 
            // hTQLYMKTDataSet
            // 
            this.hTQLYMKTDataSet.DataSetName = "HTQLYMKTDataSet";
            this.hTQLYMKTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taiKhoanBindingSource
            // 
            this.taiKhoanBindingSource.DataMember = "TaiKhoan";
            this.taiKhoanBindingSource.DataSource = this.hTQLYMKTDataSet;
            // 
            // taiKhoanTableAdapter
            // 
            this.taiKhoanTableAdapter.ClearBeforeFill = true;
            // 
            // taiKhoanTableAdapter1
            // 
            this.taiKhoanTableAdapter1.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(396, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 28);
            this.button1.TabIndex = 13;
            this.button1.Text = "Tìm ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UQLTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HTQLMKT1.Properties.Resources.imapmo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUHuy);
            this.Controls.Add(this.btnUSua);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtUMaNV);
            this.Controls.Add(this.txtUMatKhau);
            this.Controls.Add(this.txtUTenDNKH);
            this.Controls.Add(this.txtUMaKH);
            this.Controls.Add(this.txtUMaTK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UQLTK";
            this.Text = "UQLTK";
            this.Load += new System.EventHandler(this.UQLTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTQLYMKTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taiKhoanBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUMaTK;
        private System.Windows.Forms.TextBox txtUMaKH;
        private System.Windows.Forms.TextBox txtUTenDNKH;
        private System.Windows.Forms.TextBox txtUMatKhau;
        private System.Windows.Forms.TextBox txtUMaNV;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUSua;
        private System.Windows.Forms.Button btnUHuy;
        private HTQLYMKTDataSet hTQLYMKTDataSet;
        private System.Windows.Forms.BindingSource taiKhoanBindingSource;
        private HTQLYMKTDataSetTableAdapters.TaiKhoanTableAdapter taiKhoanTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tENDANGNHAPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATKHAUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAKHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mANVDataGridViewTextBoxColumn;
        private HTQLYMKTDataSet1 hTQLYMKTDataSet1;
        private System.Windows.Forms.BindingSource taiKhoanBindingSource1;
        private HTQLYMKTDataSet1TableAdapters.TaiKhoanTableAdapter taiKhoanTableAdapter1;
        private System.Windows.Forms.Button button1;
    }
}