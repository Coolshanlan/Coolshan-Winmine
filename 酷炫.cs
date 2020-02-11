using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 酷炫踩地雷
{
    public partial class 酷炫 : Form
    {
        public 酷炫()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.URL = Path.GetFullPath("..\\..\\Pictures\\進入遊戲.wav");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.01;
            if(this.Opacity >= 1)
            {
                this.Close();
            }
        }
    }
}
