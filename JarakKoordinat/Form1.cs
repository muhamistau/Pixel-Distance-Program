using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JarakKoordinat
{
    public partial class Form1 : Form
    {

        int nMouseClick = 0;
        int x1, y1, x2, y2;
        public Form1()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.bmp)|*.jpg; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.Enabled = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            double euclidian, manhattan, chess;

            if (nMouseClick == 0)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                base.OnMouseHover(me);
                x1 = me.X;
                y1 = me.Y;

                textBoxX1.Text = x1.ToString();
                textBoxY1.Text = y1.ToString();
                nMouseClick = 1;
            }
            else
            {
                MouseEventArgs me = (MouseEventArgs)e;
                base.OnMouseHover(me);
                x2 = me.X;
                y2 = me.Y;

                textBoxX2.Text = x2.ToString();
                textBoxY2.Text = y2.ToString();
                nMouseClick = 0;

                euclidian = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
                manhattan = Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
                chess = Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
                textBoxEuclidian.Text = euclidian.ToString();
                textBoxManhattan.Text = manhattan.ToString();
                textBoxChess.Text = chess.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxX1.Text = null;
            textBoxY1.Text = null;
            textBoxX2.Text = null;
            textBoxY2.Text = null;
            x1 = 0;
            y1 = 0;
            x2 = 0;
            y2 = 0;
            textBoxEuclidian.Text = null;
            textBoxManhattan.Text = null;
            textBoxChess.Text = null;
        }
    }
}
