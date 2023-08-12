namespace baitap
{
    partial class _130_gdht
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
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lbMa = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.lbTuoi = new System.Windows.Forms.Label();
            this.TBMa = new System.Windows.Forms.TextBox();
            this.TBTen = new System.Windows.Forms.TextBox();
            this.TBTuoi = new System.Windows.Forms.TextBox();
            this.cbNam = new System.Windows.Forms.CheckBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4});
            this.dgvEmployee.Location = new System.Drawing.Point(54, 12);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowTemplate.Height = 24;
            this.dgvEmployee.Size = new System.Drawing.Size(643, 150);
            this.dgvEmployee.TabIndex = 0;
            this.dgvEmployee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Ma";
            this.Column1.HeaderText = "Mã Nhân Viên ";
            this.Column1.Name = "Column1";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Tuoi";
            this.Column3.HeaderText = "Tuổi";
            this.Column3.Name = "Column3";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Ten";
            this.Column2.HeaderText = "Tên Nhân Viên";
            this.Column2.Name = "Column2";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "none";
            this.Column4.HeaderText = "Gioi Tính";
            this.Column4.Name = "Column4";
            // 
            // lbMa
            // 
            this.lbMa.AutoSize = true;
            this.lbMa.Location = new System.Drawing.Point(54, 202);
            this.lbMa.Name = "lbMa";
            this.lbMa.Size = new System.Drawing.Size(27, 17);
            this.lbMa.TabIndex = 1;
            this.lbMa.Text = "Mã";
            this.lbMa.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Location = new System.Drawing.Point(54, 239);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(33, 17);
            this.lbTen.TabIndex = 1;
            this.lbTen.Text = "Tên";
            // 
            // lbTuoi
            // 
            this.lbTuoi.AutoSize = true;
            this.lbTuoi.Location = new System.Drawing.Point(51, 279);
            this.lbTuoi.Name = "lbTuoi";
            this.lbTuoi.Size = new System.Drawing.Size(36, 17);
            this.lbTuoi.TabIndex = 1;
            this.lbTuoi.Text = "Tuổi";
            // 
            // TBMa
            // 
            this.TBMa.Location = new System.Drawing.Point(154, 196);
            this.TBMa.Name = "TBMa";
            this.TBMa.Size = new System.Drawing.Size(179, 22);
            this.TBMa.TabIndex = 2;
            this.TBMa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // TBTen
            // 
            this.TBTen.Location = new System.Drawing.Point(154, 234);
            this.TBTen.Name = "TBTen";
            this.TBTen.Size = new System.Drawing.Size(343, 22);
            this.TBTen.TabIndex = 2;
            // 
            // TBTuoi
            // 
            this.TBTuoi.Location = new System.Drawing.Point(154, 274);
            this.TBTuoi.Name = "TBTuoi";
            this.TBTuoi.Size = new System.Drawing.Size(179, 22);
            this.TBTuoi.TabIndex = 2;
            this.TBTuoi.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // cbNam
            // 
            this.cbNam.AutoSize = true;
            this.cbNam.Location = new System.Drawing.Point(154, 321);
            this.cbNam.Name = "cbNam";
            this.cbNam.Size = new System.Drawing.Size(59, 21);
            this.cbNam.TabIndex = 3;
            this.cbNam.Text = "Nam";
            this.cbNam.UseVisualStyleBackColor = true;
            this.cbNam.CheckedChanged += new System.EventHandler(this.cbNam_CheckedChanged);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(539, 343);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(107, 40);
            this.btThem.TabIndex = 4;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(665, 343);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(107, 40);
            this.btXoa.TabIndex = 4;
            this.btXoa.Text = "xoá";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(783, 343);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(107, 40);
            this.btSua.TabIndex = 4;
            this.btSua.Text = "sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _130_gdht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.cbNam);
            this.Controls.Add(this.TBTuoi);
            this.Controls.Add(this.TBTen);
            this.Controls.Add(this.TBMa);
            this.Controls.Add(this.lbTuoi);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.lbMa);
            this.Controls.Add(this.dgvEmployee);
            this.Name = "_130_gdht";
            this.Text = "_130_gdht";
            this.Load += new System.EventHandler(this._130_gdht_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Label lbMa;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.Label lbTuoi;
        private System.Windows.Forms.TextBox TBMa;
        private System.Windows.Forms.TextBox TBTen;
        private System.Windows.Forms.TextBox TBTuoi;
        private System.Windows.Forms.CheckBox cbNam;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.Button button1;

    }
}