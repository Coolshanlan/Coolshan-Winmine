using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 酷炫踩地雷
{
    public partial class Set_Color : Form
    {
        public Set_Color()
        {
            InitializeComponent();
            if (OK == false)
            {
                trackBar1.Value = Color.LightBlue.R;
                trackBar2.Value = Color.LightBlue.G;
                trackBar3.Value = Color.LightBlue.B;
                pictureBox1.BackColor = Color.FromArgb(255, trackBar1.Value, 0, 0);
                pictureBox2.BackColor = Color.FromArgb(255, 0, trackBar2.Value, 0);
                pictureBox3.BackColor = Color.FromArgb(255, 0, 0, trackBar3.Value);
                pictureBox4.BackColor = Color.FromArgb(255, trackBar1.Value, trackBar2.Value, trackBar3.Value);
                label1.Text = "R=" + trackBar1.Value;
                label2.Text = "G=" + trackBar2.Value;
                label3.Text = "B=" + trackBar3.Value;
            }
            else
            {
                trackBar1.Value =buttoncolor[0];
                trackBar2.Value =buttoncolor[1];
                trackBar3.Value =buttoncolor[2];
                pictureBox1.BackColor = Color.FromArgb(255, trackBar1.Value, 0, 0);
                pictureBox2.BackColor = Color.FromArgb(255, 0, trackBar2.Value, 0);
                pictureBox3.BackColor = Color.FromArgb(255, 0, 0, trackBar3.Value);
                pictureBox4.BackColor = Color.FromArgb(255, trackBar1.Value, trackBar2.Value, trackBar3.Value);
                label1.Text = "R=" + trackBar1.Value;
                label2.Text = "G=" + trackBar2.Value;
                label3.Text = "B=" + trackBar3.Value;
            }
        }
        public static int[] buttoncolor = new Int32[3];
        public static bool OK = false;
       private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "R=" + trackBar1.Value;
            label2.Text = "G=" + trackBar2.Value;
            label3.Text = "B=" + trackBar3.Value;
            pictureBox1.BackColor = Color.FromArgb(255, trackBar1.Value, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(255, 0, trackBar2.Value, 0);
            pictureBox3.BackColor = Color.FromArgb(255, 0,0, trackBar3.Value);
            pictureBox4.BackColor = Color.FromArgb(255, trackBar1.Value, trackBar2.Value, trackBar3.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OK = true;
            buttoncolor[0] = trackBar1.Value;
            buttoncolor[1] = trackBar2.Value;
            buttoncolor[2] = trackBar3.Value;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trackBar1.Value = Color.LightBlue.R;
            trackBar2.Value = Color.LightBlue.G;
            trackBar3.Value = Color.LightBlue.B;
            pictureBox1.BackColor = Color.FromArgb(255, trackBar1.Value, 0, 0);
            pictureBox2.BackColor = Color.FromArgb(255, 0, trackBar2.Value, 0);
            pictureBox3.BackColor = Color.FromArgb(255, 0, 0, trackBar3.Value);
            pictureBox4.BackColor = Color.FromArgb(255, trackBar1.Value, trackBar2.Value, trackBar3.Value);
            label1.Text = "R=" + trackBar1.Value;
            label2.Text = "G=" + trackBar2.Value;
            label3.Text = "B=" + trackBar3.Value;
        }
    }
}
