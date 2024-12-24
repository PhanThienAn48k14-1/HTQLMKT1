using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
namespace HTQLMKT1
{
    partial class CQLHD
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDKHD = new System.Windows.Forms.TextBox();
            this.datetimeDKY = new System.Windows.Forms.DateTimePicker();
            this.datetimeHHAN = new System.Windows.Forms.DateTimePicker();
            this.txtMADVMKT = new System.Windows.Forms.TextBox();
            this.txtMAKH = new System.Windows.Forms.TextBox();
            this.txtMANV = new System.Windows.Forms.TextBox();
            this.btnTAO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Điều Khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày Đăng Ký";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày Hết Hạn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã Dịch Vụ Marketing";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã Khách Hàng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(43, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mã Nhân Viên";
            // 
            // txtDKHD
            // 
            this.txtDKHD.Location = new System.Drawing.Point(260, 42);
            this.txtDKHD.Name = "txtDKHD";
            this.txtDKHD.Size = new System.Drawing.Size(444, 20);
            this.txtDKHD.TabIndex = 8;
            // 
            // datetimeDKY
            // 
            this.datetimeDKY.Location = new System.Drawing.Point(259, 90);
            this.datetimeDKY.Name = "datetimeDKY";
            this.datetimeDKY.Size = new System.Drawing.Size(201, 20);
            this.datetimeDKY.TabIndex = 9;
            // 
            // datetimeHHAN
            // 
            this.datetimeHHAN.Location = new System.Drawing.Point(260, 148);
            this.datetimeHHAN.Name = "datetimeHHAN";
            this.datetimeHHAN.Size = new System.Drawing.Size(200, 20);
            this.datetimeHHAN.TabIndex = 10;
            // 
            // txtMADVMKT
            // 
            this.txtMADVMKT.Location = new System.Drawing.Point(260, 206);
            this.txtMADVMKT.Name = "txtMADVMKT";
            this.txtMADVMKT.Size = new System.Drawing.Size(444, 20);
            this.txtMADVMKT.TabIndex = 11;
            // 
            // txtMAKH
            // 
            this.txtMAKH.Location = new System.Drawing.Point(260, 261);
            this.txtMAKH.Name = "txtMAKH";
            this.txtMAKH.Size = new System.Drawing.Size(444, 20);
            this.txtMAKH.TabIndex = 12;
            // 
            // txtMANV
            // 
            this.txtMANV.Location = new System.Drawing.Point(260, 308);
            this.txtMANV.Name = "txtMANV";
            this.txtMANV.Size = new System.Drawing.Size(444, 20);
            this.txtMANV.TabIndex = 13;
            // 
            // btnTAO
            // 
            this.btnTAO.BackColor = System.Drawing.Color.Silver;
            this.btnTAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTAO.Location = new System.Drawing.Point(339, 374);
            this.btnTAO.Name = "btnTAO";
            this.btnTAO.Size = new System.Drawing.Size(90, 35);
            this.btnTAO.TabIndex = 14;
            this.btnTAO.Text = "TẠO";
            this.btnTAO.UseVisualStyleBackColor = false;
            this.btnTAO.Click += new System.EventHandler(this.btnTAO_Click);
            // 
            // CQLHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTAO);
            this.Controls.Add(this.txtMANV);
            this.Controls.Add(this.txtMAKH);
            this.Controls.Add(this.txtMADVMKT);
            this.Controls.Add(this.datetimeHHAN);
            this.Controls.Add(this.datetimeDKY);
            this.Controls.Add(this.txtDKHD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "CQLHD";
            this.Text = "CQLHD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDKHD;
        private System.Windows.Forms.DateTimePicker datetimeDKY;
        private System.Windows.Forms.DateTimePicker datetimeHHAN;
        private System.Windows.Forms.TextBox txtMADVMKT;
        private System.Windows.Forms.TextBox txtMAKH;
        private System.Windows.Forms.TextBox txtMANV;
        private System.Windows.Forms.Button btnTAO;
    }
}