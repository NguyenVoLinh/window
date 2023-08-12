namespace NguyenVoLinh_2121110083.GUI
{
    partial class HoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HoaDon));
            this.dgvhd = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSp = new System.Windows.Forms.ComboBox();
            this.tbMa = new System.Windows.Forms.TextBox();
            this.tbNgay = new System.Windows.Forms.TextBox();
            this.tbNv = new System.Windows.Forms.TextBox();
            this.tbTenkh = new System.Windows.Forms.TextBox();
            this.tbgia = new System.Windows.Forms.TextBox();
            this.tbsdt = new System.Windows.Forms.TextBox();
            this.btNew = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbsl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvhd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvhd
            // 
            this.dgvhd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvhd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvhd.Location = new System.Drawing.Point(3, 1);
            this.dgvhd.Name = "dgvhd";
            this.dgvhd.RowTemplate.Height = 24;
            this.dgvhd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvhd.Size = new System.Drawing.Size(1263, 286);
            this.dgvhd.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Mã hoá đơn";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Ngày lập hoá đơn";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Nhân viên lập";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Tên khách hàng";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Số điện thoại";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "Tên sản phẩm";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Gía";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Số lượng";
            this.Column8.Name = "Column8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(690, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(690, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên sản phẩm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mã hoá đơn";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 392);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên nhân viên lập HĐ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(690, 436);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Gía";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 352);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ngày lập hoá đơn";
            // 
            // cbSp
            // 
            this.cbSp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSp.FormattingEnabled = true;
            this.cbSp.Location = new System.Drawing.Point(842, 395);
            this.cbSp.Name = "cbSp";
            this.cbSp.Size = new System.Drawing.Size(206, 24);
            this.cbSp.TabIndex = 2;
            this.cbSp.SelectedIndexChanged += new System.EventHandler(this.cbSp_SelectedIndexChanged);
            // 
            // tbMa
            // 
            this.tbMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMa.Location = new System.Drawing.Point(192, 308);
            this.tbMa.Name = "tbMa";
            this.tbMa.Size = new System.Drawing.Size(277, 22);
            this.tbMa.TabIndex = 3;
            // 
            // tbNgay
            // 
            this.tbNgay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNgay.Location = new System.Drawing.Point(192, 350);
            this.tbNgay.Name = "tbNgay";
            this.tbNgay.Size = new System.Drawing.Size(277, 22);
            this.tbNgay.TabIndex = 3;
            // 
            // tbNv
            // 
            this.tbNv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNv.Location = new System.Drawing.Point(192, 395);
            this.tbNv.Name = "tbNv";
            this.tbNv.Size = new System.Drawing.Size(277, 22);
            this.tbNv.TabIndex = 3;
            // 
            // tbTenkh
            // 
            this.tbTenkh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTenkh.Location = new System.Drawing.Point(842, 314);
            this.tbTenkh.Name = "tbTenkh";
            this.tbTenkh.Size = new System.Drawing.Size(295, 22);
            this.tbTenkh.TabIndex = 3;
            // 
            // tbgia
            // 
            this.tbgia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbgia.Location = new System.Drawing.Point(842, 431);
            this.tbgia.Name = "tbgia";
            this.tbgia.Size = new System.Drawing.Size(206, 22);
            this.tbgia.TabIndex = 3;
            // 
            // tbsdt
            // 
            this.tbsdt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbsdt.Location = new System.Drawing.Point(842, 355);
            this.tbsdt.Name = "tbsdt";
            this.tbsdt.Size = new System.Drawing.Size(295, 22);
            this.tbsdt.TabIndex = 3;
            // 
            // btNew
            // 
            this.btNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btNew.Image = ((System.Drawing.Image)(resources.GetObject("btNew.Image")));
            this.btNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btNew.Location = new System.Drawing.Point(568, 527);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(96, 51);
            this.btNew.TabIndex = 4;
            this.btNew.Text = "Thêm ";
            this.btNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btDelete
            // 
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Image = ((System.Drawing.Image)(resources.GetObject("btDelete.Image")));
            this.btDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btDelete.Location = new System.Drawing.Point(726, 527);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(89, 51);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "Xoá";
            this.btDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btEdit
            // 
            this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEdit.Image = ((System.Drawing.Image)(resources.GetObject("btEdit.Image")));
            this.btEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEdit.Location = new System.Drawing.Point(864, 527);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(94, 51);
            this.btEdit.TabIndex = 4;
            this.btEdit.Text = "Sửa";
            this.btEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btExit
            // 
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
            this.btExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExit.Location = new System.Drawing.Point(1022, 527);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(97, 51);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "Thoát";
            this.btExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Số lượng";
            // 
            // tbsl
            // 
            this.tbsl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbsl.Location = new System.Drawing.Point(192, 434);
            this.tbsl.Name = "tbsl";
            this.tbsl.Size = new System.Drawing.Size(277, 22);
            this.tbsl.TabIndex = 3;
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 616);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.tbsl);
            this.Controls.Add(this.tbNv);
            this.Controls.Add(this.tbNgay);
            this.Controls.Add(this.tbsdt);
            this.Controls.Add(this.tbgia);
            this.Controls.Add(this.tbTenkh);
            this.Controls.Add(this.tbMa);
            this.Controls.Add(this.cbSp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvhd);
            this.Name = "HoaDon";
            this.Text = "DonMua";
            this.Load += new System.EventHandler(this.HoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvhd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvhd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSp;
        private System.Windows.Forms.TextBox tbMa;
        private System.Windows.Forms.TextBox tbNgay;
        private System.Windows.Forms.TextBox tbNv;
        private System.Windows.Forms.TextBox tbTenkh;
        private System.Windows.Forms.TextBox tbgia;
        private System.Windows.Forms.TextBox tbsdt;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}