using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace baitap
{
    public partial class Form5 : Form
    {
        string path = @"D:\form.xml";

        public Form5()
        {
            InitializeComponent();
        }

        public void Write(InfoWindows iw)
        {
            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
            using (StreamWriter file = new StreamWriter(path))
            {
                writer.Serialize(file, iw);
            }
        }

        public InfoWindows Read()
        {
            XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
            using (StreamReader file = new StreamReader(path))
            {
                InfoWindows iw = (InfoWindows)reader.Deserialize(file);
                return iw;
            }
        }

        private void Form5_ResizeEnd(object sender, EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;
            Write(iw);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            this.Size = new Size(iw.Width, iw.Height);
        }
    }

//    public class InfoWindows
//    {
//        public int Width { get; set; }
//        public int Height { get; set; }
//    }
}
