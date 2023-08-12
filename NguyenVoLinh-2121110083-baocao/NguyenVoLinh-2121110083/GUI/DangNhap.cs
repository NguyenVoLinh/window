using NguyenVoLinh_2121110083.BAL;
using NguyenVoLinh_2121110083.GUI;
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

namespace NguyenVoLinh_2121110083
{
    public partial class Form1 : Form
    {
        TaiKhoanBAL cusBAL = new TaiKhoanBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            //string tk1 = tbTK.Text;
            //string mk1 = tbMK.Text;
            //bool dn = false;
            //bool kktk = false;
            //bool kkmk = false;

            //int length = tk1.Length;
            //int length1 = mk1.Length;
            //if (length < 5 || length >= 15)
            //{
            //    MessageBox.Show("Tài khoản phải từ 5-15 ký tự");
            //}
            //else
            //{
            //    kktk = true;
            //}
            //if (length1 < 5)
            //{
            //    MessageBox.Show("Mật khẩu ít nhất 5 ký tự");
            //}
            //else
            //{
            //    kkmk = true;
            //}

            //if (kktk == true && kkmk == true)
            //{
            //    List<TaiKhoanBEL> lstCus = cusBAL.ReadTaiKhoan();
            //    foreach (TaiKhoanBEL cus in lstCus)
            //    {
            //        if (cus.tentaikhoan == tk1 && cus.matkhau == mk1)
            //        {
            //            this.Hide();
            //            var form2 = new NguyenVoLinh_2121110083.GUI.Menu();
            //            form2.Closed += (s, args) => this.Close();
            //            form2.Show();
            //            dn = true;
            //            break;
            //        }

            //    }
            //    if (!dn)
            //    {
            //        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    }
            //}
            try
            {
                string tk1 = tbTK.Text;
                string mk1 = tbMK.Text;
                bool dn = false;
                bool kktk = false;
                bool kkmk = false;

                int length = tk1.Length;
                int length1 = mk1.Length;
                if (length < 5 || length >= 15)
                {
                    MessageBox.Show("Tài khoản phải từ 5-15 ký tự");
                }
                else
                {
                    kktk = true;
                }
                if (length1 < 5)
                {
                    MessageBox.Show("Mật khẩu ít nhất 5 ký tự");
                }
                else
                {
                    kkmk = true;
                }

                if (kktk == true && kkmk == true)
                {
                    List<TaiKhoanBEL> lstCus = cusBAL.ReadTaiKhoan();
                    foreach (TaiKhoanBEL cus in lstCus)
                    {
                        if (cus.tentaikhoan == tk1 && cus.matkhau == mk1)
                        {
                            this.Hide();
                            var form2 = new NguyenVoLinh_2121110083.GUI.Menu();
                            form2.Closed += (s, args) => this.Close();
                            MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            form2.Show();
                            dn = true;
                            
                            break;
                            
                        }

                    }
                    if (!dn)
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Hệ thống đang cập nhật vui lòng chờ đợi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

    }
}
