using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace 酷炫踩地雷
{
    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Program Files\Microsoft Games\Minesweeper\MineSweeper.exe");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            (new Form1()).Show();
            timer1.Enabled = true;
        }

        private void Choose_Load(object sender, EventArgs e)
        {
            //if (File.Exists(Path.GetFullPath("pyhscore.exe")))
            //    Process.Start(Path.GetFullPath("pyhscore.exe"));
        }
    }
}
