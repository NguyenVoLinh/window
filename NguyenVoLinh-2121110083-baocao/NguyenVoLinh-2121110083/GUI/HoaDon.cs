using NguyenVoLinh_2121110083.BAL;
using NguyenVoLinh_2121110083.DAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NguyenVoLinh_2121110083.GUI
{
    public partial class HoaDon : Form
    {
        CustomerBAL spBAL = new CustomerBAL();
        HoaDonBAL cusBAL = new HoaDonBAL();
        DBConnection dbConnection = new DBConnection();

        // ràng buộc số điện thoại

        private void tbsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (like backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered
                MessageBox.Show("Vui lòng chỉ nhập số điện thoại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Allow only 10 to 11 digits
            if (!string.IsNullOrEmpty(tbsdt.Text) && tbsdt.Text.Length >= 11 && tbsdt.Text.Length <= 11)
            {
                e.Handled = true; // Prevent entering more than 11 digits
            }
        }



        // ràng buộc ngày lập hoá đơn
        private bool ValidateDateInput(string input)
        {
            DateTime date;
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                int year = date.Year;
                int month = date.Month;
                int day = date.Day;

                if (year >= 2000 && year <= 2050 && month >= 1 && month <= 12 && day >= 1 && day <= DateTime.DaysInMonth(year, month))
                {
                    return true;
                }
            }

            return false;
        }

        private void tbNgay_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateDateInput(tbNgay.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Ngày lập hoá đơn không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy và trong khoảng từ 01/01/2000 đến 31/12/2050.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public HoaDon()
        {
            InitializeComponent();
            dgvhd.RowsDefaultCellStyle.BackColor = Color.LightGray; // Thay đổi màu nền của các hàng trong DataGridView thành LightGray
            dgvhd.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Thay đổi màu nền của các hàng lẻ thành White
            dgvhd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvhd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (AreAllFieldsFilled())
                {
                    int newId = int.Parse(tbMa.Text);

                    // Check for duplicate ID before adding
                    if (IsDuplicateId(newId))
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    HoaDonBEL cus = new HoaDonBEL();
                    cus.id = newId;
                    cus.ngaylap = tbNgay.Text;
                    cus.nhanvienlap = tbNv.Text;
                    cus.tenkhachhang = tbTenkh.Text;
                    cus.sodienthoai = int.Parse(tbsdt.Text);
                    cus.customer = (CustomerBEL)cbSp.SelectedItem;
                    cus.gia = int.Parse(tbgia.Text);
                    cus.soluong = int.Parse(tbsl.Text);

                    cusBAL.NewHoadon(cus);
                    dgvhd.Rows.Add(cus.id, cus.ngaylap, cus.nhanvienlap, cus.tenkhachhang, cus.sodienthoai, cus.CustomerName, cus.gia, cus.soluong);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            List<HoaDonBEL> lstCus = cusBAL.ReadHoadon();

            // Clear the existing rows in the DataGridView
            dgvhd.Rows.Clear();

            // Add the records from the database to the DataGridView
            foreach (HoaDonBEL cus in lstCus)
            {
                dgvhd.Rows.Add(cus.id, cus.ngaylap, cus.nhanvienlap, cus.tenkhachhang, cus.sodienthoai, cus.CustomerName, cus.gia,cus.soluong);
            }
            List<CustomerBEL> lstsp = spBAL.ReadCustomerList();
            foreach (CustomerBEL sp in lstsp)
            {
                cbSp.Items.Add(sp);
            }
            cbSp.DisplayMember = "name";

            tbMa.KeyPress += TextBox_KeyPress;
            tbNgay.KeyPress += TextBox_KeyPress;
            tbNv.KeyPress += TextBox_KeyPress;
            tbTenkh.KeyPress += TextBox_KeyPress;
            tbsdt.KeyPress += TextBox_KeyPress;
            tbgia.KeyPress += TextBox_KeyPress;
            tbsl.KeyPress += TextBox_KeyPress;

            // Attach the event handler to ComboBox control
            cbSp.KeyPress += ComboBox_KeyPress;

            dgvhd.RowEnter += dgvhd_RowEnter;
            dgvhd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //ràng buộc ngày lập hoá đơn
            tbNgay.Validating += tbNgay_Validating;
            //ràng buộc giá
            tbgia.Validating += tbgia_Validating;

            //ràng buộc sdt
            tbsdt.KeyPress += tbsdt_KeyPress;

            //ràng buộc tên
            tbNv.Validating += tbNv_Validating;
            tbTenkh.Validating += tbTenkh_Validating;
            // ràng buộc số lượng
            tbsl.Validating += tbsl_Validating;
            // mã
            tbMa.Validating += tbMa_Validating;

           
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvhd.CurrentRow;
                if (row != null)
                {
                    // Check if the selected row contains data
                    if (row.Cells[0].Value != null)
                    {
                        int hoadonId = int.Parse(row.Cells[0].Value.ToString());

                        // Delete the customer from the database
                        HoaDonBEL hoadonToDelete = cusBAL.GetHoadonById(hoadonId);
                        if (hoadonToDelete != null)
                        {
                            cusBAL.DeleteHoadon(hoadonToDelete);
                        }

                        // Remove the customer from the DataGridView
                        dgvhd.Rows.RemoveAt(row.Index);
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
                DataGridViewRow row = dgvhd.CurrentRow;
                if (row != null)
                {
                    // Check if the selected row contains data
                    if (row.Cells[0].Value != null)
                    {
                        if (AreAllFieldsFilled())
                        {
                            HoaDonBEL cus = new HoaDonBEL();
                            cus.id = int.Parse(tbMa.Text);
                            cus.ngaylap = tbNgay.Text;
                            cus.nhanvienlap = tbNv.Text;
                            cus.tenkhachhang = tbTenkh.Text;
                            cus.sodienthoai = int.Parse(tbsdt.Text);
                            cus.customer = (CustomerBEL)cbSp.SelectedItem;
                            cus.gia = int.Parse(tbgia.Text);
                            cus.soluong = int.Parse(tbsl.Text);
                            cusBAL.EditHoadon(cus);

                            row.Cells[0].Value = cus.id;
                            row.Cells[1].Value = cus.ngaylap;
                            row.Cells[2].Value = cus.nhanvienlap;
                            row.Cells[3].Value = cus.tenkhachhang;
                            row.Cells[4].Value = cus.sodienthoai;
                            row.Cells[5].Value = cus.CustomerName;
                            row.Cells[6].Value = cus.gia;
                            row.Cells[7].Value = cus.soluong;
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
        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(tbMa.Text)
                && !string.IsNullOrWhiteSpace(tbNgay.Text)
                && !string.IsNullOrWhiteSpace(tbNv.Text)
                && !string.IsNullOrWhiteSpace(tbTenkh.Text)
                && !string.IsNullOrWhiteSpace(tbsdt.Text)
                && cbSp.SelectedItem != null

                && !string.IsNullOrWhiteSpace(tbgia.Text)
                && !string.IsNullOrWhiteSpace(tbsl.Text);

        }
        private void dgvhd_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvhd.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbMa.Text = row.Cells[0].Value.ToString();
                tbNgay.Text = row.Cells[1].Value.ToString();
                tbNv.Text = row.Cells[2].Value.ToString();
                tbTenkh.Text = row.Cells[3].Value.ToString();
                tbsdt.Text = row.Cells[4].Value.ToString();
                cbSp.Text = row.Cells[5].Value.ToString();
                tbgia.Text = row.Cells[6].Value.ToString();
                tbsl.Text = row.Cells[7].Value.ToString();


            }
            else
            {
                tbMa.Text = null;
                tbNgay.Text = null;
                tbNv.Text = null;
                tbTenkh.Text = null;
                tbsdt.Text = null;
                cbSp.SelectedItem = null;
                tbgia.Text = null;
                tbsl.Text = null;

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

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ComboBox currentComboBox = sender as ComboBox;
                if (currentComboBox != null)
                {
                    SelectNextControl(currentComboBox, true, true, true, true); // Move focus to the next control
                }
            }
        }
        //private bool IsDuplicateId(int id)
        //{
        //    foreach (DataGridViewRow row in dgvhd.Rows)
        //    {
        //        if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == id)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        //tạo ràng buộc tên
        private bool ValidateNameInput(string input)
        {
            // Check if the input contains only letters and spaces
            if (!string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                return true;
            }

            return false;
        }

        private void tbNv_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateNameInput(tbNv.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Tên nhân viên không hợp lệ. Vui lòng nhập tên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbTenkh_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateNameInput(tbTenkh.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Tên khách hàng không hợp lệ. Vui lòng nhập tên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //ràng buộc số lượng
        private bool ValidateQuantityInput(string input)
        {
            int quantity;
            if (int.TryParse(input, out quantity) && quantity >= 0)
            {
                return true;
            }

            return false;
        }
        private void tbsl_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateQuantityInput(tbsl.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng nhập số lượng khách hàng mua.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //ràng buộc giá

        private bool ValidateNumericPrice(string input)
        {
            // Check if the input contains only numeric characters
            if (!string.IsNullOrEmpty(input) && input.All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
        private void tbgia_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateNumericPrice(tbgia.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Giá không hợp lệ. Vui lòng chỉ nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //mã 
        private bool IsDuplicateId(int id)
        {
            foreach (DataGridViewRow row in dgvhd.Rows)
            {
                if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == id)
                {
                    return true;
                }
            }
            return false;
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

        private void tbMa_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidateNumericInput(tbMa.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng chỉ nhập số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int newId = int.Parse(tbMa.Text);
                if (IsDuplicateId(newId))
                {
                    e.Cancel = true;
                    MessageBox.Show("Mã hoá đơn đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void cbSp_SelectedIndexChanged(object sender, EventArgs e)
        {
             string str;
            if (cbSp.SelectedItem != null)
            {
                CustomerBEL selectedCustomer = (CustomerBEL)cbSp.SelectedItem;
                str = "SELECT Gia FROM Customer WHERE name = @Name";

                using (SqlConnection connection = dbConnection.CreateConnection())
                using (SqlCommand command = new SqlCommand(str, connection))
                {
                    command.Parameters.AddWithValue("@Name", selectedCustomer.Name);

                    try
                    {
                        connection.Open();
                        object queryResult = command.ExecuteScalar();
                        if (queryResult != null)
                        {
                            tbgia.Text = queryResult.ToString();
                        }
                        else
                        {
                            tbgia.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                tbgia.Text = "";
            }
        }

        }
}
