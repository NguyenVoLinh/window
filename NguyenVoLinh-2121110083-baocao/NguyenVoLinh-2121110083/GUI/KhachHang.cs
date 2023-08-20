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
    public partial class KhachHang : Form
    {
        KhachHangBAL cusBAL = new KhachHangBAL();
        public KhachHang()
        {
            InitializeComponent();
            dgvKH.RowsDefaultCellStyle.BackColor = Color.LightGray; // Thay đổi màu nền của các hàng trong DataGridView thành LightGray
            dgvKH.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Thay đổi màu nền của các hàng lẻ thành White
            dgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvKH.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        //hàm kiểm tra nếu để trống thông tin thì báo lỗi
        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(tbMa.Text)
                && !string.IsNullOrWhiteSpace(tbTen.Text)
                && !string.IsNullOrWhiteSpace(tbDc.Text)
                && !string.IsNullOrWhiteSpace(tbSdt.Text);
        }
        private void btNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreAllFieldsFilled())
                {
                    KhachHangBEL cus = new KhachHangBEL();
                    cus.makhach = int.Parse(tbMa.Text);
                    cus.tenkhach = tbTen.Text;
                    cus.diachi = tbDc.Text;
                    cus.sodienthoai = int.Parse(tbSdt.Text);
                    cusBAL.NewKhachhang(cus);
                    dgvKH.Rows.Add(cus.makhach, cus.tenkhach, cus.diachi, cus.sodienthoai);
                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvKH.CurrentRow;
                if (row != null)
                {
                    // Check if the selected row contains data
                    if (row.Cells[0].Value != null)
                    {
                        int khachhangId = int.Parse(row.Cells[0].Value.ToString());

                        // Delete the customer from the database
                        KhachHangBEL khachhangToDelete = cusBAL.GetKhachHangId(khachhangId);
                        if (khachhangToDelete != null)
                        {
                            cusBAL.DeleteKhachhang(khachhangToDelete);
                        }

                        // Remove the customer from the DataGridView
                        dgvKH.Rows.RemoveAt(row.Index);
                        MessageBox.Show("Xoá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void btEdit_Click(object sender, EventArgs e)
        {

            try
            {
                DataGridViewRow row = dgvKH.CurrentRow;
                if (row != null)
                {
                    // Check if the selected row contains data
                    if (row.Cells[0].Value != null)
                    {
                        if (AreAllFieldsFilled())
                        {
                            KhachHangBEL cus = new KhachHangBEL();
                            cus.makhach = int.Parse(tbMa.Text);
                            cus.tenkhach = tbTen.Text;
                            cus.diachi = tbDc.Text;
                            cus.sodienthoai = int.Parse(tbSdt.Text);
                            cusBAL.EditKhachhang(cus);

                            row.Cells[0].Value = cus.makhach;
                            row.Cells[1].Value = cus.tenkhach;
                            row.Cells[2].Value = cus.diachi;
                            row.Cells[3].Value = cus.sodienthoai;
                            MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void KhachHang_Load(object sender, EventArgs e)
        {
            List<KhachHangBEL> lstCus = cusBAL.ReadKhachhangList();

            dgvKH.Rows.Clear();

            foreach (KhachHangBEL cus in lstCus)
            {

                dgvKH.Rows.Add(cus.makhach, cus.tenkhach, cus.diachi, cus.sodienthoai);
            }
            //// Xoá các hàng hiện có trong DataGridView
           

            tbMa.KeyPress += TextBox_KeyPress;
            tbTen.KeyPress += TextBox_KeyPress;
            tbDc.KeyPress += TextBox_KeyPress;
            tbSdt.KeyPress += TextBox_KeyPress;

            dgvKH.RowEnter += dgvKH_RowEnter;

            //mã
            tbMa.Validating += tbMa_Validating;
            //ten
            tbTen.Validating += tbTen_Validating;
            //địa chỉ
            tbDc.Validating += tbDc_Validating;

            //sdt
            tbSdt.Validating += tbSdt_Validating;
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

        private void dgvKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvKH.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbMa.Text = row.Cells[0].Value.ToString();
                tbTen.Text = row.Cells[1].Value.ToString();
                tbDc.Text = row.Cells[2].Value.ToString();
                tbSdt.Text = row.Cells[3].Value.ToString();

            }
            else
            {
                tbMa.Text = null;
                tbTen.Text = null;
                tbDc.Text = null;
                tbSdt.Text = null;

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
            foreach (DataGridViewRow row in dgvKH.Rows)
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
        private void tbDc_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateAddressInput(tbDc.Text))
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
