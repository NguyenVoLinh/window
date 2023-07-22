using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace baitap
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        void Form3_ResizeEnd(object sender, System.EventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            this.Text = width.ToString() + " - " + height.ToString();
        }
        void Form3_Load(object sender, System.EventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            this.Text = width.ToString() + " - " + height.ToString();
        }
      
        //private void Form3_Load(object sender, EventArgs e)
        //{

        //}
    }
}
