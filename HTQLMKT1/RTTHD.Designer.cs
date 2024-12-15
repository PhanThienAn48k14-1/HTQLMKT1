namespace HTQLMKT1
{
    partial class RTTHD
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMAHDKH = new System.Windows.Forms.TextBox();
            this.btnXemMAHDKH = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mã hợp đồng";
            // 
            // txtMAHDKH
            // 
            this.txtMAHDKH.Location = new System.Drawing.Point(319, 133);
            this.txtMAHDKH.Name = "txtMAHDKH";
            this.txtMAHDKH.Size = new System.Drawing.Size(278, 20);
            this.txtMAHDKH.TabIndex = 1;
            // 
            // btnXemMAHDKH
            // 
            this.btnXemMAHDKH.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnXemMAHDKH.Location = new System.Drawing.Point(353, 228);
            this.btnXemMAHDKH.Name = "btnXemMAHDKH";
            this.btnXemMAHDKH.Size = new System.Drawing.Size(79, 31);
            this.btnXemMAHDKH.TabIndex = 2;
            this.btnXemMAHDKH.Text = "XEM";
            this.btnXemMAHDKH.UseVisualStyleBackColor = false;
            this.btnXemMAHDKH.Click += new System.EventHandler(this.btnXemMAHDKH_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(60, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(674, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // RTTHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnXemMAHDKH);
            this.Controls.Add(this.txtMAHDKH);
            this.Controls.Add(this.label1);
            this.Name = "RTTHD";
            this.Text = "RTTHD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMAHDKH;
        private System.Windows.Forms.Button btnXemMAHDKH;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}