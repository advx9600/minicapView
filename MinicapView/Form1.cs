using Minicap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinicapView
{
    public partial class Form1 : Form
    {
        MinicapStream minicap;
        MiniTouchStream minitouch;
        public Form1()
        {
            InitializeComponent();
            //minicap = new MinicapStream();            
            minitouch = new MiniTouchStream();
            startCapture();
        }

        private void UpdatePictureBox()
        {
            pictureBoxMain.Invalidate();
            byte[] buff = new byte[0];
            minicap.ImageByteQueue.TryDequeue(out buff);
            MemoryStream stream = new MemoryStream(buff);
            pictureBoxMain.Image = Image.FromStream(stream);
        }

        private void startCapture()
        {
            minicap = new MinicapStream();
            minicap.Update += new Minicap.MinicapEventHandler(UpdatePictureBox);
            Thread thread = new Thread(minicap.ReadImageStream);
            thread.Start();
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            minitouch.TouchDown(e);            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private Point Rotate(Point point)
        {
            //if (device.Orientation == 90)
            //{
            //    point = new Point(device.VirtualWidth - point.Y, point.X);
            //}
            return point;
        }
    }
}
