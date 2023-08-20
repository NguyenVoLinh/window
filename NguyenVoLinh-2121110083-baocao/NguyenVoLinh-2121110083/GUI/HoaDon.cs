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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace NguyenVoLinh_2121110083.GUI
{
    public partial class HoaDon : Form
    {
        CustomerBAL spBAL = new CustomerBAL();
        HoaDonBAL cusBAL = new HoaDonBAL();
        nhanvienBAL cusBAL1 = new nhanvienBAL();
        KhachHangBAL cusBAL2 = new KhachHangBAL();
        DBConnection dbConnection = new DBConnection();    
        
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
                    cus.ngaylap = date.Value.ToString("dd/MM/yyyy");
                cus.customer = (CustomerBEL)cbSp.SelectedItem;
                cus.sodienthoai = int.Parse(tbsdt.Text);
                cus.nv = (nhanvienBEL)cbnv.SelectedItem;
                    cus.kh = (KhachHangBEL)cbkh.SelectedItem;
                    cus.gia = int.Parse(tbgia.Text);
                    cus.soluong = int.Parse(tbsl.Text);
                    cus.tongtien = cus.gia * cus.soluong;

                    cusBAL.NewHoadon(cus);

                    dgvhd.Rows.Add(cus.id, cus.ngaylap, cus.nvid, cus.khid,  cus.sodienthoai, cus.CustomerName, cus.gia, cus.soluong, cus.tongtien);
                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgvhd.Rows.Add(cus.id, cus.ngaylap, cus.nvid, cus.khid, cus.sodienthoai, cus.CustomerName, cus.gia, cus.soluong, cus.tongtien);
            }
            List<CustomerBEL> lstsp = spBAL.ReadCustomerList();
            foreach (CustomerBEL sp in lstsp)
            {
                cbSp.Items.Add(sp);
            }
            cbSp.DisplayMember = "name";

            List<nhanvienBEL> lstsp1 = cusBAL1.ReadNhanvienList();
            foreach (nhanvienBEL sp in lstsp1)
            {
                cbnv.Items.Add(sp);
            }
            cbnv.DisplayMember = "tennhanvien";

            List<KhachHangBEL> lstsp2 = cusBAL2.ReadKhachhangList();
            foreach (KhachHangBEL sp in lstsp2)
            {
                cbkh.Items.Add(sp);
            }
            cbkh.DisplayMember = "tenkhach";

            tbMa.KeyPress += TextBox_KeyPress;
            date.KeyPress += TextBox_KeyPress;
            
            tbsdt.KeyPress += TextBox_KeyPress;
            tbgia.KeyPress += TextBox_KeyPress;
            tbsl.KeyPress += TextBox_KeyPress;

            // Attach the event handler to ComboBox control
            cbSp.KeyPress += ComboBox_KeyPress;
            cbkh.KeyPress += ComboBox_KeyPress;
            cbnv.KeyPress += ComboBox_KeyPress;

            dgvhd.RowEnter += dgvhd_RowEnter;
            dgvhd.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //ràng buộc ngày lập hoá đơn
            date.Format = DateTimePickerFormat.Custom;
            date.CustomFormat = "dd/MM/yyyy";
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

        //private void btEdit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataGridViewRow row = dgvhd.CurrentRow;
        //        if (row != null)
        //        {
        //            // Check if the selected row contains data
        //            if (row.Cells[0].Value != null)
        //            {
        //                if (AreAllFieldsFilled())
        //                {
        //                    HoaDonBEL cus = new HoaDonBEL();
        //                    cus.id = int.Parse(tbMa.Text);
        //                    cus.ngaylap = tbNgay.Text;
        //                    cus.nhanvienlap = tbNv.Text;
        //                    cus.tenkhachhang = tbTenkh.Text;
        //                    cus.sodienthoai = int.Parse(tbsdt.Text);
        //                    cus.customer = (CustomerBEL)cbSp.SelectedItem;
        //                    cus.gia = int.Parse(tbgia.Text);
        //                    cus.soluong = int.Parse(tbsl.Text);
        //                    cusBAL.EditHoadon(cus);

        //                    row.Cells[0].Value = cus.id;
        //                    row.Cells[1].Value = cus.ngaylap;
        //                    row.Cells[2].Value = cus.nhanvienlap;
        //                    row.Cells[3].Value = cus.tenkhachhang;
        //                    row.Cells[4].Value = cus.sodienthoai;
        //                    row.Cells[5].Value = cus.CustomerName;
        //                    row.Cells[6].Value = cus.gia;
        //                    row.Cells[7].Value = cus.soluong;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Vui lòng chọn ô có dữ liệu để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}


        //kiểm tra xem tất cả các trường dữ liệu (fields) trong giao diện người dùng có được điền đầy đủ thông tin hay không.
        private bool AreAllFieldsFilled()
        {
            return !string.IsNullOrWhiteSpace(tbMa.Text)
                && !string.IsNullOrWhiteSpace(date.Text)
                && !string.IsNullOrWhiteSpace(tbsdt.Text)
                && cbSp.SelectedItem != null
                && cbkh.SelectedItem != null
                && cbnv.SelectedItem != null

                && !string.IsNullOrWhiteSpace(tbgia.Text)
                && !string.IsNullOrWhiteSpace(tbsl.Text);

        }
        private void dgvhd_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //int idx = e.RowIndex;
            //DataGridViewRow row = dgvhd.Rows[idx];
            //if (row.Cells[0].Value != null)
            //{
            //    tbMa.Text = row.Cells[0].Value.ToString();
            //    date.Value = DateTime.ParseExact(row.Cells[1].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //    if (row.Cells[2].Value != null)
            //    {
            //        cbkh.Text = row.Cells[2].Value.ToString();
            //    }
            //    else
            //    {
            //        cbkh.Text = ""; // Set to an appropriate default value if needed
            //    }
            //    if (row.Cells[3].Value != null)
            //    {
            //        cbnv.Text = row.Cells[3].Value.ToString();
            //    }
            //    else
            //    {
            //        cbnv.Text = ""; // Set to an appropriate default value if needed
            //    }
            //    tbsdt.Text = row.Cells[4].Value.ToString();
            //    cbSp.Text = row.Cells[5].Value.ToString();
            //    tbgia.Text = row.Cells[6].Value.ToString();
            //    tbsl.Text = row.Cells[7].Value.ToString();


            //}
            //else
            //{
            //    tbMa.Text = null;
            //    date.Text = null;
            //    cbnv.Text = null;
            //    cbkh.Text = null;
            //    tbsdt.Text = null;
            //    cbSp.SelectedItem = null;
            //    tbgia.Text = null;
            //    tbsl.Text = null;

            //}
            int idx = e.RowIndex;
            DataGridViewRow row = dgvhd.Rows[idx];

            if (row.Cells[0].Value != null)
            {
                int hoadonId = int.Parse(row.Cells[0].Value.ToString());
                DisplaySelectedRowData(hoadonId);
            }
            else
            {
                ClearInputFields(); // Clear input fields since there's no data
            }
        }
        private void ClearInputFields()
        {
            tbMa.Text = null;
            date.Text = null;
            cbnv.Text = null;
            cbkh.Text = null;
            tbsdt.Text = null;
            cbSp.SelectedItem = null;
            tbgia.Text = null;
            tbsl.Text = null;
        }
        private void DisplaySelectedRowData(int hoadonId)
        {
            try
            {
                HoaDonBEL cus = cusBAL.GetHoadonById(hoadonId);
                if (cus != null)
                {
                    tbMa.Text = cus.id.ToString();
                    date.Value = DateTime.ParseExact(cus.ngaylap, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    // Set other fields based on the properties of the 'cus' object
                    // For example:
                    cbkh.Text = cus.kh.tenkhach; // Assuming 'kh' is a property of type KhachHangBEL in HoaDonBEL
                    cbnv.Text = cus.nv.tennhanvien; // Assuming 'nv' is a property of type nhanvienBEL in HoaDonBEL
                    cbSp.Text = cus.customer.Name;
                    tbsdt.Text = cus.sodienthoai.ToString();
                    tbgia.Text = cus.gia.ToString();
                    tbsl.Text = cus.soluong.ToString();
                    // Set other fields similarly
                }
                else
                {
                    ClearInputFields(); // Clear input fields since there's no data
                }
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    

        //private void tbNv_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!ValidateNameInput(tbNv.Text))
        //    {
        //        e.Cancel = true;
        //        MessageBox.Show("Tên nhân viên không hợp lệ. Vui lòng nhập tên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void tbTenkh_Validating(object sender, CancelEventArgs e)
        //{
        //    if (!ValidateNameInput(tbTenkh.Text))
        //    {
        //        e.Cancel = true;
        //        MessageBox.Show("Tên khách hàng không hợp lệ. Vui lòng nhập tên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

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

        private void cbkh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbkh.Text))
            {
                string tenkhach = cbkh.Text;
                string sql = "SELECT sodienthoai FROM khachhang WHERE tenkhach = @tenkhach";

                using (SqlConnection connection = dbConnection.CreateConnection())
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@tenkhach", tenkhach);

                    try
                    {
                        connection.Open();
                        object queryResult = command.ExecuteScalar();
                        if (queryResult != null)
                        {
                            tbsdt.Text = queryResult.ToString();
                        }
                        else
                        {
                            tbsdt.Text = "Không tìm thấy số điện thoại.";
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
                tbsdt.Text = "";
            }
        }

        private void cbnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void ExportToPDF(DataGridView dgv)
        {
            
            try
            {
                // Tạo tệp PDF
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "PDF file (*.pdf)|*.pdf";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveDialog.FileName, FileMode.Create));

                    document.Open();

                    PdfPTable pdfTable = new PdfPTable(dgv.Columns.Count);
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        pdfTable.AddCell(new Phrase(dgv.Columns[j].HeaderText));
                    }
                    pdfTable.HeaderRows = 1;

                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        for (int k = 0; k < dgv.Columns.Count; k++)
                        {
                            if (dgv[k, i].Value != null)
                            {
                                pdfTable.AddCell(new Phrase(dgv[k, i].Value.ToString()));
                            }
                        }
                    }

                    document.Add(pdfTable);
                    document.Close();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToPDF(dgvhd);
                MessageBox.Show("Xuất file PDF thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
