using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt01_Click(object sender, EventArgs e)
        {
            Form2 trang2 = new Form2();
            trang2.ShowDialog();
        }

        private void bt02_Click(object sender, EventArgs e)
        {
            Form3 trang3 = new Form3();
            trang3.ShowDialog();
        }

        //private void bt03_Click(object sender, EventArgs e)
        //{
        //    Form4 trang4 = new Form4();
        //    trang4.ShowDialog();
        //}

        //private void bt04_Click(object sender, EventArgs e)
        //{
        //    Form5 trang5 = new Form5();
        //    trang5.ShowDialog();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            _130_gdht trang5 = new _130_gdht();
            trang5.ShowDialog();
        }

        private void bt04_Click(object sender, EventArgs e)
        {

        }
    }
}
