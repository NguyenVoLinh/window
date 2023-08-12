using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace baitap
{
    public partial class _130_gdht : Form
    {
        //List<Employee> lst;
        //ArrayList lstEm;
      
        //public List<Employee> GetData()
        //{
        //    List<Employee> lst = new List<Employee>();
        //    Employee em = new Employee();
        //    em.Ma = "1234";
        //    em.Ten = "Trần Tiến";
        //    em.Tuoi = 20;
        //    lst.Add(em);

        //    em = new Employee();
        //    em.Ma = "2345";
        //    em.Ten = "Nguyễn Cường";
        //    em.Tuoi = 21;
        //    lst.Add(em);

        //    em = new Employee();
        //    em.Ma = "2456";
        //    em.Ten = "Nguyễn Hào";
        //    em.Tuoi = 23;
        //    lst.Add(em);
        //    return lst;


        //}
        public _130_gdht()
        {
            InitializeComponent();
            dgvEmployee.CellClick+= dgvEmployee_CellContentClick;
            
        }

        private void _130_gdht_Load(object sender, EventArgs e)
        {
            //lst = GetData();
            //foreach (Employee em in lst)
            //{
            //    dgvEmployee.Rows.Add(em.Ma, em.Ten, em.Tuoi);
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int idx = e.RowIndex;
            //lbMa.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
            //lbTen.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
            //lbTuoi.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
            //cbNam.Checked = bool.Parse(dgvEmployee.Rows[idx].Cells[3].Value.ToString());


            //int idx = e.RowIndex;
            //txtMa.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
            //txtTen.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
            //txtTuoi.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
            //checkGT.Checked = bool.Parse(dgvEmployee.Rows[idx].Cells[3].Value.ToString());

            //if (e.RowIndex >= 0 && e.RowIndex < dgvEmployee.Rows.Count)
            //{
            //    // Clear previous selection
            //    dgvEmployee.ClearSelection();

            //    // Select the entire row
            //    dgvEmployee.Rows[e.RowIndex].Selected = true;

            //    // Highlight the remaining cells in the row
            //    for (int colIndex = 0; colIndex < dgvEmployee.Columns.Count; colIndex++)
            //    {
            //        if (colIndex != e.ColumnIndex)
            //        {
            //            dgvEmployee.Rows[e.RowIndex].Cells[colIndex].Style.BackColor = Color.Yellow;
            //        }
            //    }
            //}

            if (e.RowIndex < 0 || e.RowIndex >= dgvEmployee.Rows.Count)
                return; // Return if the row index is out of range (e.g., header clicked)

            int idx = e.RowIndex;

            // Check if the cell value is null or empty
            if (dgvEmployee.Rows[idx].Cells[0].Value == null || string.IsNullOrEmpty(dgvEmployee.Rows[idx].Cells[0].Value.ToString()))
                return; // Return if the cell doesn't have data

            TBMa.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
            TBTen.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
            TBTuoi.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
            cbNam.Checked = bool.Parse(dgvEmployee.Rows[idx].Cells[3].Value.ToString());

            // The remaining code for row selection and highlighting (as in the previous version) can stay here
            if (e.RowIndex >= 0 && e.RowIndex < dgvEmployee.Rows.Count)
            {
                // Clear previous selection
                dgvEmployee.ClearSelection();

                // Select the entire row
                dgvEmployee.Rows[e.RowIndex].Selected = true;

                // Highlight the remaining cells in the row
                for (int colIndex = 0; colIndex < dgvEmployee.Columns.Count; colIndex++)
                {
                    if (colIndex != e.ColumnIndex)
                    {
                        dgvEmployee.Rows[e.RowIndex].Cells[colIndex].Style.BackColor = Color.Aqua;
                    }
                }
            }


           

        }

        private void btThem_Click(object sender, EventArgs e)
        {

            //Employee em = new Employee();
            //em.Ma = TBMa.Text;
            //em.Ten=TBTen.Text;
            //em.Tuoi=int.Parse(TBTuoi.Text);
            //em.GioiTinh=cbNam.Checked;
            //lst.Add(em);
            if (KiemTraThongTin())
            {
                dgvEmployee.Rows.Add(TBMa.Text, TBTen.Text, TBTuoi.Text, cbNam.Checked);
            }
           
          
        }

        private void cbNam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int idx = dgvEmployee.CurrentCell.RowIndex;
            if (idx >= 0 && idx < dgvEmployee.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvEmployee.Rows[idx];
                if (selectedRow.Cells[0].Value != null && !string.IsNullOrWhiteSpace(selectedRow.Cells[0].Value.ToString()))
                {
                    dgvEmployee.Rows.RemoveAt(idx);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn ô có dữ liệu để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ô có dữ liệu để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //int idx = dgvEmployee.CurrentCell.RowIndex;
            ////lst.RemoveAt(idx);
            //dgvEmployee.Rows.RemoveAt(idx);
            //MessageBox.Show("xoá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {

            if (KiemTraThongTin())
            {
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows[idx].Cells[0].Value = TBMa.Text;
                dgvEmployee.Rows[idx].Cells[1].Value = TBTen.Text;
                dgvEmployee.Rows[idx].Cells[2].Value = TBTuoi.Text;
                dgvEmployee.Rows[idx].Cells[3].Value = cbNam.Checked;
            }
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
        }
        public bool KiemTraThongTin()
        {


            if (TBMa.Text == "" || TBTen.Text == "" ||TBTuoi.Text == "" || !cbNam.Checked)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TBMa.Focus();
                return false;
            }
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (TBTen.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    TBTen.Focus();
            //    return false;
            //}
            //if (TBTuoi.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    TBTuoi.Focus();
            //    return false;
            //}
            //if (!cbNam.Checked )
            //{
            //    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
          
            
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
