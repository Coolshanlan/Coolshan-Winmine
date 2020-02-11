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
    public partial class Boom : Form
    {
        public Boom()
        {
            InitializeComponent();
            if(Game.hide == 3)
            {
                if(Game.win.Count == Form1.bum)
                {
                    this.BackgroundImage = Properties.Resources.goodclick;
                    this.BackgroundImageLayout = ImageLayout.Zoom;
                    this.ClientSize = new Size(915, 517);
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.難過;
                    this.BackgroundImageLayout = ImageLayout.Zoom;
                    this.ClientSize = new Size(686, 359);
                }
            }
            else
            {
                this.BackgroundImage = Properties.Resources.Boom;
                this.BackgroundImageLayout = ImageLayout.Zoom;
                this.ClientSize = new Size(780, 517);
            }
        }

        private void Boom_Load(object sender, EventArgs e)
        {

        }

        private void Boom_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
