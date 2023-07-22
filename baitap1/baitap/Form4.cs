//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml.Serialization;

//namespace baitap
//{
//    public partial class Form4 : Form
//    {
//        string path = @"D:\form.xml";

//        public Form4()
//        {
//            InitializeComponent();
//        }

//        public void Write(InfoWindows iw)
//        {
//            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
//            using (StreamWriter file = new StreamWriter(path))
//            {
//                writer.Serialize(file, iw);
//            }
//        }

//        private void Form4_ResizeEnd(object sender, EventArgs e)
//        {
//            InfoWindows iw = new InfoWindows();
//            iw.Width = this.Size.Width;
//            iw.Height = this.Size.Height;
//            Write(iw);
//        }

//        private void Form4_Load(object sender, EventArgs e)
//        {
//            if (File.Exists(path))
//            {
//                // Deserialize the XML file and set form size
//                XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
//                using (StreamReader file = new StreamReader(path))
//                {
//                    InfoWindows iw = (InfoWindows)reader.Deserialize(file);
//                    this.Size = new Size(iw.Width, iw.Height);
//                }
//            }
//        }
//    }

//    //public class InfoWindows
//    //{
//    //    public int Width { get; set; }
//    //    public int Height { get; set; }
//    //}
//}
