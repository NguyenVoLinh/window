using NguyenVoLinh_2121110083.BAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenVoLinh_2121110083.GUI
{
    public partial class DanhMuc : Form
    {
        DanhMucBAL cusBAL = new DanhMucBAL();
        public DanhMuc()
        {
            InitializeComponent();
            dgvNCC.RowsDefaultCellStyle.BackColor = Color.LightGray; // Thay đổi màu nền của các hàng trong DataGridView thành LightGray
            dgvNCC.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Thay đổi màu nền của các hàng lẻ thành White
            dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvNCC.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }


        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(tbMa.Text)
                && !string.IsNullOrWhiteSpace(tbTen.Text)
                && !string.IsNullOrWhiteSpace(tbDiachi.Text)
                && !string.IsNullOrWhiteSpace(tbSdt.Text);
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            //DanhMucBEL cus = new DanhMucBEL();
            //cus.id = int.Parse(tbMa.Text);
            //cus.name = tbTen.Text;
            //cus.diachi = tbDiachi.Text;
            //cus.sodienthoai = int.Parse(tbSdt.Text);
            //cusBAL.NewDanhmuc(cus);
            //dgvNCC.Rows.Add(cus.id, cus.name, cus.diachi, cus.sodienthoai);


            try
            {
                if (AreAllFieldsFilled())
                {
                    DanhMucBEL cus = new DanhMucBEL();
                    cus.id = int.Parse(tbMa.Text);
                    cus.name = tbTen.Text;
                    cus.diachi = tbDiachi.Text;
                    cus.sodienthoai = int.Parse(tbSdt.Text);
                    cusBAL.NewDanhmuc(cus);
                    dgvNCC.Rows.Add(cus.id, cus.name, cus.diachi, cus.sodienthoai);

                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng thêm lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        private void DanhMuc_Load(object sender, EventArgs e)
        {
            List<DanhMucBEL> lstCus = cusBAL.ReadDanhmucList();

            // Clear the existing rows in the DataGridView
            dgvNCC.Rows.Clear();

            // Add the records from the database to the DataGridView
            foreach (DanhMucBEL cus in lstCus)
            {
                dgvNCC.Rows.Add(cus.id, cus.name, cus.diachi, cus.sodienthoai);
            }

            tbMa.KeyPress += TextBox_KeyPress;
            tbTen.KeyPress += TextBox_KeyPress;
            tbDiachi.KeyPress += TextBox_KeyPress;
            tbSdt.KeyPress += TextBox_KeyPress;

            dgvNCC.RowEnter += dgvCustomer_RowEnter;
            //mã
            tbMa.Validating += tbMa_Validating;
            //ten
            tbTen.Validating += tbTen_Validating;
            //địa chỉ
            tbDiachi.Validating += tbDiachi_Validating;
            //sdt
            tbSdt.Validating += tbSdt_Validating;



        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvNCC.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbMa.Text = row.Cells[0].Value.ToString();
                tbTen.Text = row.Cells[1].Value.ToString();
                tbDiachi.Text = row.Cells[2].Value.ToString();
                tbSdt.Text = row.Cells[3].Value.ToString();

            }
            else
            {
                tbMa.Text = null;
                tbTen.Text = null;
                tbDiachi.Text = null;
                tbSdt.Text = null;

            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextBox currentTextbox = sender as TextBox;
                if (currentTextbox != null)
                {
                    currentTextbox.Text = ""; // Clear the content of the current textbox
                    SelectNextControl(currentTextbox, true, true, true, true); // Move focus to the next control
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvNCC.CurrentRow;
                if (row != null)
                {
                    // Check if the selected row contains data
                    if (row.Cells[0].Value != null)
                    {
                        int danhmucId = int.Parse(row.Cells[0].Value.ToString());

                        // Delete the customer from the database
                        DanhMucBEL danhmucToDelete = cusBAL.GetDanhmucId(danhmucId);
                        if (danhmucToDelete != null)
                        {
                            cusBAL.DeleteDanhmuc(danhmucToDelete);
                        }

                        // Remove the customer from the DataGridView
                        dgvNCC.Rows.RemoveAt(row.Index);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn ô có dữ liệu để xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng xoá lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //DataGridViewRow row = dgvNCC.CurrentRow;
            //if (row != null)
            //{
            //    int danhmucId = int.Parse(row.Cells[0].Value.ToString());

            //    // Delete the customer from the database
            //    DanhMucBEL danhmucToDelete = cusBAL.GetDanhmucId(danhmucId);
            //    if (danhmucToDelete != null)
            //    {
            //        cusBAL.DeleteDanhmuc(danhmucToDelete);
            //    }

            //    // Remove the customer from the DataGridView
            //    dgvNCC.Rows.RemoveAt(row.Index);
            //}
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            //DataGridViewRow row = dgvNCC.CurrentRow;
            //if (row != null)
            //{
            //    DanhMucBEL cus = new DanhMucBEL();
            //    cus.id = int.Parse(tbMa.Text);
            //    cus.name = tbTen.Text;
            //    cus.diachi = tbDiachi.Text;
            //    cus.sodienthoai = int.Parse(tbSdt.Text);
            //    cusBAL.EditDanhmuc(cus);

            //    row.Cells[0].Value = cus.id;
            //    row.Cells[1].Value = cus.name;
            //    row.Cells[2].Value = cus.sodienthoai;
            //    row.Cells[3].Value = cus.diachi;

            //}


            try
            {
                DataGridViewRow row = dgvNCC.CurrentRow;
                if (row != null)
                {
                    // Check if the selected row contains data
                    if (row.Cells[0].Value != null)
                    {
                        if (AreAllFieldsFilled())
                        {
                            DanhMucBEL cus = new DanhMucBEL();
                            cus.id = int.Parse(tbMa.Text);
                            cus.name = tbTen.Text;
                            cus.diachi = tbDiachi.Text;
                            cus.sodienthoai = int.Parse(tbSdt.Text);
                            cusBAL.EditDanhmuc(cus);

                            row.Cells[0].Value = cus.id;
                            row.Cells[1].Value = cus.name;
                            row.Cells[2].Value = cus.diachi;
                            row.Cells[3].Value = cus.sodienthoai;
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn ô có dữ liệu để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }




        public int danhmucId { get; set; }

        //ràng buộc mã
        // ...

        private bool ValidateNumericInput(string input)
        {
            // Check if the input contains only numeric characters
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }
        private bool IsDuplicateId(int id)
        {
            foreach (DataGridViewRow row in dgvNCC.Rows)
            {
                if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == id)
                {
                    return true;
                }
            }
            return false;
        }
        private void tbMa_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateNumericInput(tbMa.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng nhập mã bằng số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int newId = int.Parse(tbMa.Text);
                if (IsDuplicateId(newId))
                {
                    e.Cancel = true;
                    MessageBox.Show("Mã đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        // ràng buộc tên

        private bool ValidateNameInput(string input)
        {
            // Check if the input contains only letters and spaces
            if (!string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                return true;
            }
            return false;
        }
        private void tbTen_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateNameInput(tbTen.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng chỉ nhập tên nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                e.Cancel = false;
            }
        }
        //địa chỉ
        private bool ValidateAddressInput(string input)
        {
            // Check if the input contains only letters, spaces, and numbers
            if (!string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsDigit(c)))
            {
                return true;
            }
            return false;
        }
        private void tbDiachi_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateAddressInput(tbDiachi.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng chỉ nhập địa chỉ bằng chữ, số và khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                e.Cancel = false;
            }
        }
        //sdt
        private bool ValidatePhoneNumberInput(string input)
        {
            // Check if the input contains only numeric characters
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }

        private void tbSdt_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatePhoneNumberInput(tbSdt.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng chỉ nhập số điện thoại bằng chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                e.Cancel = false;
            }
        }

    }
}
