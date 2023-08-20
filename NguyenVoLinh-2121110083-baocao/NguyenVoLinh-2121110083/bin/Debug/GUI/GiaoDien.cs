using iTextSharp.text;
using iTextSharp.text.pdf;
using NguyenVoLinh_2121110083.BAL;
using NguyenVoLinh_2121110083.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace NguyenVoLinh_2121110083.GUI
{
    public partial class GiaoDien : Form
    {
        string img;
        string nameimg;
        private ErrorProvider errorProvider = new ErrorProvider();

        PictureBox pb = new PictureBox();
        CustomerBAL cusBAL = new CustomerBAL();
        AreaBAL areBAL = new AreaBAL();
        DanhMucBAL dmBAL = new DanhMucBAL();


        public GiaoDien()
        {
            InitializeComponent();
            dgvCustomer.RowsDefaultCellStyle.BackColor = Color.LightGray; // Thay đổi màu nền của các hàng trong DataGridView thành LightGray
            dgvCustomer.AlternatingRowsDefaultCellStyle.BackColor = Color.White; // Thay đổi màu nền của các hàng lẻ thành White
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCustomer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            

        }

        private void btNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    int newCustomerId = int.Parse(tbMa.Text);

                    if (IsCustomerIdDuplicate(newCustomerId))
                    {
                        MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng nhập mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    CustomerBEL cus = new CustomerBEL();
                    cus.Id = newCustomerId;
                    cus.Name = tbName.Text;
                    cus.Area = (AreaBEL)cbKv.SelectedItem;
                    cus.SoLuong = int.Parse(tbsl.Text);
                    cus.Gia = int.Parse(tbgia.Text);
                    cus.DM = (DanhMucBEL)cbNCC.SelectedItem;
                    cus.Anh = nameimg;
                    cusBAL.NewCustomer(cus);

                    dgvCustomer.Rows.Add(cus.Id, cus.Name, cus.AreaName, cus.SoLuong, cus.Gia, cus.Anh, cus.DanhMucName);
                    MessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng thêm lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool IsCustomerIdDuplicate(int customerId)
        {
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                if (row.Cells[0].Value != null && (int)row.Cells[0].Value == customerId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            string errorMessage = "Vui lòng nhập đầy đủ thông tin:\n\n";

            if (string.IsNullOrWhiteSpace(tbMa.Text) || string.IsNullOrWhiteSpace(tbName.Text) ||
                cbKv.SelectedItem == null || string.IsNullOrWhiteSpace(tbsl.Text) ||
                string.IsNullOrWhiteSpace(tbgia.Text) || string.IsNullOrWhiteSpace(nameimg) || cbNCC.SelectedItem == null)
            {

                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errorMessage, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isValid;
        }

        //ràng buộc số lượng
        private void tbsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
                MessageBox.Show("Vui lòng nhập số lượng.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //RÀNG buộc giá

        private void tbgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
                MessageBox.Show("Vui lòng nhập giá.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //ràng buộc tên

        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter or space or a control key (like backspace)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Prevent the character from being entered
                MessageBox.Show("Vui lòng chỉ nhập Tên.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        

        private void GiaoDien_Load(object sender, EventArgs e)
        {
            List<CustomerBEL> lstCus = cusBAL.ReadCustomerList();
            foreach (CustomerBEL cus in lstCus)
            {

                dgvCustomer.Rows.Add(cus.Id, cus.Name, cus.AreaName, cus.SoLuong, cus.Gia, cus.Anh, cus.DanhMucName);
            }
            List<AreaBEL> lstArea = areBAL.ReadAreaList();
            foreach (AreaBEL area in lstArea)
            {
                cbKv.Items.Add(area);
            }
            cbKv.DisplayMember = "name";
            List<DanhMucBEL> lstDM = dmBAL.ReadDanhmucList();
            foreach (DanhMucBEL dm in lstDM)
            {
                cbNCC.Items.Add(dm);
            }
            cbNCC.DisplayMember = "name";

            //ràng buộc số lượng
            tbsl.KeyPress += tbsl_KeyPress;
            //ràng buộc giá
            tbgia.KeyPress += tbgia_KeyPress;
            //ràng buộc tên 
            tbName.KeyPress += tbName_KeyPress;

            //ràng buộc mã
            tbMa.Validating += tbMa_Validating;


        }

        public int selectedRowIndex { get; set; }
        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //int idx = e.RowIndex;
            //DataGridViewRow row = dgvCustomer.Rows[idx];
            //if(row.Cells[0].Value!=null)
            //{
            //    tbMa.Text = row.Cells[0].Value.ToString();
            //    tbName.Text = row.Cells[1].Value.ToString();
            //    cbKv.Text = row.Cells[2].Value.ToString();
            //    tbsl.Text = row.Cells[3].Value.ToString();
            //    tbgia.Text = row.Cells[4].Value.ToString();
            //    if (row.Cells[5].Value != null)
            //    {
            //        // Kiểu đối tượng (object) chứa giá trị của ô hình ảnh
            //        img = dgvCustomer.Row.Cells[5].Value.ToString();
            //    }
            //    if (File.Exists(@"D:\lập trình windows\test\bai04\bai05\img" + img))
            //    {

            //        // Hiển thị hình ảnh trong PictureBox
            //        pt1.Image = new Bitmap(@"D:\lập trình windows\test\bai04\bai05\img" + img);
            //        pt1.SizeMode = PictureBoxSizeMode.Zoom;
            //    }
            //    else
            //    {
            //        pt1.Image = null;
            //    }
            //}
            //else
            //{
            //    tbMa.Text = null;
            //    tbName.Text = null;
            //    cbKv.Text = null;
            //    tbsl.Text = null;
            //    tbgia.Text = null;
            //    pt1.Image = null;
            //}

            int idx = e.RowIndex;
            DataGridViewRow row = dgvCustomer.Rows[idx];

            if (row.Cells[0].Value != null)
            {
                int customerId = int.Parse(row.Cells[0].Value.ToString());
                DisplaySelectedRowData(customerId);
            }
            else
            {
                ClearInputFields(); // Clear input fields since there's no data
            }
        }


        private void ClearInputFields()
        {
            tbMa.Text = "";
            tbName.Text = "";
            cbKv.SelectedItem = null;
            cbNCC.SelectedItem = null;
            tbsl.Text = "";
            tbgia.Text = "";
            nameimg = "";

            pt1.Image = null;
        }
        private void DisplaySelectedRowData(int customerId)
        {
            CustomerBEL cus = cusBAL.GetCustomerById(customerId);
            if (cus != null)
            {
                tbMa.Text = cus.Id.ToString();
                tbName.Text = cus.Name;
                cbKv.Text = cus.AreaName; // Select item in ComboBox based on Area
                cbNCC.Text = cus.DanhMucName;
                tbsl.Text = cus.SoLuong.ToString();
                tbgia.Text = cus.Gia.ToString();
                nameimg = cus.Anh;

                // Display image
                if (!string.IsNullOrEmpty(nameimg))
                {
                    string imagePath = Path.Combine(@"D:\laptrinhwindows\baocaolaptrinhwindows\NguyenVoLinh-2121110083-baocao\NguyenVoLinh-2121110083\img", nameimg);
                    if (File.Exists(imagePath))
                    {
                        pt1.Image = new Bitmap(imagePath);
                        pt1.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pt1.Image = null;
                    }
                }
                else
                {
                    pt1.Image = null;
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataGridViewRow row = dgvCustomer.CurrentRow;
                if (row != null)
                {
                    if (row.Cells[0].Value != null) // Check if the selected row has data
                    {
                        int customerId = int.Parse(row.Cells[0].Value.ToString());

                        // Delete the customer from the database
                        CustomerBEL customerToDelete = cusBAL.GetCustomerById(customerId);
                        if (customerToDelete != null)
                        {
                            cusBAL.DeleteCustomer(customerToDelete);
                        }

                        // Remove the customer from the DataGridView
                        dgvCustomer.Rows.RemoveAt(row.Index);
                        MessageBox.Show("Xoá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn một hàng có dữ liệu để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch
            {
                MessageBox.Show("lỗi vui lòng xoá lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btimg_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
            //openFileDialog.Multiselect = false; // Chỉ cho phép chọn một tệp tin

            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    // Lấy đường dẫn của hình ảnh đã chọn
            //    string imagePath = openFileDialog.FileName;
            //    string selectedImagePath = openFileDialog.FileName;

            //    // Lưu ảnh vào thư mục chỉ định
            //    string targetDirectory = @"D:\laptrinhwindows\baocaolaptrinhwindows\NguyenVoLinh-2121110083\NguyenVoLinh-2121110083\img"; // Thay đổi đường dẫn tới thư mục mong muốn
            //    string targetFileName = Path.Combine(targetDirectory, Path.GetFileName(selectedImagePath));

            //    nameimg = Path.GetFileName(selectedImagePath);


            //    File.Copy(selectedImagePath, targetFileName, true);
            //    // Load ảnh từ đường dẫn và thêm vào DataGridViewImageColumn

            //    pt1.Image = new Bitmap(openFileDialog.FileName);
            //    pt1.SizeMode = PictureBoxSizeMode.Zoom;
            //    pb.Image = new Bitmap(openFileDialog.FileName);
            //}
            
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All files (*.*)|*.*";
                    openFileDialog.Multiselect = false;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Lấy đường dẫn của hình ảnh đã chọn
                        string imagePath = openFileDialog.FileName;
                        string selectedImagePath = openFileDialog.FileName;

                        // Lưu ảnh vào thư mục chỉ định
                        string targetDirectory = @"D:\laptrinhwindows\baocaolaptrinhwindows\NguyenVoLinh-2121110083-baocao\NguyenVoLinh-2121110083\img"; // Thay đổi đường dẫn tới thư mục mong muốn
                        string targetFileName = Path.Combine(targetDirectory, Path.GetFileName(selectedImagePath));

                        nameimg = Path.GetFileName(selectedImagePath);


                        File.Copy(selectedImagePath, targetFileName, true);
                        // Load ảnh từ đường dẫn và thêm vào DataGridViewImageColumn

                        pt1.Image = new Bitmap(openFileDialog.FileName);
                        pt1.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.Image = new Bitmap(openFileDialog.FileName);
                    }
                }
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng chọn lại ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btEdit_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (dgvCustomer.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một hàng có dữ liệu để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ValidateInput())
                {
                    DataGridViewRow row = dgvCustomer.CurrentRow;
                    if (row != null)
                    {
                        CustomerBEL cus = new CustomerBEL();
                        cus.Id = int.Parse(tbMa.Text);
                        cus.Name = tbName.Text;
                        cus.SoLuong = int.Parse(tbsl.Text);
                        cus.Gia = int.Parse(tbgia.Text);
                        cus.Area = (AreaBEL)cbKv.SelectedItem;
                        cus.DM = (DanhMucBEL)cbNCC.SelectedItem;
                        cus.Anh = nameimg;
                        cusBAL.EditCustomer(cus);

                        row.Cells[0].Value = cus.Id;
                        row.Cells[1].Value = cus.Name;
                        row.Cells[2].Value = cus.AreaName;
                        row.Cells[3].Value = cus.SoLuong;
                        row.Cells[4].Value = cus.Gia;
                        row.Cells[5].Value = cus.Anh;
                        row.Cells[6].Value = cus.DanhMucName;
                        MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        

        //mã
        private bool ValidateProductIdInput(string input)
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
            if (!ValidateProductIdInput(tbMa.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Vui lòng nhập mã sản phẩm bằng số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int newProductId = int.Parse(tbMa.Text);
                if (IsProductIdDuplicate(newProductId))
                {
                    e.Cancel = true;
                    MessageBox.Show("Mã sản phẩm đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
        private bool IsProductIdDuplicate(int productId)
        {
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                if (row.Cells[0].Value != null && (int)row.Cells[0].Value == productId)
                {
                    return true;
                }
            }
            return false;
        }

        private void btExecl_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                        excelApp.Visible = false;
                        excelApp.Workbooks.Add();

                        Microsoft.Office.Interop.Excel._Worksheet worksheet = (Microsoft.Office.Interop.Excel._Worksheet)excelApp.ActiveSheet;

                        int rowIndex = 1;

                        // Header
                        for (int colIndex = 1; colIndex <= dgvCustomer.Columns.Count; colIndex++)
                        {
                            worksheet.Cells[rowIndex, colIndex] = dgvCustomer.Columns[colIndex - 1].HeaderText;
                        }
                        rowIndex++;

                        // Data
                        foreach (DataGridViewRow row in dgvCustomer.Rows)
                        {
                            for (int colIndex = 1; colIndex <= dgvCustomer.Columns.Count; colIndex++)
                            {
                                worksheet.Cells[rowIndex, colIndex] = row.Cells[colIndex - 1].Value;
                            }
                            rowIndex++;
                        }

                        worksheet.SaveAs(filePath);
                        MessageBox.Show("Xuất file execl thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        excelApp.Quit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void btPDF_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToPDF(dgvCustomer);
                MessageBox.Show("Xuất file PDF thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //tìm kiếm
        private void btSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBoxx
                string keyword = tbsearch.Text;

                // Thực hiện tìm kiếm dựa trên từ khóa
                SearchCustomers(keyword);
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SearchCustomers(string keyword)
        {
            try
            {
                dgvCustomer.Rows.Clear(); // Xóa các hàng hiện có

                List<CustomerBEL> lstCus = cusBAL.ReadCustomerList();

                foreach (CustomerBEL cus in lstCus)
                {
                    if (cus.Id.ToString().Contains(keyword) ||
                        cus.Name.Contains(keyword) ||
                        cus.AreaName.Contains(keyword))
                    /*cus.Gia.ToString("N0").Contains(keyword))*/ // Tìm kiếm theo giá tiền đã định dạng
                    {
                        /*string formattedGia = cus.Gia.ToString("N0") + CurrencySymbol;*/ // Định dạng giá tiền
                        dgvCustomer.Rows.Add(cus.Id, cus.Name, cus.AreaName, cus.SoLuong, cus.Gia, cus.Anh, cus.DanhMucName);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi vui lòng thực hiện lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
