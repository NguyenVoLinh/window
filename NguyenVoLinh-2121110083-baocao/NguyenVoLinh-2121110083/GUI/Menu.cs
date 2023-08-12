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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GiaoDien trang2 = new GiaoDien();
            //trang2.ShowDialog();
            try
            {
                GiaoDien trang2 = new GiaoDien();
                trang2.ShowDialog();
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng chọn lại..", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //HoaDon trang2 = new HoaDon();
            //trang2.ShowDialog();
            try
            {
                HoaDon trang2 = new HoaDon();
                trang2.ShowDialog();
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng chọn lại..", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DanhMuc trang2 = new DanhMuc();
            //trang2.ShowDialog();
            try
            {
                DanhMuc trang2 = new DanhMuc();
                trang2.ShowDialog();
            }
            catch
            {
                MessageBox.Show("lỗi vui lòng chọn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn thoát chương trình?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
